﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace DataCoreTests.Sql.TableScaleModels;

[TestFixture]
internal class LogValidatorTests
{
	[Test]
	public void Entity_Validate_IsFalse()
	{
		Assert.DoesNotThrow(() =>
		{
			// Arrange.
			LogEntity item = Substitute.For<LogEntity>();
			LogValidator validator = new();
			// Act.
			ValidationResult result = validator.Validate(item);
			TestsUtils.FailureWriteLine(result);
			// Assert.
			Assert.IsFalse(result.IsValid);
			// Act.
			item.Version = string.Empty;
			result = validator.Validate(item);
			TestsUtils.FailureWriteLine(result);
			// Assert.
			Assert.IsFalse(result.IsValid);
		});
	}

	[Test]
	public void Entity_Validate_IsTrue()
	{
		Assert.DoesNotThrow(() =>
		{
			// Arrange.
			LogEntity item = Substitute.For<LogEntity>();
			LogValidator validator = new();
			// Act.
			item.Version = "0.1.2";
			item.File = "Test.cs";
			item.Line = 1;
			item.Member = "Test";
			item.LogType = new() { Number = 0, Icon = "Test" };
			item.Message = "Test";
			ValidationResult result = validator.Validate(item);
			TestsUtils.FailureWriteLine(result);
			// Assert.
			Assert.IsTrue(result.IsValid);
		});
	}

	[Test]
	public void DbTable_Validate_IsTrue()
	{
		TestsUtils.DbTableAction(() =>
		{
			// Arrange.
			LogValidator validator = new();
			LogEntity[]? items = TestsUtils.DataAccess.Crud.GetEntities<LogEntity>(null, null, 100);
			// Act.
			if (items == null || !items.Any())
			{
				TestContext.WriteLine($"{nameof(items)} is null or empty!");
			}
			else
			{
				TestContext.WriteLine($"Found {nameof(items)}.Count: {items.Count()}");
				int i = 0;
				foreach (LogEntity item in items)
				{
					if (i < 10)
						TestContext.WriteLine(item);
					i++;
					ValidationResult result = validator.Validate(item);
					TestsUtils.FailureWriteLine(result);
					// Assert.
					Assert.IsTrue(result.IsValid);
				}
			}
		});
	}
}
