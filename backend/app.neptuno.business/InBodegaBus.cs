using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.neptuno.data;
using app.neptuno.dto;

namespace app.neptuno.business
{
    public class InBodegaBus
    {
        private InBodegaData data;

        public InBodegaBus(DataContext context)
        {
            data = new InBodegaData(context);
        }

        // consultar
        public async Task<List<InBodegaDTO>> GetBodegas()
        {
            return await data.GetBodegas();
        }


        // consultar
        public async Task<InBodegaDTO> GetBodega(int IdBodega)
        {
            return await data.GetBodega(IdBodega);
        }
    }
}
