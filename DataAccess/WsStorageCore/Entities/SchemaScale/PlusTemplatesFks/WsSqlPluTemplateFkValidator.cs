namespace WsStorageCore.Entities.SchemaScale.PlusTemplatesFks;

/// <summary>
/// Table validation "PLUS_TEMPLATES_FK".
/// </summary>
public sealed class WsSqlPluTemplateFkValidator : WsSqlTableValidator<WsSqlPluTemplateFkEntity>
{

    public WsSqlPluTemplateFkValidator(bool isCheckIdentity) : base(isCheckIdentity, true, true)
    {
        RuleFor(item => item.Plu)
            .NotEmpty()
            .NotNull()
            .SetValidator(new WsSqlPluValidator(isCheckIdentity));
        RuleFor(item => item.Template)
            .NotEmpty()
            .NotNull()
            .SetValidator(new WsSqlTemplateValidator(isCheckIdentity));
    }
}