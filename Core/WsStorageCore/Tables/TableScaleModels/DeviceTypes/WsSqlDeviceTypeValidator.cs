// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.Tables.TableScaleModels.DeviceTypes;

/// <summary>
/// Table validation "DEVICES_TYPES".
/// </summary>
public sealed class WsSqlDeviceTypeValidator : WsSqlTableValidator<WsSqlDeviceTypeModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="isCheckIdentity"></param>
    public WsSqlDeviceTypeValidator(bool isCheckIdentity) : base(isCheckIdentity, true, true)
    {
        RuleFor(item => item.Name)
            .NotEmpty()
            .NotNull();
        RuleFor(item => item.PrettyName)
            .NotEmpty()
            .NotNull();
        RuleFor(item => item.Description)
            .NotNull();
    }
}