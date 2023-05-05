// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.TableScaleModels.ProductSeries;

/// <summary>
/// Table validation "ProductSeries".
/// </summary>
public sealed class WsSqlProductSeriesValidator : WsSqlTableValidator<WsSqlProductSeriesModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public WsSqlProductSeriesValidator() : base(true, false)
    {
        RuleFor(item => item.Sscc)
            .NotEmpty()
            .NotNull();
        RuleFor(item => item.Scale)
            .NotEmpty()
            .NotNull()
            .SetValidator(new WsSqlScaleValidator());
    }
}