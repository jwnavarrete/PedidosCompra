using app.neptuno.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.neptuno.data
{
    public class InGrupoBodegaData
    {
        private readonly DataContext context;

        public InGrupoBodegaData(DataContext context)
        {
            this.context = context;
        }

        // consultar
        public async Task<List<InGrupoBodega>> GetAll()
        {
            return await context.GrupoBodega.ToListAsync();
        }

        // consultar por marca
        public async Task<InGrupoBodega> GetById(int IdGrupoBodega)
        {
            return await context.GrupoBodega.Where(q => q.id_grupo_bodega == IdGrupoBodega).FirstAsync();
        }
    }
}
