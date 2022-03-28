﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

//using DataCore;
//using NUnit.Framework;
//using System.Collections.Generic;

//namespace DataCoreTests.DAL.TableModels
//{
//    [TestFixture]
//    internal class BarCodeTypesTests
//    {
//        [Test]
//        public void Entity_Equals_DoesNotThrow()
//        {
//            TestsUtils.MethodStart();

//            Assert.DoesNotThrow(() =>
//            {
//                BarcodeTypeEntityV2 entityNew = new();
//                Assert.AreEqual(true, entityNew.EqualsNew());
//                Assert.AreEqual(true, entityNew.EqualsDefault());
//                object entityCopy = entityNew.Clone();
//                Assert.AreEqual(true, entityNew.Equals(entityCopy));

//                foreach (int i in TestsEnums.GetInt())
//                    foreach (string s in TestsEnums.GetString())
//                    {
//                        BarcodeTypeEntityV2 entity = new()
//                        {
//                            Id = i,
//                            Name = s
//                        };
//                        _ = entity.ToString();
//                        Assert.AreEqual(false, entityNew.Equals(entity));
//                    }
//            });

//            TestsUtils.MethodComplete();
//        }

//        public BarcodeTypeEntityV2 EntityCreate(string name)
//        {
//            //var entity = new BarCodeTypesEntity
//            //{
//            //    //Id = -1,
//            //    Name = name
//            //};
//            //// Не сохранять.
//            //DataAccessUtils.DataAccess.BarCodeTypesCrud.SaveEntity(entity);
//            return DataAccessUtilsTests.DataAccess.Crud.GetEntity<BarcodeTypeEntityV2>(
//                new FieldListEntity(new Dictionary<string, object?> { { ShareEnums.DbField.Name.ToString(), name } }),
//                new FieldOrderEntity(ShareEnums.DbField.Id, ShareEnums.DbOrderDirection.Desc));
//        }

//        [Test]
//        public void Entity_Crud_DoesNotThrow()
//        {
//            TestsUtils.MethodStart();

//            Assert.DoesNotThrow(() =>
//            {
//                string name = "Code128";
//                BarcodeTypeEntityV2 entityNew = EntityCreate(name);
//                // UpdateEntity - Не изменять
//                //entityNew.Name += " changed";
//                //DataAccessUtils.DataAccess.BarCodeTypesCrud.UpdateEntity(entityNew);
//                // GetEntities
//                BarcodeTypeEntityV2[] entities = DataAccessUtilsTests.DataAccess.Crud.GetEntities<BarcodeTypeEntityV2>(null, null);
//                Assert.AreEqual(true, entities.Length > 0);
//                foreach (BarcodeTypeEntityV2 entity in entities)
//                {
//                    if (entity.Name.Equals(name + " changed"))
//                    {
//                        // DeleteEntity - Не удалять
//                        //DataAccessUtils.DataAccess.BarCodeTypesCrud.DeleteEntity(entity);
//                    }
//                }
//            });

//            TestsUtils.MethodComplete();
//        }
//    }
//}