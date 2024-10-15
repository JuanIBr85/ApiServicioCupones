using System.Diagnostics.Contracts;

namespace ApiServicioCupones.Models
{
    public class Cupon_Historial
    {
        public int Id_Cupon { get; set; }   
        public string NroCupon { get; set; }
        public DateOnly FechaUso_Cupon { get; set; }
        public string CodCliente {  get; set; }
    }
}
