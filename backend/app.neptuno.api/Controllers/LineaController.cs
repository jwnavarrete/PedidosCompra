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
    public class LineaController : ControllerBase
    {
        private InNodoClasif1Bus bus;

        public LineaController(DataContext context){
            this.bus = new InNodoClasif1Bus(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<InNodoClasif1DTO>>> GetAll(){
            return  Ok(await this.bus.GetAll());
        }
    }
}