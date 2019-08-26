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

        public static Task MostrarMensaje(this IJSRuntime js, string titulo, string mensaje ,TipoMensajeSweetAlert tipo)
        {
            return js.InvokeAsync<object>("Swal.fire", titulo, mensaje, tipo.ToString());
        }

        public async static Task<bool> Confirm(this IJSRuntime js, string titulo, string mesaje, TipoMensajeSweetAlert tipo)
        {
            return await js.InvokeAsync<bool>("CustomConfirm", titulo , mesaje, tipo.ToString());
        }

        public enum TipoMensajeSweetAlert
        {
            question, warning, error, success, info
        }
    }
}
