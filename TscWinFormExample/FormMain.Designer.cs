﻿namespace TSCLIB_DLL_IN_C_Sharp
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPrintSendCmd = new System.Windows.Forms.Button();
            this.fieldPortName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldCmd = new System.Windows.Forms.RichTextBox();
            this.buttonLibSendCmd = new System.Windows.Forms.Button();
            this.buttonLibInit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPrintSendCmd
            // 
            this.buttonPrintSendCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrintSendCmd.Location = new System.Drawing.Point(323, 11);
            this.buttonPrintSendCmd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrintSendCmd.Name = "buttonPrintSendCmd";
            this.buttonPrintSendCmd.Size = new System.Drawing.Size(290, 25);
            this.buttonPrintSendCmd.TabIndex = 0;
            this.buttonPrintSendCmd.Text = "Send cmd";
            this.buttonPrintSendCmd.UseVisualStyleBackColor = true;
            this.buttonPrintSendCmd.Click += new System.EventHandler(this.buttonPrintSendCmd_Click);
            // 
            // fieldPortName
            // 
            this.fieldPortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldPortName.Location = new System.Drawing.Point(106, 12);
            this.fieldPortName.Margin = new System.Windows.Forms.Padding(4);
            this.fieldPortName.Name = "fieldPortName";
            this.fieldPortName.Size = new System.Drawing.Size(200, 22);
            this.fieldPortName.TabIndex = 1;
            this.fieldPortName.Text = "SCALES-PRN-TSC";
            this.fieldPortName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Printer name";
            // 
            // fieldCmd
            // 
            this.fieldCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldCmd.Location = new System.Drawing.Point(13, 88);
            this.fieldCmd.Margin = new System.Windows.Forms.Padding(4);
            this.fieldCmd.Name = "fieldCmd";
            this.fieldCmd.Size = new System.Drawing.Size(600, 521);
            this.fieldCmd.TabIndex = 4;
            this.fieldCmd.Text = "";
            // 
            // buttonLibSendCmd
            // 
            this.buttonLibSendCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLibSendCmd.Location = new System.Drawing.Point(323, 44);
            this.buttonLibSendCmd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLibSendCmd.Name = "buttonLibSendCmd";
            this.buttonLibSendCmd.Size = new System.Drawing.Size(290, 25);
            this.buttonLibSendCmd.TabIndex = 5;
            this.buttonLibSendCmd.Text = "TscPrintControl send cmd";
            this.buttonLibSendCmd.UseVisualStyleBackColor = true;
            this.buttonLibSendCmd.Click += new System.EventHandler(this.buttonLibSendCmd_Click);
            // 
            // buttonLibInit
            // 
            this.buttonLibInit.Location = new System.Drawing.Point(13, 44);
            this.buttonLibInit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLibInit.Name = "buttonLibInit";
            this.buttonLibInit.Size = new System.Drawing.Size(290, 25);
            this.buttonLibInit.TabIndex = 6;
            this.buttonLibInit.Text = "TscPrintControl init";
            this.buttonLibInit.UseVisualStyleBackColor = true;
            this.buttonLibInit.Click += new System.EventHandler(this.buttonLibInit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 622);
            this.Controls.Add(this.buttonLibInit);
            this.Controls.Add(this.buttonLibSendCmd);
            this.Controls.Add(this.fieldCmd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fieldPortName);
            this.Controls.Add(this.buttonPrintSendCmd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "TSC print example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPrintSendCmd;
        private System.Windows.Forms.TextBox fieldPortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox fieldCmd;
        private System.Windows.Forms.Button buttonLibSendCmd;
        private System.Windows.Forms.Button buttonLibInit;
    }
}
