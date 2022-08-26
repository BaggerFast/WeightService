﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table validation "BARCODES_V2".
/// </summary>
public class BarCodeValidator : BaseValidator
{
	/// <summary>
	/// Constructor.
	/// </summary>
	public BarCodeValidator() : base(ColumnName.Uid)
	{
		RuleFor(item => ((BarCodeEntity)item).Value)
			.NotEmpty()
			.NotNull();
	}
}