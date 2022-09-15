﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Tables;

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table validation "___".
/// </summary>
public class VersionValidator : SqlTableValidator<VersionModel>
{
	/// <summary>
	/// Constructor.
	/// </summary>
	public VersionValidator() : base(false, false)
	{
		RuleFor(item => item.ReleaseDt)
			.NotEmpty()
			.NotNull()
			.GreaterThanOrEqualTo(new DateTime(2020, 01, 01));
		RuleFor(item => item.Version)
			.NotEmpty()
			.NotNull()
			.GreaterThan(default(short));
		RuleFor(item => item.Description)
			.NotEmpty()
			.NotNull();
	}
}
