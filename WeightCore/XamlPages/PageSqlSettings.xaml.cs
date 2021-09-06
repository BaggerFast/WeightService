﻿using DataProjectsCore.DAL;
using DataProjectsCore.DAL.TableModels;
using DataProjectsCore.DAL.Utils;
using System.Windows.Forms;
using WeightCore.Models;

namespace WeightCore.XamlPages
{
    /// <summary>
    /// Interaction logic for PageSqlSettings.xaml
    /// </summary>
    public partial class PageSqlSettings : System.Windows.Controls.UserControl
    {
        #region Private fields and properties

        public SessionState _ws { get; private set; } = SessionState.Instance;
        public SqlViewModel ViewModel { get; set; }
        public int RowCount { get; } = 5;
        public int ColumnCount { get; } = 4;
        public int PageSize { get; } = 20;
        public DialogResult Result { get; private set; }

        #endregion

        #region Constructor and destructor

        public PageSqlSettings()
        {
            InitializeComponent();

            //var context = FindResource("ViewModelSqlHelper");
            //if (context is SqlHelper sqlHelper)
            //{
            //    _ws.SqlItem = sqlHelper;
            //}
            ViewModel = _ws.SqlItem;
        }

        #endregion

        #region Public and private methods

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _ws.SqlItem.SetupTasks(_ws.Host?.CurrentScaleId);

            System.Windows.Controls.Grid gridTasks = new();
            // Columns.
            for (int col = 0; col < 2; col++)
            {
                System.Windows.Controls.ColumnDefinition column = new()
                {
                    Width = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star)
                };
                gridTasks.ColumnDefinitions.Add(column);
            }
            // Rows.
            for (int row = 0; row < _ws.SqlItem.Tasks.Count; row++)
            {
                // Row.
                System.Windows.Controls.RowDefinition rows = new()
                {
                    Height = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star)
                };
                gridTasks.RowDefinitions.Add(rows);
                // Task caption.
                System.Windows.Controls.Label labelTaskCaption = new()
                {
                    Content = _ws.SqlItem.Tasks[row].TaskType.Name,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                };
                System.Windows.Controls.Grid.SetColumn(labelTaskCaption, 0);
                System.Windows.Controls.Grid.SetRow(labelTaskCaption, row);
                gridTasks.Children.Add(labelTaskCaption);
                // Task enabled.
                System.Windows.Controls.ComboBox comboBoxTaskEnabled = new()
                {
                    Width = 100,
                    Height = 30,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
                    Tag = _ws.SqlItem.Tasks[row]
                };
                System.Windows.Controls.ComboBoxItem itemTrue = new() { Content = "True" };
                comboBoxTaskEnabled.Items.Add(itemTrue);
                System.Windows.Controls.ComboBoxItem itemFalse = new() { Content = "False" };
                comboBoxTaskEnabled.Items.Add(itemFalse);
                comboBoxTaskEnabled.SelectedItem = _ws.SqlItem.Tasks[row].Enabled ? itemTrue : itemFalse;
                System.Windows.Controls.Grid.SetColumn(comboBoxTaskEnabled, 1);
                System.Windows.Controls.Grid.SetRow(comboBoxTaskEnabled, row);
                gridTasks.Children.Add(comboBoxTaskEnabled);
            }
            // Fill tab.
            tabTasks.Content = gridTasks;
        }

        public void ButtonOk_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tabTasks.Content is System.Windows.Controls.Grid gridTasks)
            {
                foreach (object item in gridTasks.Children)
                {
                    if (item is System.Windows.Controls.ComboBox comboBoxTaskEnabled)
                    {
                        if (comboBoxTaskEnabled.Tag is TaskDirect taskItem)
                        {
                            if (comboBoxTaskEnabled.SelectedItem is System.Windows.Controls.ComboBoxItem itemSelected)
                            {
                                TasksUtils.SaveTask(taskItem, taskItem.TaskType, taskItem.Scale.Id,
                                    string.Equals(itemSelected.Content.ToString(), "True", System.StringComparison.InvariantCultureIgnoreCase));
                            }
                        }
                    }
                }
            }

            Result = DialogResult.OK;
            _ws.IsWpfPageLoaderClose = true;
        }

        public void ButtonClose_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Result = DialogResult.Cancel;
            _ws.IsWpfPageLoaderClose = true;
        }

        #endregion
    }
}