// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DeviceControl.Pages;

public sealed partial class NavMenu : RazorComponentBase
{
    #region Public and private fields, properties, constructor

    private bool CollapseNavMenu { get; set; } = true;

    private static LocaleDeviceControl LocaleBlazor { get; } = LocaleDeviceControl.Instance;

    #endregion

    #region Public and private methods

    private void ToggleNavMenu()
    {
        CollapseNavMenu = !CollapseNavMenu;
    }

    #endregion
}
