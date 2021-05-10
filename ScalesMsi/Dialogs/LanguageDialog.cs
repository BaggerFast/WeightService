// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using ScalesMsi.Helpers;
using ScalesMsi.Utils;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WixSharp;
using WixSharp.UI.Forms;

namespace ScalesMsi.Dialogs
{
    /// <summary>
    /// Language dialog
    /// </summary>
    public partial class LanguageDialog : ManagedForm
    {
        #region Private helpers

        /// <summary>
        /// �������� ����������.
        /// </summary>
        private readonly AppHelper _app = AppHelper.Instance;

        #endregion

        #region Dialog methods

        public LanguageDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �����������.
        /// </summary>
        private void Localization()
        {
            // Language.
            Text = _app.CurrentLocalization == EnumLocalization.English ? @"Setup localization" : @"��������� �����������";
            groupBoxLanguage.Text = @"[MaintenanceLocalizationDlgLanguage]";

            // ID.
            groupBoxId.Text = @"[MaintenanceLocalizationDlgId]";
            buttonIdPaste.Text = @"[MaintenanceLocalizationDlgIdPasteFromBuffer]";
            buttonIdCheckInSql.Text = @"[MaintenanceLocalizationDlgIdCheckInSql]";
            buttonIdRegistryLoad.Text = @"[MaintenanceLocalizationDlgLoadDefault]";

            // SQL.
            groupBoxSql.Text = @"[MaintenanceLocalizationDlgSqlConStr]";
            labelSqlServer.Text = @"[MaintenanceLocalizationDlgSqlServer]";
            labelSqlDb.Text = @"[MaintenanceLocalizationDlgSqlDb]";
            labelSqlUser.Text = @"[MaintenanceLocalizationDlgSqlUser]";
            labelSqlPassword.Text = @"[MaintenanceLocalizationDlgSqlPassword]";
            buttonSqlConfigLoad.Text = @"[MaintenanceLocalizationDlgLoadDefault]";
            buttonSqlCheckConnect.Text = @"[MaintenanceLocalizationDlgSqlCheckConnect]";
            fieldSqlIntegratedSecurity.Text = @"[MaintenanceLocalizationDlgSqlIntegratedSecurity]";

            // ������.
            buttonRunAs.Text = @"[WixUIRunAs]";
            next.Text = @"[WixUINext]";
            cancel.Text = @"[WixUICancel]";

            // ���������� ����� �������.
            fieldElevatedAccess.Text = @"[MaintenanceLocalizationDlgElevatedRequired]";

            Localize();
        }

        /// <summary>
        /// �������� �������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LanguageDialog_Load(object sender, EventArgs e)
        {
            ResetLayout();

            // �����������.
            fieldLanguage_SelectedIndexChanged(sender, e);

            // ���������� ����� �������.
            var isAccess = false;
            try
            {
                isAccess = UACHelper.UACHelper.IsProcessElevated(Process.GetCurrentProcess());
            }
            catch (Exception)
            {
                //
            }
            if (!isAccess)
            {
                fieldElevatedAccess.Visible = true;
                groupBoxSql.Enabled = false;
                groupBoxId.Enabled = false;
                next.Enabled = false;
                buttonRunAs.Visible = true;
            }

            // ��������� ��������� SQL-����������� �� �������.
            buttonSqlLoadConfig_Click(sender, e);
            // ��������� SQL-�����������.
            _app.SqlConCheck(_app.CurrentLocalization);

            // SQL.
            fieldSqlIntegratedSecurity_CheckedChanged(sender, e);
            SqlCheckConnectAsync();

            // ID.
            buttonIdReading_Click(sender, e);
            fieldId.TextChanged += fieldId_TextChanged;
            SqlCheckId(EnumSilentUI.True);

            // ���������� ��� �������.
            if (!isAccess)
            {
                buttonRunAs_Click(sender, e);
            }
        }

        private void ResetLayout()
        {
            fieldLanguage.Items.Add("English");
            fieldLanguage.Items.Add("Russian");
            fieldLanguage.SelectedIndex = (int)_app.CurrentLocalization;
            fieldLanguage.SelectedIndexChanged += fieldLanguage_SelectedIndexChanged;
            fieldLanguage.KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                    cancel_Click(s, e);
                if (e.KeyCode == Keys.Enter)
                {
                    next_Click(s, e);
                }
            };

            var bHeight = (int)(next.Height * 2.3);
            var upShift = bHeight - bottomPanel.Height;
            bottomPanel.Top -= upShift;
            bottomPanel.Height = bHeight;
        }

        #endregion

