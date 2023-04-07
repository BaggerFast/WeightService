// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCore.Sql.TableScaleModels.BarCodes;

/// <summary>
/// Table validation "BARCODES".
/// </summary>
[DebuggerDisplay("{nameof(BarCodeValidator)}")]
public sealed class BarCodeValidator : WsSqlTableValidator<BarCodeModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public BarCodeValidator() : base(true, true)
    {
        RuleFor(item => item.TypeTop)
            //.NotEmpty()
            .NotNull();
        RuleFor(item => item.ValueTop)
            //.NotEmpty()
            .NotNull();
        RuleFor(item => item.TypeRight)
            //.NotEmpty()
            .NotNull();
        RuleFor(item => item.ValueRight)
            //.NotEmpty()
            .NotNull();
        RuleFor(item => item.TypeBottom)
            //.NotEmpty()
            .NotNull();
        RuleFor(item => item.ValueBottom)
            //.NotEmpty()
            .NotNull();
    }
}
