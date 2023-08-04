// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DeviceControl.Utils;

/// <summary>
/// Утилиты Blazor.
/// </summary>
public static class WsBlazorCoreUtils
{
    #region Public and private methods

    public static string GetLibVersion()
    {
        FileVersionInfo fieVersionInfo = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
        if (string.IsNullOrEmpty(fieVersionInfo.FileVersion))
            return string.Empty;
        
        string result = fieVersionInfo.FileVersion;
        int endIndex = result.LastIndexOf(".0", StringComparison.InvariantCultureIgnoreCase);
        return endIndex != -1 ? result[..endIndex] : result;
    }

    #endregion
}