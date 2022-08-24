﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table validation "PLUS_SCALES".
/// </summary>
public class PluScaleValidator : BaseUidValidator
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public PluScaleValidator()
    {
		RuleFor(item => ((PluScaleEntity)item).Plu)
			.NotEmpty()
			.NotNull();
		RuleFor(item => ((PluScaleEntity)item).Scale)
			.NotEmpty()
			.NotNull();
	}
}
