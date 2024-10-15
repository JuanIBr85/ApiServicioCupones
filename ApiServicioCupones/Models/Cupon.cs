using System.Diagnostics.Contracts;

namespace ApiServicioCupones.Models
{
    public class Cupon
    {
        public int Id_Cupon { get; set; }
        public string Nombre_Cupon { get; set; }
        public string Descripcion_Cupon { get; set; }
        public decimal PorcentajeDto_Cupon { get; set; }
        public decimal ImportePromo_Cupon { get; set; }
        public DateOnly FechaInicio_Cupo { get; set; }
        public DateOnly FechaFin_Cupon { get; set; }
        public int Id_Tipo_Cupon { get; set; }
        public bool Cupon_Actuvo {  get; set; }
    }
}
