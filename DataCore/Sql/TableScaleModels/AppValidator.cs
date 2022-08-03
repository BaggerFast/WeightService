﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using FluentValidation;

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table validation "ACCESS".
/// </summary>
public class AppValidator : AbstractValidator<AppEntity>
{
	/// <summary>
	/// Constructor.
	/// </summary>
	public AppValidator()
	{
		RuleFor(item => item.Name)
			.NotEmpty()
			.NotNull();
	}
}
