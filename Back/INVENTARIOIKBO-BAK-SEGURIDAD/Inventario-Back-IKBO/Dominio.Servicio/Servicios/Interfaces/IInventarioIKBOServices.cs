using Dominio.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.Servicios.Interfaces
{
    public interface IInventarioIKBOServices
    {
        ProductoDto Insertproducto(ProductoDto producto);
        List<ExistenciasDto> Existencias(ProductoDto producto);
        MvtoDto InsertEntrada(MvtoDto entrada);
        MvtoDto InsertSalida(MvtoDto salida);
        List<ProductoDto> GetAllProductos();
        List<ProductoFechaDto> GetAllProductoFechaByIdProducto(int IdProducto);

    }
}
