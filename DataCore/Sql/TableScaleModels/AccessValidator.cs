﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Models;
using DataCore.Sql.Tables;

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table validation "ACCESS".
/// </summary>
public class AccessValidator : SqlTableValidator<AccessModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AccessValidator()
    {
        RuleFor(item => item.User)
	        .NotEmpty()
	        .NotNull();
        RuleFor(item => item.Rights)
	        .NotNull()
	        .LessThanOrEqualTo((byte)AccessRightsEnum.Admin)
	        .GreaterThanOrEqualTo((byte)AccessRightsEnum.None);
    }
}
