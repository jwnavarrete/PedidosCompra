using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.neptuno.business;
using app.neptuno.dto;
using app.neptuno.data;

namespace app.neptuno.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoCompraController : ControllerBase
    {
        private InPedidoCompraBus bus;

        public PedidoCompraController(DataContext context)
        {
            this.bus = new InPedidoCompraBus(context);
        }

        [HttpPost]
        public async Task<ActionResult<List<InPedidoCompraDetDTO>>> GenerarDetalle(BodyPedido body)
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
                return Ok(await this.bus.GenerarDetalle(body.FechaIni, body.FechaFin, body.IdClasif1, body.Bodegas));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}