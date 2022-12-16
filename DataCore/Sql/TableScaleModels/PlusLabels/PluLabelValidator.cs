﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Tables;
using FluentValidation.Results;

namespace DataCore.Sql.TableScaleModels.PlusLabels;

/// <summary>
/// Table validation "PLUS_LABELS".
/// </summary>
public class PluLabelValidator : SqlTableValidator<PluLabelModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public PluLabelValidator()
    {
        RuleFor(item => item.PluScale)
            .NotEmpty()
            .NotNull();
        RuleFor(item => item.Zpl)
            .NotEmpty()
            .NotNull();
        RuleFor(item => item.ProductDt)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(new DateTime(2020, 01, 01));
        RuleFor(item => item.ExpirationDt)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(item => item.ProductDt);
    }

    protected override bool PreValidate(ValidationContext<PluLabelModel> context, ValidationResult result)
    {
        switch (context.InstanceToValidate)
        {
            case null:
                result.Errors.Add(new(nameof(context), "Please ensure a model was supplied!"));
                return false;
            default:
                if (!PreValidateSubEntity(context.InstanceToValidate.PluWeighing, ref result))
                    return result.IsValid;
                return result.IsValid;
        }
    }
}