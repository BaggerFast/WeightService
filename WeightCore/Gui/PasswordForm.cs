﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WeightCore.Gui
{
    public partial class PasswordForm : Form
    {
        #region Private fields and properties

        private int UnlockPinCode { get => DateTime.Now.Hour * 100 + DateTime.Now.Minute; }
        private int UserPinCode { get; set; }
        private bool CheckPin { get => UserPinCode == UnlockPinCode; }

        #endregion

        #region Constructor and destructor

        public PasswordForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Форма загружена.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordForm_Load(object sender, EventArgs e)
        {
            ShowPin();
        }

        private void PasswordForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                case Keys.D0:
                    btnNum_Click(btnNum0, e);
                    break;
                case Keys.NumPad1:
                case Keys.D1:
                    btnNum_Click(btnNum1, e);
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    btnNum_Click(btnNum2, e);
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    btnNum_Click(btnNum3, e);
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    btnNum_Click(btnNum4, e);
                    break;
                case Keys.NumPad5:
                case Keys.D5:
                    btnNum_Click(btnNum5, e);
                    break;
                case Keys.NumPad6:
                case Keys.D6:
                    btnNum_Click(btnNum6, e);
                    break;
                case Keys.NumPad7:
                case Keys.D7:
                    btnNum_Click(btnNum7, e);
                    break;
                case Keys.NumPad8:
                case Keys.D8:
                    btnNum_Click(btnNum8, e);
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    btnNum_Click(btnNum9, e);
                    break;
                case Keys.Escape:
                case Keys.Enter:
                    btnClose_Click(sender, e);
                    break;
            }
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            var num = (string)(sender as Control)?.Tag;
            UserPinCode = int.Parse(UserPinCode + num);
            if (CheckPin)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            if (UserPinCode.ToString().Length > 3)
            {
                UserPinCode = 0;
            }
            ShowPin();
        }

        private void ShowPin()
        {
            if (UserPinCode == 0)
            {
                lbPIn.Text = "....";
                return;
            }

            string x = string.Empty;
            string y = string.Empty;

            x = UserPinCode.ToString();
            y = Regex.Replace(x, "[0-9]", "*");
            lbPIn.Text = y;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            UserPinCode = 0;
            ShowPin();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = CheckPin ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}