using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app.neptuno.models;
using app.neptuno.dto;

namespace app.neptuno.data
{
    public class InBodegaData
    {
        private readonly DataContext context;

        public InBodegaData(DataContext context)
        {
            this.context = context;
        }

        // consultar todas las bodegas
        public async Task<List<InBodegaDTO>> GetBodegas()
        {
            // select q.id_bodega, q.codigo, q.nombre, q.activo from in_bodega q;
            var query = from q in this.context.Bodega
                        select new InBodegaDTO
                        {
                            IdBodega = q.id_bodega,
                            Codigo = q.codigo,
                            Nombre = q.nombre,
                            Activo = q.activo,
                            NombreCompleto = "[" + q.codigo + "] - " + q.nombre
                        };

            return await query.ToListAsync();
        }

        // consultar una sola bodega
        public async Task<InBodegaDTO> GetBodega(int IdBodega)
        {
            // select q.id_bodega, q.codigo, q.nombre, q.activo from in_bodega q where q.id_bodega = IdBodega;
            var query = from q in this.context.Bodega
                        where q.id_bodega == IdBodega
                        select new InBodegaDTO
                        {
                            IdBodega = q.id_bodega,
                            Codigo = q.codigo,
                            Nombre = q.nombre,
                            Activo = q.activo,
                            NombreCompleto = "[" + q.codigo + "] - " + q.nombre
                        };

            return await query.FirstAsync();
        }


        // consultar una bodega por codigo
    }
}
