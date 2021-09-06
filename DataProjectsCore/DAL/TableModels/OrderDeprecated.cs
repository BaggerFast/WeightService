﻿//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Reflection;
//using System.Text;
//using System.Xml.Serialization;

//namespace DataProjectsCore.DAL.Entities
//{
//    public enum OrderStatus
//    {
//        New         = 0,
//        InProgress  = 1,
//        Paused      = 2,
//        Performed   = 3,
//        Canceled    = 4
//    }

//    [Serializable]
//    public class OrderEntity
//    {
//        public int Id               { get; set; }
//        public int OrderType        { get; set; } = 1;
//        public string RRefID        { get; set; }

//        public PluEntity  PLU       { get; set; }
//        public string TemplateID    { get; set; }
//        public TemplateEntity Template { get; set; }

//        public int PlaneBoxCount    { get; set; }
//        public int FactBoxCount     { get; set; } = 0;
//        public int PlanePalletCount { get; set; }
//        public DateTime? PlanePackingOperationBeginDate { get; set; }
//        public DateTime? PlanePackingOperationEndDate   { get; set; }
//        public string ScaleID           { get; set; }
//        public DateTime ProductDate     { get; set; }
//        public DateTime? CreateDate     { get; set; }
//        public OrderStatus Status       { get; set; }


//        public override bool Equals(object obj)
//        {
//            if (!(obj is OrderEntity item))
//            {
//                return false;
//            }

//            return Id.Equals(item.Id);
//        }

//        public override int GetHashCode()
//        {
//            return Id.GetHashCode();
//        }

//        public OrderEntity ()
//        {

//        }

//        public OrderEntity(PluEntity _plu)
//        {
//            PLU = _plu;
//        }

//        public override string ToString()
//        {
//            StringBuilder sb = new StringBuilder();
//            sb.Append($"({ProductDate})");
//            sb.Append($"{PLU}");
//            return sb.ToString();
//        }

//        public static IDictionary<string, object> ObjectToDictionary<T>(T item)
//            where T : class
//        {
//            Type myObjectType = item.GetType();
//            IDictionary<string, object> dict = new Dictionary<string, object>();
//            var indexer = new object[0];
//            PropertyInfo[] properties = myObjectType.GetProperties();
//            foreach (var info in properties)
//            {
//                var value = info.GetValue(item, indexer);
//                dict.Add(info.Name, value);
//            }
//            return dict;
//        }
        
//        public static T ObjectFromDictionary<T>(IDictionary<string, object> dict)
//            where T : class
//        {
//            Type type = typeof(T);
//            T result = (T)Activator.CreateInstance(type);
//            foreach (var item in dict)
//            {
//                type.GetProperty(item.Key)?.SetValue(result, item.Value, null);
//            }
//            return result;
//        }

//        public string SerializeObject()
//        {
//            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderEntity));
//            using (StringWriter textWriter = new StringWriter())
//            {
//                xmlSerializer.Serialize(textWriter, this);
//                return textWriter.ToString();
//            }
//        }

//        public void LoadTemplate()
//        {
//            if (TemplateID != null)
//                Template = new TemplateEntity(TemplateID);
//        }
//    }
//}