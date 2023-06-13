// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsLabelCore.Common;

/// <summary>
/// Базовый класс помощника плагина.
/// </summary>
#nullable enable
[DebuggerDisplay("{ToString()}")]
public class WsPluginBaseHelper : WsBaseHelper
{
    #region Public and private fields and properties

    /// <summary>
    /// Тип плагина.
    /// </summary>
    protected WsEnumPluginType PluginType { get; init; }
    protected WsPluginModel ReopenItem { get; }
    protected WsPluginModel RequestItem { get; }
    protected WsPluginModel ResponseItem { get; }
    protected int ReopenCounter => ReopenItem.SafeCounter;
    protected int RequestCounter => RequestItem.SafeCounter;
    protected int ResponseCounter => ResponseItem.SafeCounter;

    #endregion

    #region Constructor and destructor

    protected WsPluginBaseHelper()
    {
        PluginType = WsEnumPluginType.Default;
        ReopenItem = new() { Config = new(waitExecute: 0_250, waitClose: 0_250) };
        RequestItem = new() { Config = new(waitExecute: 0_250, waitClose: 0_250) };
        ResponseItem = new() { Config = new(waitExecute: 0_250, waitClose: 0_250) };
    }

    #endregion

    #region Public and private methods

    public override string ToString() => $"{PluginType} | {ReopenItem} | {RequestItem} | {ResponseItem}";

    #endregion
}