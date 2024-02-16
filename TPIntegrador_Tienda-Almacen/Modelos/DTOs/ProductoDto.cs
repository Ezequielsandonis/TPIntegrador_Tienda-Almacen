using System.ComponentModel.DataAnnotations;

namespace TPIntegrador_Tienda_Almacen.Modelos.DTOs
{
    public class ProductoDto
    {
        [Key]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
