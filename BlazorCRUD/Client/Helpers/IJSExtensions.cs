using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorCRUD.Client.Helpers
{
    public static class IJSExtensions
    {
        public static Task GuardarComo(this IJSRuntime js, string nombreArchivo, byte[] archivo)
        {
            return js.InvokeAsync<object>("saveAsFile", nombreArchivo, Convert.ToBase64String(archivo));
        }

        public static Task MostrarMensaje(this IJSRuntime js, string mensaje)
        {
            return js.InvokeAsync<object>("Swal.fire", mensaje);
        }

        public static Task MostrarMensaje(this IJSRuntime js, string titulo, string mensaje, TipoMensajeSweetAlert tipo)
        {
            return js.InvokeAsync<object>("Swal.fire", titulo, mensaje, tipo.ToString());
        }

        public async static Task<bool> Confirm(this IJSRuntime js, string titulo, string mesaje, TipoMensajeSweetAlert tipo)
        {
            return await js.InvokeAsync<bool>("CustomConfirm", titulo, mesaje, tipo.ToString());
        }

        public static Task SetInLocalStorage(this IJSRuntime js, string key, string content)
   => js.InvokeAsync<object>(
       "localStorage.setItem",
       key, content
       );

        public static Task<string> GetFromLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>(
                "localStorage.getItem",
                key
                );

        public static Task RemoveItem(this IJSRuntime js, string key)
            => js.InvokeAsync<object>(
                "localStorage.removeItem",
                key);




        public enum TipoMensajeSweetAlert
        {
            question, warning, error, success, info
        }

    }
}
