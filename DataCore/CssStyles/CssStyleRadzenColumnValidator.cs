﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCore.CssStyles;

public class CssStyleRadzenColumnValidator : AbstractValidator<CssStyleRadzenColumnModel>
{
	#region Public and private fields, properties, constructor

	/// <summary>
	/// Constructor.
	/// </summary>
	public CssStyleRadzenColumnValidator()
	{
		RuleFor(item => item.Width)
			.NotEmpty()
			.NotNull();
	}

	#endregion
}