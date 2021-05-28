﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using ScalesUI.Common;
using ScalesUI.Utils;
using System;
using System.Windows.Forms;
using UICommon;

namespace ScalesUI.Forms
{
    public partial class SetKneadingNumberForm : Form
    {
        #region Private fields and properties

        // Состояние устройства.
        private readonly SessionState _ws = SessionState.Instance;
        private int OldKneading { get; }
        private int OldPalletSize { get; }
        private DateTime OldProductDate { get; }

        #endregion

        #region Constructor and destructor

        public SetKneadingNumberForm()
        {
            InitializeComponent();

            // WindowState = FormWindowState.Maximized;

            OldKneading = _ws.Kneading;
            OldProductDate = _ws.ProductDate;
            OldPalletSize = _ws.PalletSize;

        }

        #endregion

        #region Public and private methods

        private void SetKneadingNumberForm_Load(object sender, EventArgs e)
        {
            TopMost = !_ws.IsDebug;
            Width = Owner.Width;
            Height = Owner.Height;
            Left = Owner.Left;
            Top = Owner.Top;

            StartPosition = FormStartPosition.CenterScreen;
            ShowPalletSize();
        }

        private void ShowProductDate()
        {
            lbProdDate.Text = _ws.ProductDate.ToString("dd.MM.yyyy");
        }

        private void ShowKneading()
        {
            lKneadingValue.Text = _ws.Kneading.ToString();
        }

        private void buttonKneadingLeft_Click(object sender, EventArgs e)
        {
            //_ws.RotateKneading(Direction.back);

            var numberInputForm = new NumberInputForm();
            numberInputForm.InputValue = 0;// _ws.Kneading;
            if (numberInputForm.ShowDialog() == DialogResult.OK)
            {
                _ws.Kneading = numberInputForm.InputValue;
            }
            ShowKneading();

        }

        private void SetKneadingNumberForm_Shown(object sender, EventArgs e)
        {
            ShowKneading();
            ShowProductDate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            _ws.Kneading = OldKneading;
            _ws.ProductDate = OldProductDate;
            _ws.PalletSize = OldPalletSize;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();

        }

        private void buttonDtRight_Click(object sender, EventArgs e)
        {
            _ws.RotateProductDate(Direction.Forward);
            ShowProductDate();
        }

        private void buttonDtLeft_Click(object sender, EventArgs e)
        {
            _ws.RotateProductDate(Direction.Back);
            ShowProductDate();
        }

        private void btnPalletSize10_Click(object sender, EventArgs e)
        {
            int n = _ws.PalletSize == 1 ? 9 : 10;

            for (int i = 0; i < n; i++)
            {
                _ws.RotatePalletSize(Direction.Forward);
                ShowPalletSize();
            }

        }

        private void ShowPalletSize()
        {
            labelPalletSize.Text = _ws.PalletSize.ToString();
        }

        private void btnPalletSizeNext_Click(object sender, EventArgs e)
        {
            _ws.RotatePalletSize(Direction.Forward);
            ShowPalletSize();
        }

        private void btnPalletSizePrev_Click(object sender, EventArgs e)
        {
            _ws.RotatePalletSize(Direction.Back);
            ShowPalletSize();

        }

        private void btSet40_Click(object sender, EventArgs e)
        {
            _ws.PalletSize = 40;
            ShowPalletSize();
        }

        private void btSet60_Click(object sender, EventArgs e)
        {
            _ws.PalletSize = 60;
            ShowPalletSize();

        }

        private void btSet120_Click(object sender, EventArgs e)
        {
            _ws.PalletSize = 120;
            ShowPalletSize();

        }

        private void btSet1_Click(object sender, EventArgs e)
        {
            _ws.PalletSize = 1;
            ShowPalletSize();
        }

        #endregion
    }
}