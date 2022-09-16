﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.CssStyles;
using DataCore.Sql.Core;
using DataCoreTests;
using NSubstitute;
using NUnit.Framework;

namespace BlazorCoreTests.Models.CssStyles;

[TestFixture]
internal class CssStyleTableBodyValidatorTests
{
	#region Public and private fields, properties, constructor

	private DataCoreHelper DataCore { get; } = DataCoreHelper.Instance;

	#endregion

	#region Public and private methods

	[Test]
	public void Model_Validate_IsFalse()
	{
		// Arrange.
		CssStyleTableBodyModel item = Substitute.For<CssStyleTableBodyModel>();
		// Act.
		// Assert.
		DataCore.AssertValidate(item, false);
		// Act.
		item.IdentityName = SqlFieldIdentityEnum.Empty;
		// Assert.
		DataCore.AssertValidate(item, false);
	}

	[Test]
	public void Model_Validate_IsTrue()
	{
		// Arrange.
		CssStyleTableBodyModel item = Substitute.For<CssStyleTableBodyModel>();
		// Act.
		item.IdentityName = SqlFieldIdentityEnum.Uid;
		item.IsShowMarked = true;
		// Assert.
		DataCore.AssertValidate(item, true);
	}

	#endregion
}
