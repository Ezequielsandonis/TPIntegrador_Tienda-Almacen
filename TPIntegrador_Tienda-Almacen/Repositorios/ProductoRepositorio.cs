using TPIntegrador_Tienda_Almacen.Data;
using TPIntegrador_Tienda_Almacen.Modelos;
using TPIntegrador_Tienda_Almacen.Modelos.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace TPIntegrador_Tienda_Almacen.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly AplicationDbContext _context;
        private IMapper _mapper;

        public ProductoRepositorio(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductoDto> CrearOActualizar(ProductoDto productoDto, int id = 0)
        {
            Producto producto = _mapper.Map<ProductoDto, Producto>(productoDto);
            if (id > 0)
            {
                producto.Id = id;
                _context.Productos.Update(producto);
            }
            else
            {
                await _context.Productos.AddAsync(producto);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Producto, ProductoDto>(producto);
        }

        public async Task<bool> EliminarProducto(int id)
        {
            try
            {
                Producto producto = await _context.Productos.FindAsync(id);
                if (producto == null)
                {
                    return false;
                }
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<ProductoDto>> GetProductos()
        {
            List<Producto> productos = await _context.Productos.ToListAsync();
            return _mapper.Map<List<ProductoDto>>(productos);
        }

        public async Task<ProductoDto> GetProducto(int id)
        {
            Producto producto = await _context.Productos.FindAsync(id);
            return _mapper.Map<ProductoDto>(producto);
        }
    }
}
