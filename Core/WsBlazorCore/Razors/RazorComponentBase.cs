// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Radzen;
using WsBlazorCore.Settings;
using WsStorageCore.Helpers;
using WsStorageCore.Models;
using WsStorageCore.Utils;

namespace WsBlazorCore.Razors;

public partial class RazorComponentBase : LayoutComponentBase
{
    #region Public and private fields, properties, constructor

    #region Inject

    [Inject] protected DialogService? DialogService { get; set; }
    [Inject] protected IJSRuntime? JsRuntime { get; set; }
    [Inject] protected NavigationManager? NavigationManager { get; set; }
    [Inject] protected NotificationService? NotificationService { get; set; }
    [Inject] protected IHttpContextAccessor? HttpContextAccess { get; set; }

    #endregion

    #region Constants

    public WsSqlContextManagerHelper ContextManager => WsSqlContextManagerHelper.Instance;
    public WsSqlContextCacheHelper ContextCache => WsSqlContextCacheHelper.Instance;
    public HttpContext? HttpContext => HttpContextAccess?.HttpContext;
    protected BlazorAppSettingsHelper BlazorAppSettings => BlazorAppSettingsHelper.Instance;

    #endregion

    #region Parameters
    
    [CascadingParameter] private Task<AuthenticationState>? AuthenticationStateTask { get; set; }
    [Parameter] public RazorFieldConfigModel RazorFieldConfig { get; set; }
    [Parameter] public Guid? IdentityUid { get; set; }
    [Parameter] public long? IdentityId { get; set; }

    [Parameter]
    public string IdentityUidStr
    {
        get => IdentityUid?.ToString() ?? Guid.Empty.ToString();
        set => IdentityUid = Guid.TryParse(value, out Guid uid) ? uid : Guid.Empty;
    }

    [Parameter] public string Title { get; set; }
    [Parameter] public WsSqlCrudConfigModel SqlCrudConfigItem { get; set; }

    #endregion

    [Parameter] public WsSqlTableBase? SqlItem { get; set; }
    
    public ClaimsPrincipal? User { get; set; }
    
	public RazorComponentBase()
	{
        Title = string.Empty;

		SqlItem = null;
        RazorFieldConfig = new();
        SqlCrudConfigItem = WsSqlCrudConfigUtils.GetCrudConfigItem(WsSqlIsMarked.ShowAll);
    }

    #endregion

    protected override async Task OnInitializedAsync()
    {
        if (AuthenticationStateTask is not null)
        {
            AuthenticationState authState = await AuthenticationStateTask;
            User = authState?.User;
        }
    }
}
