// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using WsLocalizationCore.Common;

namespace WsLocalizationCore.Models;

/// <summary>
/// Base class for localization.
/// </summary>
public class WsLocalizationBase
{
    public WsEnumLanguage Lang { get; set; } = WsEnumLanguage.Russian;
}