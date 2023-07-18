using app.neptuno.models;
using app.neptuno.dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.neptuno.data
{
    public class PrProveedorData
    {
        private readonly DataContext context;

        public PrProveedorData(DataContext context)
        {
            this.context = context;
        }

        // consultar
        public async Task<List<PrProveedorDTO>> GetAll()
        {
            return await context.Proveedor
                .Join(context.Ente, ai => ai.id_proveedor, al => al.id_ente, (ai, al) => new
                {
                    id_proveedor = ai.id_proveedor,
                    id_tipo_proveedor = ai.id_tipo_proveedor,
                    activo = ai.activo,
                    nombre_completo = al.nombre_completo,
                    num_docum_iden = al.num_docum_iden
                }).Where(x => x.activo == "S")
                 .Select(x => new PrProveedorDTO()
                 {
                     IdProveedor = x.id_proveedor,
                     IdTipoProveedor = x.id_tipo_proveedor,
                     Activo = x.activo,
                     NombreCompleto = x.nombre_completo,
                     NumDocumIden = x.num_docum_iden
                 })
                 .ToListAsync();
        }

        // consultar
        public async Task<PrProveedorDTO> GetOne(int IdProveedor)
        {
            return await context.Proveedor
                .Join(context.Ente, ai => ai.id_proveedor, al => al.id_ente, (ai, al) => new
                {
                    id_proveedor = ai.id_proveedor,
                    id_tipo_proveedor = ai.id_tipo_proveedor,
                    activo = ai.activo,
                    nombre_completo = al.nombre_completo,
                    num_docum_iden = al.num_docum_iden
                }).Where(x => x.activo == "S" && x.id_proveedor == IdProveedor)
                 .Select(x => new PrProveedorDTO()
                 {
                     IdProveedor = x.id_proveedor,
                     IdTipoProveedor = x.id_tipo_proveedor,
                     Activo = x.activo,
                     NombreCompleto = x.nombre_completo,
                     NumDocumIden = x.num_docum_iden
                 })
                 .FirstAsync();
        }
    }
}