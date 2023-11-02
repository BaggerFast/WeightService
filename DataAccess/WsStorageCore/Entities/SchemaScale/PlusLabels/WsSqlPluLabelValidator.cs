namespace WsStorageCore.Entities.SchemaScale.PlusLabels;

/// <summary>
/// Table validation "PLUS_LABELS".
/// </summary>
public sealed class WsSqlPluLabelValidator : WsSqlTableValidator<WsSqlPluLabelEntity>
{

    public WsSqlPluLabelValidator(bool isCheckIdentity) : base(isCheckIdentity, true, true)
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
        RuleFor(item => item.PluWeighing)
            .SetValidator(new WsSqlPluWeighingValidator(isCheckIdentity)!);
    }
}