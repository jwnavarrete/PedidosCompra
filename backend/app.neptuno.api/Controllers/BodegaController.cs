using app.neptuno.business;
using app.neptuno.data;
using app.neptuno.dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace app.neptuno.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodegaController : ControllerBase
    {
        private readonly ILogger<BodegaController> _logger;
        private InBodegaBus bus_Bodega;

        public BodegaController(ILogger<BodegaController> logger, DataContext context)
        {
            _logger = logger;
            this.bus_Bodega = new InBodegaBus(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<InBodegaDTO>>> Get()
        {
            return Ok(await this.bus_Bodega.GetBodegas());
        }

        [HttpGet("{IdBodega}")]
        public async Task<ActionResult<InBodegaDTO>> GetBodega(int IdBodega)
        {
            return Ok(await this.bus_Bodega.GetBodega(IdBodega));
        }
    }
}
