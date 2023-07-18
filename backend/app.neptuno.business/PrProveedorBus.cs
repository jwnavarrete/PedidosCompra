using app.neptuno.data;
using app.neptuno.dto;
using app.neptuno.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.neptuno.business
{
    public class PrProveedorBus
    {
        private PrProveedorData data;

        public PrProveedorBus(DataContext context)
        {
            data = new PrProveedorData(context);
        }

        // consultar
        public async Task<List<PrProveedorDTO>> GetAll()
        {
            return await data.GetAll();
        }

        // consultar
        public async Task<PrProveedorDTO> GetOne(int IdProveedor)
        {
            return await data.GetOne(IdProveedor);
        }
    }
}
