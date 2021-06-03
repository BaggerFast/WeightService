﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EntitiesLib
{
    [Serializable]
    public class ProductSeriesEntity
    {
        public ProductSeriesEntity()
        {

        }


        public ProductSeriesEntity(ScaleEntity _Scale)
        {
            Scale = _Scale;
        }


        public int Id { get; set; }
        public Guid UUID { get; set; }
        public ScaleEntity Scale { get; set; }
        public DateTime CreateDate { get; set; }
        public SsccEntity Sscc { get; set; }
        public PluEntity Plu { get; set; }

        //public string TemplateID { get; set; }

        [XmlIgnore]
        public TemplateEntity Template { get; set; }
        public Int32 CountUnit { get; set; }
        public Decimal TotalNetWeight { get; set; }
        public Decimal TotalTareWeight { get; set; }

        public void LoadTemplate(int id)
        {
            Template = new TemplateEntity(id);
        }

        public void New()
        {
            if (Scale == null)
            {
                throw new Exception("Equipment instance not identified. Set [Scale].");
            }

            using (var con = SqlConnectFactory.GetConnection())
            {
                var query =
                    "DECLARE @SSCC varchar(50);\n" +
                    "DECLARE @WeithingDate datetime;\n" +
                    "DECLARE @xmldata xml;\n" +
                    "EXECUTE [db_scales].[NewProductSeries] @ScaleID, @SSCC OUTPUT, @xmldata OUTPUT;\n " +
                    "SELECT Id, CreateDate, UUID, SSCC,CountUnit,TotalNetWeight, TotalTareWeight " +
                    " FROM [db_scales].[GetCurrentProductSeries](@ScaleId);";
                using (var cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@ScaleID", Scale.Id);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Id = reader.GetInt32(0);
                        CreateDate = reader.GetDateTime(1);
                        UUID = reader.GetGuid(2);
                        CountUnit = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                        TotalNetWeight = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);
                        TotalTareWeight = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);

                        Sscc = new SsccEntity(reader.GetString(3));

                    }
                    reader.Close();
                    con.Close();
                }
            }
        }

        public void Load()
        {
            using (var con = SqlConnectFactory.GetConnection())
            {
                var query =
                    "SELECT Id, CreateDate, UUID, SSCC, CountUnit,TotalNetWeight, TotalTareWeight " +
                    " FROM [db_scales].[GetCurrentProductSeries](@ScaleId);";
                using (var cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@ScaleID", Scale.Id);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Id = reader.GetInt32(0);
                        CreateDate = reader.GetDateTime(1);
                        UUID = reader.GetGuid(2);
                        CountUnit = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                        TotalNetWeight = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);
                        TotalTareWeight = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);

                        Sscc = new SsccEntity(reader.GetString(3));

                    }
                    reader.Close();
                    con.Close();
                }
            }

        }

        public string SerializeObject()
        {

            var xmlSerializer = new XmlSerializer(typeof(ProductSeriesEntity));

            var settings = new XmlWriterSettings();
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.OmitXmlDeclaration = false;    // не подавлять xml заголовок

            settings.Encoding = Encoding.UTF8;      // кодировка
            // Какого то кипариса! эта настройка не работает
            // и UTF16 записывается в шапку XML
            // типа Visual Studio работает только с UTF16

            settings.Indent = true;                // добавлять отступы
            settings.IndentChars = "\t";           // сиволы отступа

            var dummyNSs = new XmlSerializerNamespaces();
            dummyNSs.Add(string.Empty, string.Empty);

            using (var textWriter = new StringWriter())
            {
                using (var xw = XmlWriter.Create(textWriter, settings))
                {
                    xmlSerializer.Serialize(xw, this, dummyNSs);
                }
                return textWriter.ToString();
            }

        }

    }

}
