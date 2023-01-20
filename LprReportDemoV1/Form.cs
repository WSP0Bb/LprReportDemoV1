using System;
using System.Collections.Generic;
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

        private void onImgPathBrowseButtonClicked(object sender, EventArgs e)
        {
            string exportPath = openFolderBrowseDialog();
            imgPathTextBox.Text = exportPath;
        }
        private void onExportPathBrowseButtonClicked(object sender, EventArgs e)
        {
            string exportPath = openFolderBrowseDialog();
            exportPathTextBox.Text = exportPath;
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

                SaveImageDirectoryInfo saveImgDirectory = new SaveImageDirectoryInfo(baseImgPath);
                var saveImgFileInfoList = saveImgDirectory.getSaveImageFileInfo();

                try
                {

                    //a copy of SaveImageFileInfo
                    LinkedList<SaveImageFileInfo> saveImageFileInfoLinkedList = new LinkedList<SaveImageFileInfo>(saveImgFileInfoList);

                    int ExcelCounter = 1;

                    while (saveImageFileInfoLinkedList.Count > 0)
                    {

                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        Workbook workbook = new Workbook();
                        Worksheet worksheet = workbook.Worksheets[0];
                        #region    INIT_EXCEL_PROPERTIES

                        worksheet.Range["A1"].ColumnWidth = 8;
                        worksheet.Range["B1"].ColumnWidth = 60.25;
                        worksheet.Range["C1"].ColumnWidth = 8.5;
                        worksheet.Range["D1"].ColumnWidth = 8;

                        worksheet.Range["A1"].RowHeight = 20;

                        worksheet.Range["A1"].Text = "Date";
                        worksheet.Range["B1"].Text = "Picture";
                        worksheet.Range["C1"].Text = "License";
                        worksheet.Range["D1"].Text = "หมายเหตุ";

                        #endregion INIT_EXCEL_PROPERTIES

                        List<SaveImageFileInfo> eachList = new List<SaveImageFileInfo>();
                        //this part move data in form of LinkedList to remove first 300 datas with new set of datas to put in to loop
                        while ((eachList.Count < 300) && (saveImageFileInfoLinkedList.Count > 0))
                        {
                            eachList.Add(saveImageFileInfoLinkedList.First.Value);
                            saveImageFileInfoLinkedList.RemoveFirst();
                        }
                        //now the variable 'eachList' only contain 300 or less datas


                        List<Image> imageList = new List<Image>();


                        for (int i = 0; i < eachList.Count; i++)
                        {
                            //put each datas in 'eachList' in to each Excel row
                            int rowIndex = 2 + i;
                            var eachSaveImgFileInfo = eachList[i];
                            String dateTimeStr = eachSaveImgFileInfo.saveImageDirectoryInfo.getDateStringForDisplayInUi() + "\n" + eachSaveImgFileInfo.getTimeStringForDisplayInUi();
                            Image image = loadImage(eachSaveImgFileInfo.fullPath);
                            imageList.Add(image);
                            String licenseStr = eachSaveImgFileInfo.licensePlate;
                            String province = eachSaveImgFileInfo.province;

                            #region IN_EXCEL_PROPERTIES

                            worksheet.Range["A" + rowIndex].RowHeight = 190;

                            worksheet.Range["A" + rowIndex].Text = dateTimeStr;
                            worksheet.Pictures.Add(rowIndex, 2, image);
                            worksheet.Range["C" + rowIndex].Text = licenseStr;
                            worksheet.Range["D" + rowIndex].Text = "";

                            worksheet.Range["A" + rowIndex].Style.VerticalAlignment = VerticalAlignType.Center;
                            worksheet.Range["B" + rowIndex].Style.VerticalAlignment = VerticalAlignType.Center;
                            worksheet.Range["C" + rowIndex].Style.VerticalAlignment = VerticalAlignType.Center;
                            #endregion IN_EXCEL_PROPERTIES

                            Thread.Sleep(100);
                        }

                        #region END_EXCEL_PROPERTIES

                        string borderBound = $"A1:D{(eachList.Count + 1).ToString()}";
                        CellRange borderRange = worksheet.Range[borderBound];
                        borderRange.BorderAround(LineStyleType.Thin, Color.Black);
                        borderRange.BorderInside(LineStyleType.Thin, Color.Black);

                        string smallFontBound = $"A2:A{(eachList.Count + 1).ToString()}";
                        CellRange fontRange = worksheet.Range[smallFontBound];
                        fontRange.Style.Font.Size = 8;
                        #endregion END_EXCEL_PROPERTIES

                        //after the for loop above is done, put datas in to Excel file
                        workbook.SaveToFile(exportPathTextBox.Text + "\\" + exportFileNameTextBox.Text + "-" + ExcelCounter + ".xls");
                        foreach (Image im in imageList)
                        {
                            im.Dispose();
                        }
                        worksheet.Dispose();
                        workbook.Dispose();

                        ExcelCounter++;

                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();


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

        }


        #region RESIZE_IMAGE_UTILS

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

        public static string openFolderBrowseDialog()
        {
            string selectedPath = null;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK && (!String.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath)))
            {
                selectedPath = folderBrowserDialog.SelectedPath;
            }
            return selectedPath;
        }

        
    }

}