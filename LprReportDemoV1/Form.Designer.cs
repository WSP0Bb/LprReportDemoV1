
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
            this.SuspendLayout();
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(15, 223);
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
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Export FilePath";
            // 
            // imgPathTextBox
            // 
            this.imgPathTextBox.Location = new System.Drawing.Point(185, 32);
            this.imgPathTextBox.Name = "imgPathTextBox";
            this.imgPathTextBox.Size = new System.Drawing.Size(393, 29);
            this.imgPathTextBox.TabIndex = 3;
            // 
            // exportPathTextBox
            // 
            this.exportPathTextBox.Location = new System.Drawing.Point(185, 94);
            this.exportPathTextBox.Name = "exportPathTextBox";
            this.exportPathTextBox.Size = new System.Drawing.Size(393, 29);
            this.exportPathTextBox.TabIndex = 4;
            // 
            // exportFileNameTextBox
            // 
            this.exportFileNameTextBox.Location = new System.Drawing.Point(185, 160);
            this.exportFileNameTextBox.Name = "exportFileNameTextBox";
            this.exportFileNameTextBox.Size = new System.Drawing.Size(220, 29);
            this.exportFileNameTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "File Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = ".xls";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 278);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.exportFileNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.exportPathTextBox);
            this.Controls.Add(this.imgPathTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

