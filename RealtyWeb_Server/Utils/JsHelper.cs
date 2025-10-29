using Microsoft.JSInterop;

namespace RealtyWeb_Server.Utils
{
    public static class JsHelper
    {
        public static async ValueTask NotyfSuccess(this IJSRuntime js, string alertText) 
        {
            await js.InvokeVoidAsync("DisplayNotyf", "success", alertText);
        }
        public static async ValueTask NotyfError(this IJSRuntime js, string alertText)
        {
            await js.InvokeVoidAsync("DisplayNotyf", "error", alertText);
        }
    }
}
