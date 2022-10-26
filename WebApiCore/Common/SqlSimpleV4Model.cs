﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Xml.Serialization;
using DataCore.Sql.Models;
using WebApiCore.Utils;

namespace WebApiCore.Common;

[XmlRoot(TerraConsts.Response, Namespace = "", IsNullable = false)]
public class SqlSimpleV4Model : SerializeDeprecatedModel<SqlSimpleV4Model>
{
    #region Public and private fields and properties

    [XmlArray(TerraConsts.Items)]
    [XmlArrayItem(TerraConsts.Simple, typeof(SqlSimpleV1Model))]
    public List<SqlSimpleV1Model> Simples { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public SqlSimpleV4Model()
    {
        //
    }

    #endregion

    #region Public and private methods

    public override string ToString()
    {
        string result = string.Empty;
        if (Simples?.Count > 0)
        {
            foreach (SqlSimpleV1Model item in Simples)
            {
                result += item.SerializeAsText() + Environment.NewLine;
            }
        }
        return result;
    }

    #endregion
}