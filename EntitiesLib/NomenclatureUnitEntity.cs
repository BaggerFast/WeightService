﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WeightServices.Common;

namespace EntitiesLib
{
    [Serializable]
    public class NomenclatureUnitEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string RRefID { get; set; }

        public NomenclatureEntity Nomenclature { get; set; }
        public bool Marked { get; set; }
        public Decimal PackWeight { get; set; }
        public Int32 PackQuantly { get; set; }
        public NomenclatureEntity PackType { get; set; }


        public override bool Equals(object obj)
        {
            if (!(obj is NomenclatureUnitEntity item))
            {
                return false;
            }
            return Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public string SerializeObject()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NomenclatureUnitEntity));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, this);
                return textWriter.ToString();
            }
        }


        public NomenclatureUnitEntity()
        {
        }

        public NomenclatureUnitEntity(int _Id)
        {
            this.Id = _Id;
            Load();
        }


        public void Load()
        {
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                string query = "SELECT * FROM [db_scales].[GetNomenclatureUnit] (@Id);";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Id", this.Id);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        Id = SqlConnectFactory.GetValue<int>(reader, "ID");
                        Name = SqlConnectFactory.GetValue<string>(reader, "Name");
                        CreateDate = SqlConnectFactory.GetValue<DateTime>(reader, "CreateDate");
                        ModifiedDate = SqlConnectFactory.GetValue<DateTime>(reader, "ModifiedDate");
                        RRefID = SqlConnectFactory.GetValue<string>(reader, "RRefID");

                        Marked      = SqlConnectFactory.GetValue<bool>(reader, "Marked");
                        PackWeight  = SqlConnectFactory.GetValue<decimal>(reader, "PackWeight");
                        PackQuantly = SqlConnectFactory.GetValue<int>(reader, "PackQuantly");

                        PackType = new NomenclatureEntity(SqlConnectFactory.GetValue<int>(reader, "PackTypeId"));
                        Nomenclature = new NomenclatureEntity(SqlConnectFactory.GetValue<int>(reader, "NomenclatureId"));

                    }

                    reader.Close();
                    con.Close();
                }
            }
        }


        public void Save()
        {

            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                string query = @"
                    DECLARE @ID int; 
                    
                    EXECUTE [db_scales].[SetNomenclatureUnit]
                       @1CRRefID,
                       @Name,
                       @NomenclatureId  ,
                       @Marked          ,
                       @PackWeight      ,
                       @PackQuantly     ,
                       @PackTypeId      ,
                       @ID OUTPUT;

                    SELECT @ID";

                using (SqlCommand cmd = new SqlCommand(query))
                {

                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue($"@1CRRefID", this.RRefID ?? (object)DBNull.Value);  // @1CRRefID
                    cmd.Parameters.AddWithValue($"@Name", this.Name ?? (object)DBNull.Value);  // 

                    cmd.Parameters.AddWithValue($"@NomenclatureId",     this.Nomenclature.Id);  // 
                    cmd.Parameters.AddWithValue($"@Marked",             this.Marked);  // 
                    cmd.Parameters.AddWithValue($"@PackWeight",         this.PackWeight);  // 
                    cmd.Parameters.AddWithValue($"@PackQuantly",        this.PackQuantly);  // 
                    cmd.Parameters.AddWithValue($"@PackTypeId",         this.PackType==null ? this.PackType.Id : (object)DBNull.Value);  // 


                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        this.Id = SqlConnectFactory.GetValue<int>(reader, "Id");
                    }

                    reader.Close();

                }

                con.Close();

            }

        }

        public static List<NomenclatureUnitEntity> GetList()
        {
            List<NomenclatureUnitEntity> res = new List<NomenclatureUnitEntity>();
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                string query =
                    "SELECT * FROM [db_scales].[GetNomenclatureUnit] (default);";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        NomenclatureUnitEntity pFacility = new NomenclatureUnitEntity()
                        {
                            Id = SqlConnectFactory.GetValue<int>(reader, "Id"),
                            Name = SqlConnectFactory.GetValue<string>(reader, "Name"),
                            CreateDate = SqlConnectFactory.GetValue<DateTime>(reader, "CreateDate"),
                            ModifiedDate = SqlConnectFactory.GetValue<DateTime>(reader, "ModifiedDate"),
                            RRefID = SqlConnectFactory.GetValue<string>(reader, "1CRRefID"),
                            Marked = SqlConnectFactory.GetValue<bool>(reader, "Marked"),
                            PackWeight = SqlConnectFactory.GetValue<decimal>(reader, "PackWeight"),
                            PackQuantly = SqlConnectFactory.GetValue<int>(reader, "PackQuantly"),

                            PackType        = new NomenclatureEntity(SqlConnectFactory.GetValue<int>(reader, "PackTypeId")),
                            Nomenclature    = new NomenclatureEntity(SqlConnectFactory.GetValue<int>(reader, "NomenclatureId")),


                    };

                     res.Add(pFacility);

                    }
                    reader.Close();

                }
            }
            return res;

        }



    }
}
