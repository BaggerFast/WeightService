﻿using BlazorCore.DAL;
using BlazorCore.DAL.DataModels;
using BlazorCore.DAL.TableModels;
using NUnit.Framework;

namespace BlazorCoreTests.DAL.TableModels
{
    [TestFixture]
    internal class ScalesTests
    {
        [Test]
        public void Entity_Equals_DoesNotThrow()
        {
            Utils.MethodStart();

            Assert.DoesNotThrow(() =>
            {
                var entityNew = new ScaleEntity();
                Assert.AreEqual(true, entityNew.EqualsNew());
                Assert.AreEqual(true, entityNew.EqualsDefault());
                var entityCopy = entityNew.Clone();
                Assert.AreEqual(true, entityNew.Equals(entityCopy));

                foreach (var i in EnumValues.GetInt())
                foreach (var s in EnumValues.GetString())
                foreach (var guid in EnumValues.GetGuid())
                foreach (var sh in EnumValues.GetShort())
                foreach (var b in EnumValues.GetBool())
                foreach (var dt in EnumValues.GetDateTime())
                {
                    var entity = new ScaleEntity
                    {
                        Id = i,
                        CreateDate = dt,
                        ModifiedDate = dt,
                        TemplateDefault = new TemplateEntity(),
                        TemplateSeries = new TemplateEntity(),
                        WorkShop = new WorkshopEntity(),
                        Host = new HostEntity(),
                        Description = s,
                        IdRRef = guid,
                        DeviceIp = s,
                        DevicePort = sh,
                        DeviceMac = s,
                        DeviceSendTimeout = sh,
                        DeviceReceiveTimeout = sh,
                        DeviceComPort = s,
                        ZebraIp = s,
                        ZebraPort = sh,
                        UseOrder = b,
                        VerScalesUi = s,
                        DeviceNumber = i,
                        ScaleFactor = i
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

            Assert.DoesNotThrow(() => {
                // GetEntities.
                foreach (var entity in DataAccessUtils.DataAccess.ScalesCrud.GetEntities(null,
                    new FieldOrderEntity { Use = true, Name = EnumField.Description, Direction = EnumOrderDirection.Desc }))
                {
                    TestContext.WriteLine(entity.ToString());
                    TestContext.WriteLine();
                }
            });

            Utils.MethodComplete();
        }
    }
}