using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCRUD.Shared.Models
{
    public class Paginacions
    {
        public int Pagina { get; set; } = 1;
        public int CantidadAMostrar { get; set; } = 5;
    }
}
