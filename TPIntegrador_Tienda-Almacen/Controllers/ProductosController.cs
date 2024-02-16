using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPIntegrador_Tienda_Almacen.Data; 
using TPIntegrador_Tienda_Almacen.Modelos;
using TPIntegrador_Tienda_Almacen.Repositorios;
using TPIntegrador_Tienda_Almacen.Modelos.DTOs;

namespace TPIntegrador_Tienda_Almacen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase 
    {
        private readonly IProductoRepositorio _productoRepositorio; 
        protected ResponseDto _response;

        public ProductosController(IProductoRepositorio productosRepositorio, ResponseDto response) 
        {
            _productoRepositorio = productosRepositorio; 
            _response = response ?? new ResponseDto();
        }

       
        [HttpGet] // GET: api/Productos
        
        public async Task<ActionResult<ResponseDto>> GetProductos()
        {
            try
            {
                var listaProductos = await _productoRepositorio.GetProductos(); 
                _response.Resultado = listaProductos;
                _response.Mensaje = "Lista de Productos "; 
            }
            catch (Exception e)
            {
                _response.EsExitoso = false;
                _response.MensajesError = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
            return Ok(_response);
        }
        // GET: api/Productossd/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto>> GetProducto(int id)
        {
            try
            {
                var producto = await _productoRepositorio.GetProducto(id); 
                if (producto == null)
                {
                    _response.EsExitoso = false;
                    _response.Mensaje = "Producto no existe";
                    return NotFound(_response);
                }

                _response.Resultado = producto;
                _response.Mensaje = "Info del producto "; 
            }
            catch (Exception e)
            {
                _response.EsExitoso = false;
                _response.MensajesError = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        // PUT: api/Productos
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto>> PutProducto(int id, ProductoDto productoDto) 
        {
            try
            {
                ProductoDto productoDtoActualizado = await _productoRepositorio.CrearOActualizar(productoDto, id); 
                _response.Resultado = productoDtoActualizado;
                _response.Mensaje = "Producto actualizado";
                return Ok(_response);
            }
            catch (DbUpdateConcurrencyException)
            {
                _response.EsExitoso = false;
                _response.Mensaje = "Error al actualizar producto"; 
                return BadRequest(_response);
            }
        }

        // POST: api/Productos 
        [HttpPost]
        public async Task<ActionResult<ResponseDto>> PostProducto(ProductoDto productoDto)
        {
            try
            {
                ProductoDto productoDtoActualizado = await _productoRepositorio.CrearOActualizar(productoDto); 
                _response.Resultado = productoDtoActualizado;
                _response.Mensaje = "Producto insertado en la DB"; 
                return Ok(_response);
            }
            catch (DbUpdateConcurrencyException)
            {
                _response.EsExitoso = false;
                _response.Mensaje = "Error al insertar el producto"; 
                return BadRequest(_response);
            }
        }

        // DELETE: api/Productos
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto>> DeleteProducto(int id)
        {
            try
            {
                bool estaEliminado = await _productoRepositorio.EliminarProducto(id); 
                if (estaEliminado)
                {
                    _response.Resultado = estaEliminado;
                    _response.Mensaje = $"Producto con id : {id}  eliminado de la DB"; 
                    return Ok(_response);
                }
                else
                {
                    _response.EsExitoso = false;
                    _response.Mensaje = "Error al eliminar el producto";
                    return BadRequest(_response);
                }
            }
            catch (Exception e)
            {
                _response.EsExitoso = false;
                _response.Mensaje = "Error al eliminar el producto";
                return BadRequest(_response);
            }
        }
    }
}