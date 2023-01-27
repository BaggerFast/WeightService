﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsWebApi.Helpers;

public partial class ControllerHelper
{
    #region Public and private methods

    private List<BrandModel> GetBrandList(XElement xml)
    {
        List<BrandModel> itemsXml = new();
        XmlDocument xmlDocument = new();
        xmlDocument.LoadXml(xml.ToString());
        if (xmlDocument.DocumentElement is null) return itemsXml;

        XmlNodeList nodes = xmlDocument.DocumentElement.ChildNodes;
        if (nodes is null || nodes.Count <= 0) return itemsXml;
        foreach (XmlNode node in nodes)
        {
            BrandModel itemXml = new();
            if (node.Name.Equals("Brand", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    itemXml.ParseResult.Status = ParseStatus.Success;
                    // Set properties.
                    SetItemPropertyFromXmlAttributeGuid(node, itemXml, "Guid");
                    SetItemPropertyFromXmlAttribute(node, itemXml, nameof(itemXml.IsMarked));
                    SetItemPropertyFromXmlAttribute(node, itemXml, nameof(itemXml.Name));
                    SetItemPropertyFromXmlAttribute(node, itemXml, nameof(itemXml.Code));

                    if (string.IsNullOrEmpty(itemXml.ParseResult.Exception))
                        itemXml.ParseResult.Message = "Is success";
                }
                catch (Exception ex)
                {
                    itemXml.ParseResult.Status = ParseStatus.Error;
                    itemXml.ParseResult.Exception = ex.Message;
                    if (ex.InnerException is not null)
                        itemXml.ParseResult.InnerException = ex.InnerException.Message;
                }
            }
            else
            {
                itemXml.ParseResult.Status = ParseStatus.Error;
                itemXml.ParseResult.Exception = $"The node with name '{node.Name}' is not ident Brand!";
            }
            itemsXml.Add(itemXml);
        }
        return itemsXml;
    }

    // ReSharper disable once InconsistentNaming
    private void AddResponse1cBrand(Response1cShortModel response, 
        List<BrandModel> itemsDb, BrandModel itemXml)
    {
        try
        {
            BrandModel? itemDb = itemsDb.Find(x => x.IdentityValueUid.Equals(itemXml.IdentityValueUid));

            // Find by UID -> Update.
            if (itemDb is not null && itemDb.IsNotNew)
            {
                itemDb.UpdateProperties(itemXml);
                (bool IsOk, Exception? Exception) dbUpdate = DataContext.DataAccess.UpdateForce(itemDb);
                if (dbUpdate.IsOk)
                    response.Successes.Add(new(itemXml.IdentityValueUid));
                else
                    AddResponse1cException(response, itemXml.IdentityValueUid, dbUpdate.Exception);
                return;
            }

            // Find by Code -> Delete.
            itemDb = itemsDb.Find(x => x.Code.Equals(itemXml.Code));
            if (itemDb is not null && itemDb.IsNotNew)
            {
                (bool IsOk, Exception? Exception) dbDelete = DataContext.DataAccess.Delete(itemDb);
                // Delete was success. Duplicate field Code: {itemXml.Code}
                if (!dbDelete.IsOk)
                {
                    AddResponse1cException(response, itemDb.IdentityValueUid, dbDelete.Exception);
                    return;
                }
            }

            // Not find -> Add.
            (bool IsOk, Exception? Exception) dbSave = DataContext.DataAccess.Save(itemXml, itemXml.Identity);
            // Add was success.
            if (dbSave.IsOk)
                response.Successes.Add(new(itemXml.IdentityValueUid));
            else
                AddResponse1cException(response, itemXml.IdentityValueUid, dbSave.Exception);
        }
        catch (Exception ex)
        {
            AddResponse1cException(response, itemXml.IdentityValueUid, ex);
        }
    }

    // ReSharper disable once InconsistentNaming
    public ContentResult NewResponse1cBrands(ISessionFactory sessionFactory, XElement request, string formatString)
    {
        return NewResponse1cCore<Response1cShortModel>(sessionFactory, response =>
        {
            SqlCrudConfigModel sqlCrudConfig = new(new List<SqlFieldFilterModel>(), true, false, false, true);
            List<BrandModel> itemsDb = DataContext.GetListNotNullable<BrandModel>(sqlCrudConfig);
            List<BrandModel> itemsXml = GetBrandList(request);
            foreach (BrandModel itemXml in itemsXml)
            {
                switch (itemXml.ParseResult.Status)
                {
                    case ParseStatus.Success:
                        AddResponse1cBrand(response, itemsDb, itemXml);
                        break;
                    case ParseStatus.Error:
                        AddResponse1cException(response, itemXml);
                        break;
                }
            }
        }, formatString, false);
    }

    #endregion
}