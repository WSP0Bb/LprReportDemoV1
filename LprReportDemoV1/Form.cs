using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Xls;
using CIT.LPR.SaveImageUtils;
using CIT.Utils.Logs;



namespace LprReportDemoV1
{
    public partial class Form : System.Windows.Forms.Form
    {

        static CreativeLoggerV1 logger = new CreativeLoggerV1("LprReportDemo", @".\Logs\LprReportDemo");
        LogFunctionV1 log = null;


        public Form()
        {
            InitializeComponent();
            this.log = logger.getLogFunctionV1();
            this.log.logDebugCallback = (str) =>
            {
                Debug.WriteLine(str);
                logger.logDebug(str);
            };
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            exportFileNameTextBox.Text = $"LPR Report";
            exportPathTextBox.Text = $"C:\\Users\\{Environment.UserName}\\Documents";
        }


        private void onExportButtonClicked(object sender, EventArgs eventArgs)
        {

            Exception exceptionThrown = null;
            String baseImgPath = imgPathTextBox.Text;

            if (String.IsNullOrWhiteSpace(baseImgPath))
            {
                MessageBox.Show("กรุณาใส่ Image Path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.exportButton.Enabled = false;
            Task.Run(() =>
            {

                SaveImageDirectoryInfo saveImageDirectory = new SaveImageDirectoryInfo(baseImgPath);
                var saveImgFileInfoList = saveImageDirectory.getSaveImageFileInfo();

                try
                {
                    Workbook workbook = new Workbook();
                    Worksheet worksheet = workbook.Worksheets[0];

                    #region    INIT_COLUMN_WIDTH

                    worksheet.Range["A1"].ColumnWidth = 8;
                    worksheet.Range["B1"].ColumnWidth = 60.25;
                    worksheet.Range["C1"].ColumnWidth = 8.5;
                    worksheet.Range["D1"].ColumnWidth = 8;

                    #endregion INIT_COLUMN_WIDTH

                    worksheet.Range["A1"].RowHeight = 20;

                    worksheet.Range["A1"].Text = "Date";
                    worksheet.Range["B1"].Text = "Picture";
                    worksheet.Range["C1"].Text = "License";
                    worksheet.Range["D1"].Text = "หมายเหตุ";

                    worksheet.Range["A1"].Style.VerticalAlignment = VerticalAlignType.Center;
                    worksheet.Range["B1"].Style.VerticalAlignment = VerticalAlignType.Center;
                    worksheet.Range["C1"].Style.VerticalAlignment = VerticalAlignType.Center;
                    worksheet.Range["D1"].Style.VerticalAlignment = VerticalAlignType.Center;


                    for (int i = 0; i < saveImgFileInfoList.Count; i++)
                    {
                        int rowIndex = 2 + i;
                        var eachSaveImgFileInfo = saveImgFileInfoList[i];
                        String dateTimeStr = eachSaveImgFileInfo.saveImageDirectoryInfo.getDateStringForDisplayInUi() + "\n" + eachSaveImgFileInfo.getTimeStringForDisplayInUi();
                        Image image = loadImage(eachSaveImgFileInfo.fullPath); //ดึงรูปมาใส่ตัวแปร image
                        String licenseStr = eachSaveImgFileInfo.licensePlate; //ดึงทะเบียนมาใส่ตัวแปร licenseStr
                        String province = eachSaveImgFileInfo.province; //ดึงจังหวัดมาใส่ตัวแปร province

                        #region    INIT_ROW_WIDTH
                        worksheet.Range["A" + rowIndex].RowHeight = 190;
                        #endregion INIT_ROW_WIDTH

                        //Add data to table
                        worksheet.Range["A" + rowIndex].Text = dateTimeStr;
                        worksheet.Pictures.Add(rowIndex, 2, image);
                        worksheet.Range["C" + rowIndex].Text = licenseStr;
                        worksheet.Range["D" + rowIndex].Text = "";

                        //Allign output to center of the field
                        worksheet.Range["A" + rowIndex].Style.VerticalAlignment = VerticalAlignType.Center;
                        worksheet.Range["C" + rowIndex].Style.VerticalAlignment = VerticalAlignType.Center;
                        worksheet.Range["C" + rowIndex].Style.HorizontalAlignment = HorizontalAlignType.Center;

                        Thread.Sleep(100);
                    }

                    string borderBound = $"A1:D{(saveImgFileInfoList.Count + 1).ToString()}";
                    CellRange borderRange = worksheet.Range[borderBound];
                    borderRange.BorderAround(LineStyleType.Thin, Color.Black);
                    borderRange.BorderInside(LineStyleType.Thin, Color.Black);

                    string smallFontBound = $"A2:A{(saveImgFileInfoList.Count + 1).ToString()}";
                    CellRange fontRange = worksheet.Range[smallFontBound];
                    fontRange.Style.Font.Size = 8;

                    workbook.SaveToFile(exportPathTextBox.Text + "\\" + exportFileNameTextBox.Text + ".xls");

                }

                catch (Exception exception)
                {
                    logger.logDebug("Error creating Excel : " + exception.Message);
                    exceptionThrown = exception;
                }

                this.Invoke(new Action(() =>
                {
                    if (exceptionThrown != null) { MessageBox.Show("Error : " + exceptionThrown.Message); }
                    this.exportButton.Enabled = true;
                }));
            });

            //หา Library ที่สามารถต่อไฟล์ได้ + หรือรวมไฟล์ได้ *** 

        }


        #region RESIZE_IMAGE_UTILS

        //public static Image resizeImage(Image imgToResize, Size size){
        //  return (Image)(new Bitmap(imgToResize, size));
        //}


        public static Image loadImage(String imgPath)
        {
            Image baseImage = Image.FromFile(imgPath);
            Image resizedImage = resizeImage(baseImage, new Size(16 * 28, 9 * 28));
            baseImage.Dispose();
            return resizedImage;
        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {

            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        #endregion RESIZE_IMAGE_UTILS

    }
}


/*
Image ratio
1920 / 1080

192 / 108
48 / 27
16 / 9
640 / 360 ( x 40 ) 

 */