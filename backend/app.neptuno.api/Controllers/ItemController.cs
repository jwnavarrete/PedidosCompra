using app.neptuno.business;
using app.neptuno.data;
using app.neptuno.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using app.neptuno.dto;

namespace app.neptuno.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<BodegaController> _logger;
        private InItemBus busItem;

        public ItemController(ILogger<BodegaController> logger, DataContext context)
        {
            _logger = logger;
            this.busItem = new InItemBus(context);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<InItemDTO>>> Get()
        {
            return Ok(await this.busItem.GetAll());
        }

        [HttpGet("GetAllByMarca/{IdMarcaItem}")]
        public async Task<ActionResult<List<InItemDTO>>> GetAllByMarca(int IdMarcaItem)
        {
            return Ok(await this.busItem.GetAllByMarca(IdMarcaItem));
        }

        [HttpGet("GetAllByIdClasif1/{IdClasif1}")]
        public async Task<ActionResult<List<InItemDTO>>> GetAllByIdClasif1(int IdClasif1)
        {
            return Ok(await this.busItem.GetAllByIdClasif1(IdClasif1));
        }

        [HttpPost]
        public async Task<ActionResult<List<InItemDTO>>> GetItemsPedido(BodyPedido body)
        {
            if (body == null)
            {
                return BadRequest("Objeto vacio");
            }

            if (body.FechaIni == null)
            {
                return BadRequest("El campo FechaIni es requerido!");
            }

            if (body.FechaFin == null)
            {
                return BadRequest("El campo FechaFin es requerido!");
            }

            if (body.IdClasif1 == 0)
            {
                return BadRequest("El campo IdClasif1 es requerido!");
            }

            if (body.Bodegas.Count() <= 0)
            {
                return BadRequest("El campo Bodegas debe tener al menos una bodega");
            }

            try
            {
                return Ok(await this.busItem.GenerarDetalle(body.IdClasif1, body.Bodegas, body.FechaIni, body.FechaFin));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
