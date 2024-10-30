

using Common.Utils.Resources;
using Common.Utils.Utils.Interface;
using Common.Utils.Constant;
using planeador.seguridad.webapi.Models;

using Dominio.Servicio.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dominio.Servicio.Servicios;

using Dominio.Servicio.Servicios.Interfaces;

namespace Inventario.IKBO.Webapi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InventarioIKBOController : ControllerBase
    {
        private readonly IInventarioIKBOServices _inventarioIKBOServices;

        public InventarioIKBOController(IInventarioIKBOServices inventarioIKBOServices)
        {
            _inventarioIKBOServices = inventarioIKBOServices;
           
        }



        [HttpPost("Existencias")]
        public async Task<IActionResult> Existencias(ProductoDto producto)
        {

            List<ExistenciasDto> result = _inventarioIKBOServices.Existencias(producto);

            ResponseModel<List<ExistenciasDto>> response = new ResponseModel<List<ExistenciasDto>>()
            {
                IsSuccess = true,
                Messages = GeneralMessages.SussefullyProcess,
                Result = result
            };

            return Ok(response);


        }

        [HttpPost("Insertproducto")]
        public async Task<IActionResult> Insertproducto(ProductoDto producto)
        {

            ProductoDto result = _inventarioIKBOServices.Insertproducto(producto);

            ResponseModel<ProductoDto> response = new ResponseModel<ProductoDto>()
            {
                IsSuccess = result.IsSucess,
                Messages = result.Message,
                Result = result
            };

            return Ok(response);


        }



        [HttpPost("InsertEntrada")]
        public async Task<IActionResult> InsertEntrada(MvtoDto entrada)
        {

            MvtoDto result = _inventarioIKBOServices.InsertEntrada(entrada);

            ResponseModel<MvtoDto> response = new ResponseModel<MvtoDto>()
            {
                IsSuccess = result.IsSucess,
                Messages = result.Message,
                Result = result
            };

            return Ok(response);


        }


        [HttpPost("InsertSalida")]
        public async Task<IActionResult> InsertSalida(MvtoDto salida)
        {

            MvtoDto result = _inventarioIKBOServices.InsertSalida(salida);

            ResponseModel<MvtoDto> response = new ResponseModel<MvtoDto>()
            {
                IsSuccess = result.IsSucess,
                Messages = result.Message,
                Result = result
            };

            return Ok(response);


        }


        [HttpGet("GetAllProductos")]
        public async Task<IActionResult> GetAllProductos()
        {

            List<ProductoDto> result = _inventarioIKBOServices.GetAllProductos();

            ResponseModel<List<ProductoDto>> response = new ResponseModel<List<ProductoDto>>()
            {
                IsSuccess = true,
                Messages = GeneralMessages.SussefullyProcess,
                Result = result
            };

            return Ok(response);


        }

        [HttpGet("GetAllProductoFechaByIdProducto/{IdProducto}")]
        public async Task<IActionResult> GetAllProductoFechaByIdProducto(int IdProducto)
        {

            List<ProductoFechaDto> result = _inventarioIKBOServices.GetAllProductoFechaByIdProducto(IdProducto);

            ResponseModel<List<ProductoFechaDto>> response = new ResponseModel<List<ProductoFechaDto>>()
            {
                IsSuccess = true,
                Messages = GeneralMessages.SussefullyProcess,
                Result = result
            };

            return Ok(response);


        }

    }
}
