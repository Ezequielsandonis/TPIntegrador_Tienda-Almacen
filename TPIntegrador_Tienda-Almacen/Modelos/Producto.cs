
using System.ComponentModel.DataAnnotations;


namespace TPIntegrador_Tienda_Almacen.Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
