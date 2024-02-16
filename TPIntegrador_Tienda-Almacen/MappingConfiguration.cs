using TPIntegrador_Tienda_Almacen.Modelos.DTOs;
using AutoMapper;
using TPIntegrador_Tienda_Almacen.Modelos;

namespace TPIntegrador_Tienda_Almacen
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(Config =>
            {
                Config.CreateMap<ProductoDto, Producto>();
                Config.CreateMap<Producto, ProductoDto>();
            } );

            return mappingConfig;
        }
    }
}
