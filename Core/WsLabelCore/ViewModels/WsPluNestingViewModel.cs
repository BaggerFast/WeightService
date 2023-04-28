// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsLabelCore.ViewModels;

public sealed class WsPluNestingViewModel : WsSqlBaseViewModel
{
    #region Public and private fields, properties, constructor

    private WsSqlContextPluNestingHelper Helper => WsSqlContextPluNestingHelper.Instance;
    
    private PluNestingFkModel _item;
    public PluNestingFkModel Item
    {
        get => _item;
        set
        {
            _item = value;
            OnPropertyChanged();
        }
    }
    
    private List<PluNestingFkModel> _list;
    public List<PluNestingFkModel> List
    {
        get => _list;
        private set
        {
            _list = value;
            OnPropertyChanged();
        }
    }

    public WsPluNestingViewModel()
    {
        _item = new();
        _list = new();
        SetNewItem();
        SetNewList();
    }

    #endregion

    #region Public and private methods

    public void SetNewItem()
    {
        Item = Helper.GetNewItem();
    }

    public void SetItemFromList()
    {
        if (!List.Any())
            SetNewItem();
        else
            Item = List.Exists(x => !x.IsNew && x.IsDefault)
                ? List.Find(x => !x.IsNew && x.IsDefault)
                : List.First();
    }

    public void SetNewList()
    {
        List = new() { Item };
    }

    public void SetList(PluModel plu)
    {
        // For not exists item.
        if (plu.IsNew)
            SetNewList();
        // For exists item.
        else
        {
            SqlCrudConfigModel sqlCrudConfig = new(WsSqlQueriesScales.Tables.PluNestingFks.GetList(true), 
                new("P_UID", plu.IdentityValueUid), true);
            List = ContextManager.ContextList.GetListNotNullablePlusNestingFks(sqlCrudConfig);
            SetItemFromList();
        }
    }

    /// <summary>
    /// Проверить наличие вложенности ПЛУ.
    /// </summary>
    /// <param name="plu"></param>
    /// <param name="fieldWarning"></param>
    /// <returns></returns>
    public bool SetAndCheckList(PluModel plu, Label fieldWarning)
    {
        SetList(plu);
        if (Item.IsNew && List.Any())
        {
            MdInvokeControl.SetVisible(fieldWarning, true);
            MdInvokeControl.SetText(fieldWarning, LocaleCore.Scales.PluPackageNotSelect);
            ContextManager.ContextItem.SaveLogError(LocaleCore.Scales.PluPackageNotSelect);
            return false;
        }
        return true;
    }

    #endregion
}