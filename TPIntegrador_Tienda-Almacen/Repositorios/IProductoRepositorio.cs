using TPIntegrador_Tienda_Almacen.Modelos.DTOs;

namespace TPIntegrador_Tienda_Almacen.Repositorios
{
    public interface IProductoRepositorio
    {
        Task<List<ProductoDto>> GetProductos();
        Task<ProductoDto> GetProducto(int id);
        Task<ProductoDto> CrearOActualizar(ProductoDto producto, int id = 0);
        Task<bool> EliminarProducto(int id);
    }
}
