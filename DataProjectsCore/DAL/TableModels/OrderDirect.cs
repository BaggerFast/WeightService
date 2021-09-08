﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataShareCore.DAL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataProjectsCore.DAL.TableModels
{
    [Serializable]
    public class OrderDirect : BaseSerializeEntity<OrderDirect>
    {
        public int Id { get; set; }
        public int OrderType { get; set; } = 1;
        public string RRefID { get; set; }

        public PluDirect PLU { get; set; }
        public int TemplateID { get; set; }
        public TemplateDirect Template { get; set; }

        public int PlaneBoxCount { get; set; }
        public int FactBoxCount { get; set; } = 0;
        public int PlanePalletCount { get; set; }
        public DateTime? PlanePackingOperationBeginDate { get; set; }
        public DateTime? PlanePackingOperationEndDate { get; set; }
        public ScaleDirect Scale { get; set; }
        public DateTime ProductDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public ProjectsEnums.OrderStatus Status { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is OrderDirect item))
            {
                return false;
            }

            return Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public OrderDirect()
        {

        }

        public OrderDirect(PluDirect _plu)
        {
            PLU = _plu;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"({ProductDate})");
            sb.Append($"{PLU}");
            return sb.ToString();
        }

        public static IDictionary<string, object> ObjectToDictionary<T>(T item)
            where T : class
        {
            Type myObjectType = item.GetType();
            IDictionary<string, object> dict = new Dictionary<string, object>();
            object[] indexer = new object[0];
            System.Reflection.PropertyInfo[] properties = myObjectType.GetProperties();
            foreach (System.Reflection.PropertyInfo info in properties)
            {
                object value = info.GetValue(item, indexer);
                dict.Add(info.Name, value);
            }
            return dict;
        }

        public static T ObjectFromDictionary<T>(IDictionary<string, object> dict)
            where T : class
        {
            Type type = typeof(T);
            T result = (T)Activator.CreateInstance(type);
            foreach (KeyValuePair<string, object> item in dict)
            {
                type.GetProperty(item.Key)?.SetValue(result, item.Value, null);
            }
            return result;
        }

        public void LoadTemplate()
        {
            Template = new TemplateDirect(TemplateID);
        }

        public void SetStatus(ProjectsEnums.OrderStatus orderStatus)
        {
            using SqlConnection con = SqlConnectFactory.GetConnection();
            con.Open();
            string query =
                "DECLARE @Status tinyint;" +
                "EXECUTE [db_scales].[SetOrderStatus] @OrderId, @StatusName, @Status OUTPUT" +
                "";
            using (SqlCommand cmd = new(query))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@OrderId", RRefID);
                cmd.Parameters.AddWithValue("@StatusName", orderStatus.ToString());
                cmd.ExecuteNonQuery();
                Status = orderStatus;
            }
            con.Close();
        }

        public ProjectsEnums.OrderStatus GetStatus()
        {
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                con.Open();
                string query = "SELECT [db_scales].[GetOrderStatus](@OrderId, DEFAULT);";
                using (SqlCommand cmd = new(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@OrderId", RRefID);
                    string reader = Convert.ToString(cmd.ExecuteScalar());
                    Status = (ProjectsEnums.OrderStatus)Enum.Parse(typeof(ProjectsEnums.OrderStatus), reader);
                }
                con.Close();
            }
            return Status;
        }

        public static int GetOrderPercentCompletion(OrderDirect order)
        {
            int result = 0;
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                con.Open();
                string query = "SELECT [db_scales].[GetOrderPercentCompletion] (@OrderID)";
                using (SqlCommand cmd = new(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@OrderId", order.RRefID);
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                con.Close();
            }
            return result;
        }

        public static List<OrderDirect> GetOrderList(ScaleDirect scale)
        {
            List<OrderDirect> res = new();
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                con.Open();
                string query = "" +
                            "SELECT " +
                            "[Id]," +                               //0
                            "[RRefID]," +                           //1
                            "[PLU]," +                              //2
                            "[PlaneBoxCount]," +                    //3
                            "[PlanePalletCount]," +                 //4
                            "[PlanePackingOperationBeginDate]," +    //5
                            "[PlanePackingOperationEndDate]," +     //6
                            "[ProductDate]," +                      //7
                            "[TemplateID]," +                       //8
                            "[CreateDate]," +                       //9
                            "[OrderType]," +                        //10
                            "[ScaleID]," +                          //11
                            "[CurrentStatus] " +                    //12
                            "FROM [db_scales].[GetOrderListByScale] (@ScaleId, @StartDate, @EndDate); " +
                            "";
                using (SqlCommand cmd = new(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@ScaleId", scale.Id);
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Now.AddDays(-2));
                    cmd.Parameters.AddWithValue("@EndDate", DateTime.Now);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProjectsEnums.OrderStatus enm = ProjectsEnums.OrderStatus.New;
                            int number = reader.GetByte(12);
                            if (Enum.IsDefined(typeof(ProjectsEnums.OrderStatus), number))
                            {
                                enm = (ProjectsEnums.OrderStatus)number; // преобразование 
                                                           // или CustomEnum enm = (CustomEnum)Enum.ToObject(typeof(CustomEnum), number);
                            }
                            int pluCode = reader.GetInt32(2);
                            //PluEntity PLU = new PluEntity(SqlConnectFactory.GetValue<int>(reader, "PLU"), pluCode);
                            PluDirect PLU = new(scale, pluCode);
                            PLU.Load();
                            OrderDirect order = new()
                            {
                                Id = SqlConnectFactory.GetValue<int>(reader, "Id"),
                                //RRefID = SqlConnectFactory.GetValue<string>(reader, "RRefID"),
                                PlaneBoxCount = SqlConnectFactory.GetValue<int>(reader, "PlaneBoxCount"),
                                PlanePalletCount = SqlConnectFactory.GetValue<int>(reader, "PlanePalletCount"),
                                PlanePackingOperationBeginDate = SqlConnectFactory.GetValue<DateTime>(reader, "PlanePackingOperationBeginDate"),
                                PlanePackingOperationEndDate = SqlConnectFactory.GetValue<DateTime>(reader, "PlanePackingOperationEndDate"),
                                ProductDate = SqlConnectFactory.GetValue<DateTime>(reader, "ProductDate"),
                                TemplateID = SqlConnectFactory.GetValue<int>(reader, "TemplateID"),
                                CreateDate = SqlConnectFactory.GetValue<DateTime>(reader, "CreateDate"),
                                OrderType = SqlConnectFactory.GetValue<int>(reader, "OrderType"),
                                Scale = scale,
                                Status = enm,
                                PLU = PLU
                                //MyEnum myEnum = (MyEnum)myInt;
                                //MyEnum myEnum = (MyEnum)Enum.Parse(typeof(MyEnum), myString);
                            };
                            res.Add(order);
                        }
                    }
                    reader.Close();
                }
                con.Close();
            }
            return res;
        }

        public static List<OrderDirect> GetOrderList(ScaleDirect scale, DateTime startDate, DateTime endDate)
        {
            List<OrderDirect> res = new();
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                con.Open();
                string query = "" +
                            "SELECT " +
                            "[Id]," +                               //0
                            "[RRefID]," +                           //1
                            "[PLU]," +                              //2
                            "[PlaneBoxCount]," +                    //3
                            "[PlanePalletCount]," +                 //4
                            "[PlanePackingOperationBeginDate]," +    //5
                            "[PlanePackingOperationEndDate]," +     //6
                            "[ProductDate]," +                      //7
                            "[TemplateID]," +                       //8
                            "[CreateDate]," +                       //9
                            "[OrderType]," +                        //10
                            "[ScaleID]," +                          //11
                            "[CurrentStatus] " +                    //12
                            "FROM [db_scales].[GetOrderListByScale] (@ScaleId, @StartDate, @EndDate); " +
                            "";
                using (SqlCommand cmd = new(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@ScaleId", scale.Id);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProjectsEnums.OrderStatus orderStatus = ProjectsEnums.OrderStatus.New;
                            int number = reader.GetByte(12);
                            if (Enum.IsDefined(typeof(ProjectsEnums.OrderStatus), number))
                            {
                                orderStatus = (ProjectsEnums.OrderStatus)number; // преобразование 
                                                           // или CustomEnum enm = (CustomEnum)Enum.ToObject(typeof(CustomEnum), number);
                            }
                            int pluCode = reader.GetInt32(2);
                            PluDirect PLU = new(scale, pluCode);
                            PLU.Load();
                            OrderDirect order = new()
                            {
                                Id = SqlConnectFactory.GetValue<int>(reader, "Id"),
                                RRefID = SqlConnectFactory.GetValue<string>(reader, "RRefID"),
                                PlaneBoxCount = SqlConnectFactory.GetValue<int>(reader, "PlaneBoxCount"),
                                PlanePalletCount = SqlConnectFactory.GetValue<int>(reader, "PlanePalletCount"),
                                PlanePackingOperationBeginDate = SqlConnectFactory.GetValue<DateTime>(reader, "PlanePackingOperationBeginDate"),
                                PlanePackingOperationEndDate = SqlConnectFactory.GetValue<DateTime>(reader, "PlanePackingOperationEndDate"),
                                ProductDate = SqlConnectFactory.GetValue<DateTime>(reader, "ProductDate"),
                                TemplateID = SqlConnectFactory.GetValue<int>(reader, "TemplateID"),
                                CreateDate = SqlConnectFactory.GetValue<DateTime>(reader, "CreateDate"),
                                OrderType = SqlConnectFactory.GetValue<int>(reader, "OrderType"),
                                Scale = scale,
                                Status = orderStatus,
                                PLU = PLU
                                //MyEnum myEnum = (MyEnum)myInt;
                                //MyEnum myEnum = (MyEnum)Enum.Parse(typeof(MyEnum), myString);
                            };
                            res.Add(order);
                        }
                    }
                    reader.Close();
                }
                con.Close();
            }
            return res;
        }
    }
}