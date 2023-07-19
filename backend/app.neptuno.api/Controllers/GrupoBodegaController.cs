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
    public class GrupoBodegaController : ControllerBase
    {
       private InGrupoBodegaBus _busInGrupoBodegaBus;

        public GrupoBodegaController(DataContext context){
            this._busInGrupoBodegaBus = new InGrupoBodegaBus(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<InGrupoBodegaDTO>>> GetAll(){
            return  Ok(await this._busInGrupoBodegaBus.GetAll());
        } 

        [HttpGet("bodegas")]
        public async Task<ActionResult<List<InGrupoBodegaDTO>>> GetAllNodes(){
            return  Ok(await this._busInGrupoBodegaBus.GetAllNodes());
        } 
    }
}