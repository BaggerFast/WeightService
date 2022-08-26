﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table validation "___".
/// </summary>
public class PrinterValidator : BaseValidator
{
	/// <summary>
	/// Constructor.
	/// </summary>
	public PrinterValidator() : base(ColumnName.Id)
	{
		RuleFor(item => ((PrinterEntity)item).DarknessLevel)
			.NotNull()
			.GreaterThanOrEqualTo((short)0);
		RuleFor(item => ((PrinterEntity)item).PrinterType)
			.NotEmpty()
			.NotNull()
			.SetValidator(new PrinterTypeValidator());
	}
}