        #region Private methods - Localization

        /// <summary>
        /// ���������� ���� ����� �����������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fieldLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            _app.CurrentLocalization = (EnumLocalization)fieldLanguage.SelectedIndex;
            var runtime = ((IManagedDialog)this).Shell.MsiRuntime();
            switch (_app.CurrentLocalization)
            {
                case EnumLocalization.Russian:
                    runtime.UIText.InitFromWxl(_app.Wix.Args.Session.ReadBinary("ru_xsl"));
                    break;
                default:
                    runtime.UIText.InitFromWxl(_app.Wix.Args.Session.ReadBinary("en_xsl"));
                    break;
            }

            Localization();
        }

        #endregion

        #region Private methods - SQL

        /// <summary>
        /// ��������� � ��������� ��������� SQL-�����������.
        /// </summary>
        private void SqlLoadGui()
        {
            fieldSqlServer.TextChanged -= fieldSql_TextChanged;
            fieldSqlDb.TextChanged -= fieldSql_TextChanged;
            fieldSqlUser.TextChanged -= fieldSql_TextChanged;
            fieldSqlPassword.TextChanged -= fieldSql_TextChanged;
            fieldSqlIntegratedSecurity.CheckedChanged -= fieldSqlIntegratedSecurity_CheckedChanged;

            fieldSqlServer.Text = _app.Sql.Authentication.Server;
            fieldSqlDb.Text = _app.Sql.Authentication.Database;
            fieldSqlUser.Text = _app.Sql.Authentication.UserId;
            fieldSqlPassword.Text = _app.Sql.Authentication.Password;
            fieldSqlIntegratedSecurity.Checked = _app.Sql.Authentication.IntegratedSecurity;

            fieldSqlServer.TextChanged += fieldSql_TextChanged;
            fieldSqlDb.TextChanged += fieldSql_TextChanged;
            fieldSqlUser.TextChanged += fieldSql_TextChanged;
            fieldSqlPassword.TextChanged += fieldSql_TextChanged;
            fieldSqlIntegratedSecurity.CheckedChanged += fieldSqlIntegratedSecurity_CheckedChanged;
        }

        /// <summary>
        /// ��������� ��������� SQL-����������� �� �������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSqlLoadConfig_Click(object sender, EventArgs e)
        {
            _app.Sql.Open(EnumSettingsStorage.UseConfig);
            // ��������� � ��������� ��������� SQL-�����������.
            SqlLoadGui();
        }

        /// <summary>
        /// ���������� ���� SQL.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fieldSql_TextChanged(object sender, EventArgs e)
        {
            _app.Sql.Authentication.Server = fieldSqlServer.Text;
            _app.Sql.Authentication.Database = fieldSqlDb.Text;
            _app.Sql.Authentication.UserId = fieldSqlUser.Text;
            _app.Sql.Authentication.Password = fieldSqlPassword.Text;
            _app.Sql.Authentication.IntegratedSecurity = fieldSqlIntegratedSecurity.Checked;

            fieldConnectionString.Text = _app.Sql.Authentication.AsString(EnumConStringLevel.Middle);
        }

        /// <summary>
        /// ��������� SQL-�����������.
        /// </summary>
        private void SqlCheckConnectAsync()
        {
            fieldConnectionString.BackColor = Color.Yellow;
            groupBoxSql.Enabled = false;
            next.Enabled = false;
            groupBoxId.Enabled = false;
            // ��������� SQL-�����������.
            if (_app.SqlConCheck(_app.CurrentLocalization))
            {
                fieldConnectionString.BackColor = SystemColors.Window;
                groupBoxId.Enabled = true;
                next.Enabled = true;
            }
            groupBoxSql.Enabled = true;
        }

        /// <summary>
        /// ��������� ����������� � �������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSqlCheckConnect_Click(object sender, EventArgs e)
        {
            SqlCheckConnectAsync();
        }

        /// <summary>
        /// �������������� Windows.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fieldSqlIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox field)
            {
                labelSqlUser.Enabled = fieldSqlUser.Enabled =
                    labelSqlPassword.Enabled = fieldSqlPassword.Enabled = !field.Checked;
            }
            fieldSql_TextChanged(sender, e);
        }

        #endregion

        #region Private methods - ID

        /// <summary>
        /// ��������� ��������� ID.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fieldIdFromDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fieldIdFromDb.Items.Count > 0)
            {
                fieldId.Text = fieldIdFromDb.Items[fieldIdFromDb.SelectedIndex].ToString();
            }
        }
        
        /// <summary>
        /// ���������� ���� ID.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fieldId_TextChanged(object sender, EventArgs e)
        {
            _app.SetupDefault();
            _app.IdSetValue(fieldId.Text);
        }

        /// <summary>
        /// ��������� ID � ������� ��.
        /// </summary>
        /// <param name="silent"></param>
        private void SqlCheckId(EnumSilentUI silent)
        {
            fieldId.BackColor = Color.Yellow;
            groupBoxSql.Enabled = false;
            groupBoxId.Enabled = false;
            next.Enabled = false;
            // ��������� ������� ID.
            var allow = _app.SqlExistsId(fieldId.Text);
            if (allow && silent == EnumSilentUI.False)
            {
                MessageBox.Show(_app.CurrentLocalization == EnumLocalization.English
                    ? @"ID is found."
                    : "������������� ������� ���������.");
            }

            if (!allow)
            {
                if (silent == EnumSilentUI.False)
                {
                    MessageBox.Show(_app.CurrentLocalization == EnumLocalization.English
                        ? @"GUID not found!"
                        : "������������� �� ���������!");
                    //var question = _app.CurrentLocalization == EnumLocalization.English
                    //    ? "Unlock for admin?"
                    //    : "�������������� ��� ��������������?";
                    //allow = MessageBox.Show(question, _app.Wix.Args.ProductName, MessageBoxButtons.YesNo,
                    //    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
                }
            }

            if (allow)
            {
                fieldId.BackColor = SystemColors.Window;
                next.Enabled = true;
            }

            groupBoxSql.Enabled = true;
            groupBoxId.Enabled = true;
        }

        /// <summary>
        /// �������� ������ ID � ������� ��.
        /// </summary>
        private void SqlGetIds()
        {
            fieldIdFromDb.Items.Clear();
            fieldIdFromDb.Items.AddRange(_app.SqlGetIds());
            if (fieldIdFromDb.Items.Count > 0)
                fieldIdFromDb.SelectedIndex = 0;
            fieldIdFromDb_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// ��������� ID �� ��������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonIdReading_Click(object sender, EventArgs e)
        {
            //fieldId.Text = Properties.Settings.Default.Id;
            // �������� ������ ID � ������� ��.
            SqlGetIds();
        }

        /// <summary>
        /// �������� �� ������ ������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonIdPaste_Click(object sender, EventArgs e)
        {
            fieldId.Text = Clipboard.GetText();
        }

        /// <summary>
        /// ��������� ID � ������� ��.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonIdCheckInSql_Click(object sender, EventArgs e)
        {
            SqlCheckId(EnumSilentUI.False);
        }

        #endregion

        #region Private methods - ����������

        /// <summary>
        /// ��������� ���������.
        /// </summary>
        private void SaveSettings()
        {
            Properties.Settings.Default.Id = fieldId.Text;
            Properties.Settings.Default.ConnectionString = fieldConnectionString.Text;
        }

        /// <summary>
        /// ������ �����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void next_Click(object sender, EventArgs e)
        {
            // ���������� ���� ����� �����������.
            fieldLanguage_SelectedIndexChanged(sender, e);
            // ���������� ���� ID.
            fieldId_TextChanged(sender, e);
            // ���������� ���� SQL.
            fieldSql_TextChanged(sender, e);

            // ID.
            if (!_app.IdExists())
            {
                var message = _app.CurrentLocalization == EnumLocalization.English ? @"Fill ID!" : @"��������� ���� ��������������!";
                MessageBox.Show(message, _app.GetDescription(System.Reflection.Assembly.GetExecutingAssembly()));
                fieldId.Select();
                return;
            }
            // ��������� ��������� ID � �������.
            //_app.GuidRegSave();

            // SQL.
            if (!_app.Sql.Authentication.Exists())
            {
                var message = _app.CurrentLocalization == EnumLocalization.English ? @"Fill SQL-fields!" : @"��������� SQL-����!";
                MessageBox.Show(message, _app.GetDescription(System.Reflection.Assembly.GetExecutingAssembly()));
                fieldId.Select();
                return;
            }
            // ������� SQL-�����������.
            _app.Sql.CloseConnection(_app.CurrentLocalization);

            // ��������� ���������.
            SaveSettings();

            Shell.GoNext();
        }

        /// <summary>
        /// ������ �����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {
            Shell.Cancel();
        }

        /// <summary>
        /// ������ RunAs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRunAs_Click(object sender, EventArgs e)
        {
            var taskMsi = _app.Proc.RunMsiAsync("ScalesUI");
            taskMsi.Wait();

            Shell.Exit();
        }

        #endregion
    }
}