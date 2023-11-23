namespace DeviceControl.Services;

public class JsService
{
    private readonly IJSRuntime _jsRuntime;

    public JsService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ShowAlert(string message)
    {
        await _jsRuntime.InvokeVoidAsync("alert", message);
    }

    public async Task CopyTextToClipboard(string text)
    {
        await _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
    }

    public async Task RedirectBack()
    {
       await _jsRuntime.InvokeVoidAsync("goBack");
    }
}