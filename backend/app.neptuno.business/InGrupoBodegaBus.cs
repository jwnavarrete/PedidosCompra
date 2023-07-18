using app.neptuno.data;
using app.neptuno.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.neptuno.business
{
    public class InGrupoBodegaBus
    {
        private InGrupoBodegaData data;

        public InGrupoBodegaBus(DataContext context)
        {
            data = new InGrupoBodegaData(context);
        }

        // consultar
        public async Task<List<InGrupoBodega>> GetAll()
        {
            return await data.GetAll();
        }

        // consultar por marca
        public async Task<InGrupoBodega> GetById(int IdGrupoBodega)
        {
            return await data.GetById(IdGrupoBodega);
        }
    }
}
