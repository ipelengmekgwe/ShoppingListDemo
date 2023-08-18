using Microsoft.JSInterop;

namespace ShoppingListDemo.Client.Helpers
{
    public static class JSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }

        public static async ValueTask ToastrWarning(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("ShowToastr", "warning", message);
        }

        public static async ValueTask ToastrInfo(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("ShowToastr", "info", message);
        }
    }
}
