﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Fields;
using DataCore.Sql.QueriesModels;

namespace BlazorDeviceControl.Razors.Items;

public partial class ItemPluScale : BlazorCore.Models.RazorBase
{
    #region Public and private fields, properties, constructor

    private BarcodeHelper Barcode { get; } = BarcodeHelper.Instance;
    private List<NomenclatureEntity> Nomenclatures { get; set; }
    private List<TemplateEntity> Templates { get; set; }
	private List<ScaleEntity> Scales { get; set; }
	private List<PluEntity> Plus { get; set; }
    private PluScaleEntity ItemCast { get => Item == null ? new() : (PluScaleEntity)Item; set => Item = value; }

    #endregion

    #region Public and private methods

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Table = new TableScaleEntity(ProjectsEnums.TableScale.PlusScales);
        ItemCast = new();
        Templates = new();
        Nomenclatures = new();
        Scales = new();
        Plus = new();
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        RunActions(new()
        {
            () =>
            {
                switch (TableAction)
                {
                    case DbTableAction.New:
                        ItemCast = new();
                        ItemCast.ChangeDt = ItemCast.CreateDt = DateTime.Now;
                        ItemCast.IsMarked = false;
                        break;
                    default:
                        ItemCast = AppSettings.DataAccess.Crud.GetItemByUidNotNull<PluScaleEntity>(IdentityUid);
                        break;
                }

	            // Templates.
	            Templates = new() { new(0, false) { Title = LocaleCore.Table.FieldNull } };
                TemplateEntity[]? templates = AppSettings.DataAccess.Crud.GetItems<TemplateEntity>(
                    new FieldFilterModel(DbField.IsMarked, false), new(DbField.Title));
                if (templates is not null)
	                Templates.AddRange(templates);

	            // Nomenclatures.
	            Nomenclatures = new() { new(0, false) { Name = LocaleCore.Table.FieldNull } };
                NomenclatureEntity[]? nomenclatures = AppSettings.DataAccess.Crud.GetItems<NomenclatureEntity>(
                    new FieldFilterModel(DbField.IsMarked, false), new(DbField.Name));
                if (nomenclatures is not null)
	                Nomenclatures.AddRange(nomenclatures);

	            // Scales.
	            Scales = new() { new(0, false) { Description = LocaleCore.Table.FieldNull } };
                ScaleEntity[]? scales = AppSettings.DataAccess.Crud.GetItems<ScaleEntity>(
                    new FieldFilterModel(DbField.IsMarked, false), new(DbField.Description));
                if (scales is not null)
	                Scales.AddRange(scales);

	            // Plus.
	            Plus = new() { new(Guid.Empty, false) { Description = LocaleCore.Table.FieldNull } };
	            PluEntity[]? plus = AppSettings.DataAccess.Crud.GetItems<PluEntity>(
		            new FieldFilterModel(DbField.IsMarked, false), new (DbField.Name));
                if (plus is not null)
					Plus.AddRange(plus);

	            //// Проверка шаблона.
	            //if ((PluItem.Templates == null || PluItem.Templates.EqualsDefault()) && PluItem.Scale.TemplateDefault != null)
	            //{
	            //    PluItem.Templates = PluItem.Scale.TemplateDefault.CloneCast();
	            //}
	            //// Номер PLU.
	            //if (PluItem.Plu == 0)
	            //{
	            //    PluV2Entity pluEntity = AppSettings.DataAccess.PlusCrud.GetItem(
	            //        new FieldListEntity(new Dictionary<string, object,> { { $"Scale.{DbField.IdentityId}", PluItem.Scale.IdentityId } }),
	            //        new FieldOrderEntity { Direction = DbOrderDirection.Desc, Name = DbField.Plu, Use = true });
	            //    if (pluEntity != null && !pluEntity.EqualsDefault())
	            //    {
	            //        PluItem.Plu = pluEntity.Plu + 1;
	            //    }

	            ButtonSettings = new(false, false, false, false, false, true, true);
            }
        });
    }

    #endregion
}
