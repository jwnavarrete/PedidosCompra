using app.neptuno.models;
using app.neptuno.dto;
using Microsoft.AspNetCore.Mvc;
using app.neptuno.data;
using app.neptuno.business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app.neptuno.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private PrProveedorBus busProveedor;
        public ProveedorController(DataContext context)
        {
            busProveedor = new PrProveedorBus(context);
        }

        // GET: api/<ProveedorController>
        [HttpGet]
        public async Task<ActionResult<List<PrProveedorDTO>>> Get()
        {
            return Ok(await busProveedor.GetAll());
        }

        // GET api/<ProveedorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrProveedorDTO>> Get(int id)
        {
            return Ok(await busProveedor.GetOne(id));
        }

        // POST api/<ProveedorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProveedorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProveedorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
