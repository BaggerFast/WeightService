﻿using System;
using System.Collections.Generic;
using BlazorCore.DAL.TableModels;
using NUnit.Framework;

namespace BlazorCoreTests.DAL
{
    public class ScaleTempEntity
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual string DeviceIp { get; set; }
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}. " +
                   $"{nameof(Description)}: {Description}. " +
                   $"{nameof(DeviceIp)}: {DeviceIp}. ";
        }
    }

    [TestFixture]
    internal class DataAccessEntityTests
    {
        [Test]
        public void Entity_GetEntitiesNativeMapping_DoesNotThrow()
        {
            Utils.MethodStart();

            Assert.DoesNotThrow(() =>
            {
                Assert.AreEqual(false, false);
                var entities = DataAccessUtils.DataAccess.GetEntitiesNativeMapping<ScaleEntity>(@"
select *
from [db_scales].[Scales]
where Id > 4
                    ".TrimStart('\r', ' ', '\n').TrimEnd('\r', ' ', '\n'), string.Empty, 0, string.Empty);
                foreach (var entity in entities)
                {
                    TestContext.WriteLine(entity);
                    TestContext.WriteLine();
                }
            });

            Utils.MethodComplete();
        }
        
        [Test]
        public void Entity_GetEntitiesNativeObject_DoesNotThrow()
        {
            Utils.MethodStart();

            Assert.DoesNotThrow(() =>
            {
                Assert.AreEqual(false, false);
                var entities = DataAccessUtils.DataAccess.GetEntitiesNativeObject(@"
select [Id],[Description],[DeviceIP]
from [db_scales].[Scales]
where Id > 4
                    ".TrimStart('\r', ' ', '\n').TrimEnd('\r', ' ', '\n'), string.Empty, 0, string.Empty);
                var items = new List<ScaleTempEntity>();
                foreach (var entity in entities)
                {
                    if (entity is object[] { Length: 3 } ent)
                    {
                        items.Add(new ScaleTempEntity
                        {
                            Id = Convert.ToInt32(ent[0]),
                            Description = Convert.ToString(ent[1]),
                            DeviceIp = Convert.ToString(ent[2]),
                        });
                    }
                }
                foreach (var scaleTempEntity in items)
                {
                    TestContext.WriteLine(scaleTempEntity);
                    TestContext.WriteLine();
                }
            });

            Utils.MethodComplete();
        }
    }
}