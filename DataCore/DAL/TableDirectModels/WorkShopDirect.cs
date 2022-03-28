﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.DAL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace DataCore.DAL.TableDirectModels
{
    [Serializable]
    public class WorkShopDirect : BaseSerializeEntity<WorkShopDirect>
    {
        #region Public and private fields and properties

        public long Id { get; set; } = default;
        public string Name { get; set; } = string.Empty;

        public ProductionFacilityDirect ProductionFacility { get; set; } = new ProductionFacilityDirect();
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string RRefID { get; set; } = string.Empty;
        public SqlConnectFactory SqlConnect { get; private set; } = SqlConnectFactory.Instance;

        #endregion

        #region Constructor and destructor

        public WorkShopDirect()
        {
            Load();
        }

        public WorkShopDirect(long id)
        {
            Id = id;
            Load();
        }

        #endregion

        #region Public and private methods

        public override bool Equals(object obj)
        {
            if (obj is not WorkShopDirect item)
            {
                return false;
            }
            return Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void Load()
        {
            using SqlConnection con = SqlConnect.GetConnection();
            con.Open();
            string query = "SELECT [Id] ,[Name] ,[ProductionFacilityID] ,[CreateDate] ,[ModifiedDate] ,[1CRRefID]  FROM [db_scales].[GetWorkShop] (default,@Id);";
            using (SqlCommand cmd = new(query))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", Id);
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Id = SqlConnect.GetValueAsNotNullable<long>(reader, "ID");
                        Name = SqlConnect.GetValueAsString(reader, "Name");
                        CreateDate = SqlConnect.GetValueAsNotNullable<DateTime>(reader, "CreateDate");
                        ModifiedDate = SqlConnect.GetValueAsNotNullable<DateTime>(reader, "ModifiedDate");
                        RRefID = SqlConnect.GetValueAsString(reader, "RRefID");
                    }
                }
                ProductionFacility = new ProductionFacilityDirect(SqlConnect.GetValueAsNotNullable<int>(reader, "ProductionFacilityID"));
                reader.Close();
            }
            con.Close();
        }

        public void Save()
        {

            using SqlConnection con = SqlConnect.GetConnection();
            con.Open();
            string query = @"
                    DECLARE @ID int; 
                    EXECUTE @RC = [db_scales].[SetWorkShop] 
                       @Name
                      ,@ProductionFacilityID
                      ,@1CRRefID
                       @ID OUTPUT;
                    SELECT @ID";
            using (SqlCommand cmd = new(query))
            {
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue($"@Name", Name ?? (object)DBNull.Value);               // 
                cmd.Parameters.AddWithValue($"@ProductionFacilityID", ProductionFacility.Id);      // 
                cmd.Parameters.AddWithValue($"@1CRRefID", RRefID ?? (object)DBNull.Value);         // @1CRRefID
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Id = SqlConnect.GetValueAsNotNullable<long>(reader, "Id");
                    }
                }
                reader.Close();
            }
            con.Close();

        }

        public List<WorkShopDirect> GetList(ProductionFacilityDirect productionFacility)
        {
            List<WorkShopDirect> result = new();
            using (SqlConnection con = SqlConnect.GetConnection())
            {
                con.Open();
                string query = "SELECT [Id] ,[Name] ,[ProductionFacilityID] ,[CreateDate] ,[ModifiedDate] ,[1CRRefID]  FROM [db_scales].[GetWorkShop] (@Id,default);";
                using (SqlCommand cmd = new(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Id", productionFacility.Id);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            WorkShopDirect workShop = new()
                            {
                                Id = SqlConnect.GetValueAsNotNullable<long>(reader, "Id"),
                                Name = SqlConnect.GetValueAsString(reader, "Name"),
                                CreateDate = SqlConnect.GetValueAsNotNullable<DateTime>(reader, "CreateDate"),
                                ModifiedDate = SqlConnect.GetValueAsNotNullable<DateTime>(reader, "ModifiedDate"),
                                RRefID = SqlConnect.GetValueAsString(reader, "1CRRefID")
                            };
                            workShop.ProductionFacility = productionFacility;
                            result.Add(workShop);
                        }
                    }
                    reader.Close();
                }
                con.Close();
            }
            return result;
        }

        #endregion
    }
}