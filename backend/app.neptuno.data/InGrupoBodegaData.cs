using app.neptuno.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.neptuno.dto;

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
        public async Task<List<InGrupoBodegaDTO>> GetAll()
        {
            var query = from q in this.context.GrupoBodega 
            select new InGrupoBodegaDTO {
                IdGrupoBodega = q.id_grupo_bodega,
                Codigo = q.codigo,
                Descripcion = q.descripcion,
                IdPadre = q.id_padre,
                Nivel = q.nivel,
                Activo = q.activo
            };
            
            return await query.ToListAsync();
        }

        // consultar por id
        public async Task<InGrupoBodegaDTO> GetById(int IdGrupoBodega)
        {
            var query = from q in this.context.GrupoBodega 
            where q.id_grupo_bodega == IdGrupoBodega
            select new InGrupoBodegaDTO {
                IdGrupoBodega = q.id_grupo_bodega,
                Codigo = q.codigo,
                Descripcion = q.descripcion,
                IdPadre = q.id_padre,
                Nivel = q.nivel,
                Activo = q.activo
            };
            
            return await query.FirstAsync();        

        }
    }
}
