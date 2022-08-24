﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableDirectModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataCore.Sql.TableScaleModels;
using WeightCore.Gui;
using WeightCore.Helpers;

namespace ScalesUI.Forms
{
    public partial class OrderListForm : Form
    {
        #region Public and private fields and properties

        //private DebugHelper Debug { get; } = DebugHelper.Instance;
        //private int NumPage { get; set; }
        //private static int Offset => 9;
        //private List<OrderEntity> OrdList { get; set; }
        //private UserSessionHelper UserSession { get; } = UserSessionHelper.Instance;

        #endregion

        #region Constructor and destructor

        public OrderListForm()
        {
            InitializeComponent();
        }

        #endregion

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    TopMost = !Debug.IsDebug;

            //    OrdList = new OrderEntity().GetOrderList(UserSession.SqlViewModel.Scale);
            //    if (OrdList.Count < Offset)
            //    {
            //        btnLeftRoll.Visible = false;
            //        btnRightRoll.Visible = false;
            //    }

            //    tableLayoutPanel1.ColumnStyles.Clear();
            //    tableLayoutPanel1.RowStyles.Clear();

            //    tableLayoutPanel1.ColumnCount = 3;
            //    //tableLayoutPanel1.RowCount = 1 + (ordList.Count / tableLayoutPanel1.ColumnCount);
            //    tableLayoutPanel1.RowCount = 1;

            //    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            //    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            //    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            //    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120));

            //    //tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;

            //    //int i = 0;
            //    //foreach (OrderEntity order in ordList)
            //    //{
            //    //    tableLayoutPanel1.Size = new System.Drawing.Size(200, tableLayoutPanel1.Size.Height + 100);
            //    //    if (i % tableLayoutPanel1.ColumnCount == 0)
            //    //    {
            //    //        tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
            //    //        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120));
            //    //    }
            //    GetPage(tableLayoutPanel1, NumPage, Offset);
            //    Refresh();
            //}
            //catch (Exception ex)
            //{
            //    GuiUtils.WpfForm.CatchException(this, ex);
            //}
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DialogResult = DialogResult.Cancel;
            //    Close();
            //}
            //catch (Exception ex)
            //{
            //    GuiUtils.WpfForm.CatchException(this, ex);
            //}
        }

        private void AddRow(int i)
        {
            //try
            //{
            //    if (i % tableLayoutPanel1.ColumnCount == 0)
            //    {
            //        tableLayoutPanel1.RowCount++;
            //        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    GuiUtils.WpfForm.CatchException(this, ex);
            //}
        }

        private void NewButton(TableLayoutPanel panel, int offset, int i, OrderEntity order)
        {
            //try
            //{
            //    Button btn = new()
            //    {
            //        Font = new Font("Arial", 16, FontStyle.Bold),
            //        Text = order.ToString(),
            //        Name = "btn_" + i,
            //        TabIndex = i + offset,
            //        Dock = DockStyle.Fill,
            //        Size = new Size(120, 30),
            //        Visible = true,
            //        Parent = tableLayoutPanel1,
            //        FlatStyle = FlatStyle.Flat,
            //        Location = new Point(0, 0),
            //        UseVisualStyleBackColor = true
            //    };
            //    //the names are changed!
            //    btn.Click += delegate
            //    {
            //        UserSession.SqlViewModel.Order = OrdList[btn.TabIndex];
            //        if (UserSession.SqlViewModel.Order != null)
            //        {
            //            UserSession.SqlViewModel.Order.LoadTemplate();
            //            UserSession.SetCurrentPlu(UserSession.SqlViewModel.Order.PLU);
            //        }
            //        //ws.CurrentPLU.LoadTemplate();
            //        //_sessionState.WeightTare = (int)( _sessionState.CurrentOrder.PLU.GoodsTareWeight * _sessionState.CurrentPLU.);
            //        //_sessionState.WeightReal = 0;
            //        DialogResult = DialogResult.OK;
            //        Close();
            //    };
            //    panel.Controls.Add(btn, i % tableLayoutPanel1.ColumnCount, i / tableLayoutPanel1.ColumnCount);
            //}
            //catch (Exception ex)
            //{
            //    GuiUtils.WpfForm.CatchException(this, ex);
            //}
        }

        private void DropButtons(TableLayoutPanel panel)
        {
            //try
            //{
            //    panel.Controls.Clear();
            //}
            //catch (Exception ex)
            //{
            //    GuiUtils.WpfForm.CatchException(this, ex);
            //}
        }

        private void GetPage(TableLayoutPanel panel, int offset = 0, int rowCount = 10)
        {
            //try
            //{
            //    DropButtons(panel);
            //    int i = 0;

            //    List<OrderEntity> page = OrdList.GetRange(offset * rowCount,
            //        ((offset * rowCount + rowCount) < OrdList.Count) ? rowCount : (OrdList.Count - offset * rowCount));

            //    if (!page.Any())
            //    {
            //        page = OrdList.GetRange(offset * (--rowCount),
            //        ((offset * rowCount + rowCount) < OrdList.Count) ? rowCount : (OrdList.Count - offset * rowCount));
            //    }

            //    foreach (OrderEntity order in page)
            //    {
            //        panel.Size = new Size(200, tableLayoutPanel1.Size.Height + 100);
            //        AddRow(i);
            //        NewButton(panel, offset, i, order);
            //        i++;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    GuiUtils.WpfForm.CatchException(this, ex);
            //}
        }

        private void BtnRightRoll_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (NumPage < (OrdList.Count / Offset)) NumPage++;
            //    else NumPage = OrdList.Count / Offset;
            //    GetPage(tableLayoutPanel1, NumPage, Offset);
            //}
            //catch (Exception ex)
            //{
            //    GuiUtils.WpfForm.CatchException(this, ex);
            //}
        }

        private void BtnLeftRoll_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (NumPage > 0) NumPage--; else NumPage = 0;
            //    GetPage(tableLayoutPanel1, NumPage, Offset);
            //}
            //catch (Exception ex)
            //{
            //    GuiUtils.WpfForm.CatchException(this, ex);
            //}
        }
    }
}
