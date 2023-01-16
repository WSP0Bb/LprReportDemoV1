
namespace LprReportDemoV1
{
  partial class Form
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.exportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imgPathTextBox = new System.Windows.Forms.TextBox();
            this.exportPathTextBox = new System.Windows.Forms.TextBox();
            this.exportFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.destinationGroupBox = new System.Windows.Forms.GroupBox();
            this.imgPathBrowseButton = new System.Windows.Forms.Button();
            this.exportPathBrowseButton = new System.Windows.Forms.Button();
            this.destinationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // exportButton
            // 
            this.exportButton.Font = new System.Drawing.Font("CordiaUPC", 18F, System.Drawing.FontStyle.Bold);
            this.exportButton.Location = new System.Drawing.Point(15, 248);
            this.exportButton.Margin = new System.Windows.Forms.Padding(6);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(563, 40);
            this.exportButton.TabIndex = 0;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.onExportButtonClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("CordiaUPC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("CordiaUPC", 18F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(36, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Export FilePath";
            // 
            // imgPathTextBox
            // 
            this.imgPathTextBox.Font = new System.Drawing.Font("CordiaUPC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgPathTextBox.Location = new System.Drawing.Point(156, 40);
            this.imgPathTextBox.Name = "imgPathTextBox";
            this.imgPathTextBox.Size = new System.Drawing.Size(294, 41);
            this.imgPathTextBox.TabIndex = 3;
            // 
            // exportPathTextBox
            // 
            this.exportPathTextBox.Font = new System.Drawing.Font("CordiaUPC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportPathTextBox.Location = new System.Drawing.Point(156, 102);
            this.exportPathTextBox.Name = "exportPathTextBox";
            this.exportPathTextBox.Size = new System.Drawing.Size(294, 41);
            this.exportPathTextBox.TabIndex = 4;
            // 
            // exportFileNameTextBox
            // 
            this.exportFileNameTextBox.Font = new System.Drawing.Font("CordiaUPC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportFileNameTextBox.Location = new System.Drawing.Point(129, 188);
            this.exportFileNameTextBox.Name = "exportFileNameTextBox";
            this.exportFileNameTextBox.Size = new System.Drawing.Size(258, 41);
            this.exportFileNameTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("CordiaUPC", 18F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(36, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "File Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("CordiaUPC", 17F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(391, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = ".xlsx";
            // 
            // destinationGroupBox
            // 
            this.destinationGroupBox.Controls.Add(this.exportPathBrowseButton);
            this.destinationGroupBox.Controls.Add(this.imgPathBrowseButton);
            this.destinationGroupBox.Controls.Add(this.imgPathTextBox);
            this.destinationGroupBox.Controls.Add(this.exportPathTextBox);
            this.destinationGroupBox.Font = new System.Drawing.Font("CordiaUPC", 18F, System.Drawing.FontStyle.Bold);
            this.destinationGroupBox.Location = new System.Drawing.Point(15, 13);
            this.destinationGroupBox.Name = "destinationGroupBox";
            this.destinationGroupBox.Size = new System.Drawing.Size(563, 159);
            this.destinationGroupBox.TabIndex = 8;
            this.destinationGroupBox.TabStop = false;
            this.destinationGroupBox.Text = "Destination Folder";
            // 
            // imgPathBrowseButton
            // 
            this.imgPathBrowseButton.Font = new System.Drawing.Font("CordiaUPC", 18F, System.Drawing.FontStyle.Bold);
            this.imgPathBrowseButton.Location = new System.Drawing.Point(466, 45);
            this.imgPathBrowseButton.Name = "imgPathBrowseButton";
            this.imgPathBrowseButton.Size = new System.Drawing.Size(82, 34);
            this.imgPathBrowseButton.TabIndex = 0;
            this.imgPathBrowseButton.Text = "Browse...";
            this.imgPathBrowseButton.UseVisualStyleBackColor = true;
            this.imgPathBrowseButton.Click += new System.EventHandler(this.imgPathBrowseButton_Click);
            // 
            // exportPathBrowseButton
            // 
            this.exportPathBrowseButton.Font = new System.Drawing.Font("CordiaUPC", 18F, System.Drawing.FontStyle.Bold);
            this.exportPathBrowseButton.Location = new System.Drawing.Point(466, 105);
            this.exportPathBrowseButton.Name = "exportPathBrowseButton";
            this.exportPathBrowseButton.Size = new System.Drawing.Size(82, 34);
            this.exportPathBrowseButton.TabIndex = 5;
            this.exportPathBrowseButton.Text = "Browse...";
            this.exportPathBrowseButton.UseVisualStyleBackColor = true;
            this.exportPathBrowseButton.Click += new System.EventHandler(this.exportPathBrowseButton_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 303);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.exportFileNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.destinationGroupBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.destinationGroupBox.ResumeLayout(false);
            this.destinationGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button exportButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox imgPathTextBox;
    private System.Windows.Forms.TextBox exportPathTextBox;
        private System.Windows.Forms.TextBox exportFileNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox destinationGroupBox;
        private System.Windows.Forms.Button exportPathBrowseButton;
        private System.Windows.Forms.Button imgPathBrowseButton;
    }
}

