﻿using System;
using BlazorCore.DAL;
using BlazorCore.DAL.DataModels;
using BlazorCore.DAL.TableModels;
using NUnit.Framework;

namespace BlazorCoreTests.DAL.TableModels
{
    [TestFixture]
    internal class ZebraPrinterTests
    {
        [Test]
        public void Entity_Equals_DoesNotThrow()
        {
            Utils.MethodStart();

            Assert.DoesNotThrow(() =>
            {
                var entityNew = new WorkshopEntity();
                Assert.AreEqual(true, entityNew.EqualsNew());
                Assert.AreEqual(true, entityNew.EqualsDefault());
                var entityCopy = entityNew.Clone();
                Assert.AreEqual(true, entityNew.Equals(entityCopy));

                foreach (var i in EnumValues.GetInt())
                foreach (var dt in EnumValues.GetDateTime())
                foreach (var s in EnumValues.GetString())
                foreach (var sh in EnumValues.GetShort())
                foreach (var b in EnumValues.GetBool())
                {
                    var entity = new PrinterEntity
                    {
                        Id = i,
                        CreateDate = dt,
                        ModifiedDate = dt,
                        Name = s,
                        Ip = s,
                        Port = sh,
                        Password = s,
                        PrinterType = new PrinterTypeEntity(),
                        Mac = s,
                        PeelOffSet = b,
                        DarknessLevel = sh,
                    };
                    _ = entity.ToString();
                    Assert.AreEqual(false, entityNew.Equals(entity));
                }
            });

            Utils.MethodComplete();
        }

        [Test]
        public void Entity_Crud_DoesNotThrow()
        {
            Utils.MethodStart();

            Assert.DoesNotThrow(() =>
            {
                const string name = "ZebraPrinterEntity test";
                const string name2 = "ZebraPrinterEntity test 2";
                foreach (var zebraPrinterTypeEntity in DataAccessUtils.DataAccess.PrinterTypesCrud.GetEntities(null, null))
                {
                    // SaveEntity
                    var zebraPrinterType = new PrinterEntity
                    {
                        Id = -1,
                        CreateDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Name = name,
                        Ip = default,
                        Port = default,
                        Password = null,
                        PrinterType = zebraPrinterTypeEntity,
                        Mac = default,
                        PeelOffSet = default,
                        DarknessLevel = default,
                    };
                    DataAccessUtils.DataAccess.PrintersCrud.SaveEntity(zebraPrinterType);
                }
                // GetEntities
                foreach (var entity in DataAccessUtils.DataAccess.PrintersCrud.GetEntities(null,
                    new FieldOrderEntity { Use = true, Name = EnumField.Name, Direction = EnumOrderDirection.Asc }))
                {
                    if (entity.Name.Equals(name))
                    {
                        // UpdateEntity
                        entity.Name = name2;
                        DataAccessUtils.DataAccess.PrintersCrud.UpdateEntity(entity);
                    }
                }
                // GetEntities
                foreach (var entity in DataAccessUtils.DataAccess.PrintersCrud.GetEntities(null,
                    new FieldOrderEntity { Use = true, Name = EnumField.Name, Direction = EnumOrderDirection.Asc }))
                {
                    if (entity.Name.Equals(name2))
                    {
                        // DeleteEntity
                        DataAccessUtils.DataAccess.PrintersCrud.DeleteEntity(entity);
                    }
                }
            }
            );

            Utils.MethodComplete();
        }
    }
}