﻿namespace ScalesUI.Controls;

partial class KneadingUserControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonPalletSizeNext = new System.Windows.Forms.Button();
            this.buttonPalletSizePrev = new System.Windows.Forms.Button();
            this.buttonPalletSize10 = new System.Windows.Forms.Button();
            this.fieldPalletSize = new System.Windows.Forms.Label();
            this.labelPalletSize = new System.Windows.Forms.Label();
            this.buttonDtRight = new System.Windows.Forms.Button();
            this.buttonDtLeft = new System.Windows.Forms.Button();
            this.buttonKneading = new System.Windows.Forms.Button();
            this.fieldKneading = new System.Windows.Forms.Label();
            this.labelKneading = new System.Windows.Forms.Label();
            this.labelProdDate = new System.Windows.Forms.Label();
            this.fieldProdDate = new System.Windows.Forms.Label();
            this.buttonSet40 = new System.Windows.Forms.Button();
            this.buttonSet60 = new System.Windows.Forms.Button();
            this.buttonSet120 = new System.Windows.Forms.Button();
            this.buttonSet1 = new System.Windows.Forms.Button();
            this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.layoutPanel.SuspendLayout();
            this.flowLayoutPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(697, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(200, 122);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.Transparent;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.Location = new System.Drawing.Point(491, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(200, 122);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonPalletSizeNext
            // 
            this.buttonPalletSizeNext.BackColor = System.Drawing.Color.Transparent;
            this.buttonPalletSizeNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPalletSizeNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPalletSizeNext.Location = new System.Drawing.Point(592, 188);
            this.buttonPalletSizeNext.Name = "buttonPalletSizeNext";
            this.buttonPalletSizeNext.Size = new System.Drawing.Size(138, 82);
            this.buttonPalletSizeNext.TabIndex = 17;
            this.buttonPalletSizeNext.Text = ">";
            this.buttonPalletSizeNext.UseVisualStyleBackColor = false;
            this.buttonPalletSizeNext.Click += new System.EventHandler(this.ButtonPalletSizeNext_Click);
            // 
            // buttonPalletSizePrev
            // 
            this.buttonPalletSizePrev.BackColor = System.Drawing.Color.Transparent;
            this.buttonPalletSizePrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPalletSizePrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPalletSizePrev.Location = new System.Drawing.Point(448, 188);
            this.buttonPalletSizePrev.Name = "buttonPalletSizePrev";
            this.buttonPalletSizePrev.Size = new System.Drawing.Size(138, 82);
            this.buttonPalletSizePrev.TabIndex = 16;
            this.buttonPalletSizePrev.Text = "<";
            this.buttonPalletSizePrev.UseVisualStyleBackColor = false;
            this.buttonPalletSizePrev.Click += new System.EventHandler(this.ButtonPalletSizePrev_Click);
            // 
            // buttonPalletSize10
            // 
            this.buttonPalletSize10.BackColor = System.Drawing.Color.Transparent;
            this.buttonPalletSize10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPalletSize10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPalletSize10.Location = new System.Drawing.Point(736, 188);
            this.buttonPalletSize10.Name = "buttonPalletSize10";
            this.buttonPalletSize10.Size = new System.Drawing.Size(138, 82);
            this.buttonPalletSize10.TabIndex = 18;
            this.buttonPalletSize10.Text = "+10";
            this.buttonPalletSize10.UseVisualStyleBackColor = false;
            this.buttonPalletSize10.Click += new System.EventHandler(this.ButtonPalletSizeSet10_Click);
            // 
            // fieldPalletSize
            // 
            this.fieldPalletSize.AutoSize = true;
            this.fieldPalletSize.BackColor = System.Drawing.Color.Transparent;
            this.fieldPalletSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldPalletSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldPalletSize.Location = new System.Drawing.Point(304, 188);
            this.fieldPalletSize.Margin = new System.Windows.Forms.Padding(3);
            this.fieldPalletSize.Name = "fieldPalletSize";
            this.fieldPalletSize.Size = new System.Drawing.Size(138, 82);
            this.fieldPalletSize.TabIndex = 13;
            this.fieldPalletSize.Text = "Value";
            this.fieldPalletSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPalletSize
            // 
            this.labelPalletSize.AutoSize = true;
            this.labelPalletSize.BackColor = System.Drawing.Color.Transparent;
            this.labelPalletSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPalletSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPalletSize.Location = new System.Drawing.Point(25, 188);
            this.labelPalletSize.Margin = new System.Windows.Forms.Padding(3);
            this.labelPalletSize.Name = "labelPalletSize";
            this.labelPalletSize.Size = new System.Drawing.Size(273, 82);
            this.labelPalletSize.TabIndex = 11;
            this.labelPalletSize.Text = "labelPalletSize";
            this.labelPalletSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDtRight
            // 
            this.buttonDtRight.BackColor = System.Drawing.Color.Transparent;
            this.buttonDtRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDtRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDtRight.Location = new System.Drawing.Point(592, 12);
            this.buttonDtRight.Name = "buttonDtRight";
            this.buttonDtRight.Size = new System.Drawing.Size(138, 82);
            this.buttonDtRight.TabIndex = 10;
            this.buttonDtRight.Text = ">";
            this.buttonDtRight.UseVisualStyleBackColor = false;
            this.buttonDtRight.Click += new System.EventHandler(this.ButtonDtRight_Click);
            // 
            // buttonDtLeft
            // 
            this.buttonDtLeft.BackColor = System.Drawing.Color.Transparent;
            this.buttonDtLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDtLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDtLeft.Location = new System.Drawing.Point(448, 12);
            this.buttonDtLeft.Name = "buttonDtLeft";
            this.buttonDtLeft.Size = new System.Drawing.Size(138, 82);
            this.buttonDtLeft.TabIndex = 9;
            this.buttonDtLeft.Text = "<";
            this.buttonDtLeft.UseVisualStyleBackColor = false;
            this.buttonDtLeft.Click += new System.EventHandler(this.ButtonDtLeft_Click);
            // 
            // buttonKneading
            // 
            this.buttonKneading.BackColor = System.Drawing.Color.Transparent;
            this.buttonKneading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonKneading.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonKneading.Location = new System.Drawing.Point(448, 100);
            this.buttonKneading.Name = "buttonKneading";
            this.buttonKneading.Size = new System.Drawing.Size(138, 82);
            this.buttonKneading.TabIndex = 6;
            this.buttonKneading.Text = "...";
            this.buttonKneading.UseVisualStyleBackColor = false;
            this.buttonKneading.Click += new System.EventHandler(this.ButtonKneadingLeft_Click);
            // 
            // fieldKneading
            // 
            this.fieldKneading.AutoSize = true;
            this.fieldKneading.BackColor = System.Drawing.Color.Transparent;
            this.fieldKneading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldKneading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldKneading.Location = new System.Drawing.Point(304, 100);
            this.fieldKneading.Margin = new System.Windows.Forms.Padding(3);
            this.fieldKneading.Name = "fieldKneading";
            this.fieldKneading.Size = new System.Drawing.Size(138, 82);
            this.fieldKneading.TabIndex = 2;
            this.fieldKneading.Text = "Value";
            this.fieldKneading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelKneading
            // 
            this.labelKneading.AutoSize = true;
            this.labelKneading.BackColor = System.Drawing.Color.Transparent;
            this.labelKneading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelKneading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKneading.Location = new System.Drawing.Point(25, 100);
            this.labelKneading.Margin = new System.Windows.Forms.Padding(3);
            this.labelKneading.Name = "labelKneading";
            this.labelKneading.Size = new System.Drawing.Size(273, 82);
            this.labelKneading.TabIndex = 3;
            this.labelKneading.Text = "labelKneading";
            this.labelKneading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelProdDate
            // 
            this.labelProdDate.AutoSize = true;
            this.labelProdDate.BackColor = System.Drawing.Color.Transparent;
            this.labelProdDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProdDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProdDate.Location = new System.Drawing.Point(25, 12);
            this.labelProdDate.Margin = new System.Windows.Forms.Padding(3);
            this.labelProdDate.Name = "labelProdDate";
            this.labelProdDate.Size = new System.Drawing.Size(273, 82);
            this.labelProdDate.TabIndex = 7;
            this.labelProdDate.Text = "labelProdDate";
            this.labelProdDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldProdDate
            // 
            this.fieldProdDate.AutoSize = true;
            this.fieldProdDate.BackColor = System.Drawing.Color.Transparent;
            this.fieldProdDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldProdDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldProdDate.Location = new System.Drawing.Point(304, 12);
            this.fieldProdDate.Margin = new System.Windows.Forms.Padding(3);
            this.fieldProdDate.Name = "fieldProdDate";
            this.fieldProdDate.Size = new System.Drawing.Size(138, 82);
            this.fieldProdDate.TabIndex = 8;
            this.fieldProdDate.Text = "01.01.2020";
            this.fieldProdDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSet40
            // 
            this.buttonSet40.BackColor = System.Drawing.Color.Transparent;
            this.buttonSet40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSet40.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSet40.Location = new System.Drawing.Point(448, 276);
            this.buttonSet40.Name = "buttonSet40";
            this.buttonSet40.Size = new System.Drawing.Size(138, 82);
            this.buttonSet40.TabIndex = 19;
            this.buttonSet40.Text = "40";
            this.buttonSet40.UseVisualStyleBackColor = false;
            this.buttonSet40.Click += new System.EventHandler(this.ButtonPalletSizeSet40_Click);
            // 
            // buttonSet60
            // 
            this.buttonSet60.BackColor = System.Drawing.Color.Transparent;
            this.buttonSet60.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSet60.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSet60.Location = new System.Drawing.Point(592, 276);
            this.buttonSet60.Name = "buttonSet60";
            this.buttonSet60.Size = new System.Drawing.Size(138, 82);
            this.buttonSet60.TabIndex = 20;
            this.buttonSet60.Text = "60";
            this.buttonSet60.UseVisualStyleBackColor = false;
            this.buttonSet60.Click += new System.EventHandler(this.ButtonPalletSizeSet60_Click);
            // 
            // buttonSet120
            // 
            this.buttonSet120.BackColor = System.Drawing.Color.Transparent;
            this.buttonSet120.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSet120.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSet120.Location = new System.Drawing.Point(736, 276);
            this.buttonSet120.Name = "buttonSet120";
            this.buttonSet120.Size = new System.Drawing.Size(138, 82);
            this.buttonSet120.TabIndex = 21;
            this.buttonSet120.Text = "120";
            this.buttonSet120.UseVisualStyleBackColor = false;
            this.buttonSet120.Click += new System.EventHandler(this.ButtonPalletSizeSet120_Click);
            // 
            // buttonSet1
            // 
            this.buttonSet1.BackColor = System.Drawing.Color.Transparent;
            this.buttonSet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSet1.Location = new System.Drawing.Point(304, 276);
            this.buttonSet1.Name = "buttonSet1";
            this.buttonSet1.Size = new System.Drawing.Size(138, 82);
            this.buttonSet1.TabIndex = 22;
            this.buttonSet1.Text = "1";
            this.buttonSet1.UseVisualStyleBackColor = false;
            this.buttonSet1.Click += new System.EventHandler(this.ButtonPalletSizeSet1_Click);
            // 
            // layoutPanel
            // 
            this.layoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.layoutPanel.ColumnCount = 7;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.layoutPanel.Controls.Add(this.buttonPalletSizeNext, 4, 3);
            this.layoutPanel.Controls.Add(this.buttonPalletSizePrev, 3, 3);
            this.layoutPanel.Controls.Add(this.buttonPalletSize10, 5, 3);
            this.layoutPanel.Controls.Add(this.fieldPalletSize, 2, 3);
            this.layoutPanel.Controls.Add(this.labelPalletSize, 1, 3);
            this.layoutPanel.Controls.Add(this.buttonDtRight, 4, 1);
            this.layoutPanel.Controls.Add(this.buttonDtLeft, 3, 1);
            this.layoutPanel.Controls.Add(this.buttonKneading, 3, 2);
            this.layoutPanel.Controls.Add(this.fieldKneading, 2, 2);
            this.layoutPanel.Controls.Add(this.labelKneading, 1, 2);
            this.layoutPanel.Controls.Add(this.labelProdDate, 1, 1);
            this.layoutPanel.Controls.Add(this.fieldProdDate, 2, 1);
            this.layoutPanel.Controls.Add(this.buttonSet40, 3, 4);
            this.layoutPanel.Controls.Add(this.buttonSet60, 4, 4);
            this.layoutPanel.Controls.Add(this.buttonSet120, 5, 4);
            this.layoutPanel.Controls.Add(this.buttonSet1, 2, 4);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 6;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.75F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.75F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.75F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.75F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanel.Size = new System.Drawing.Size(900, 371);
            this.layoutPanel.TabIndex = 7;
            // 
            // flowLayoutPanelBottom
            // 
            this.flowLayoutPanelBottom.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelBottom.Controls.Add(this.buttonCancel);
            this.flowLayoutPanelBottom.Controls.Add(this.buttonOk);
            this.flowLayoutPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelBottom.Location = new System.Drawing.Point(0, 371);
            this.flowLayoutPanelBottom.Name = "flowLayoutPanelBottom";
            this.flowLayoutPanelBottom.Size = new System.Drawing.Size(900, 129);
            this.flowLayoutPanelBottom.TabIndex = 8;
            // 
            // KneadingUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.layoutPanel);
            this.Controls.Add(this.flowLayoutPanelBottom);
            this.Name = "KneadingUserControl";
            this.Size = new System.Drawing.Size(900, 500);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KneadingUserControl_KeyUp);
            this.layoutPanel.ResumeLayout(false);
            this.layoutPanel.PerformLayout();
            this.flowLayoutPanelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private Button buttonCancel;
    private Button buttonOk;
    private Button buttonPalletSizeNext;
    private Button buttonPalletSizePrev;
    private Button buttonPalletSize10;
    private Label fieldPalletSize;
    private Label labelPalletSize;
    private Button buttonDtRight;
    private Button buttonDtLeft;
    private Button buttonKneading;
    private Label fieldKneading;
    private Label labelKneading;
    private Label labelProdDate;
    private Label fieldProdDate;
    private Button buttonSet40;
    private Button buttonSet60;
    private Button buttonSet120;
    private Button buttonSet1;
    private TableLayoutPanel layoutPanel;
    private FlowLayoutPanel flowLayoutPanelBottom;
}