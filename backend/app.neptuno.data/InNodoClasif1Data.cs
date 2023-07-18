using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app.neptuno.dto;

namespace app.neptuno.data
{
    public class InNodoClasif1Data
    {
        private readonly DataContext context;

        public InNodoClasif1Data(DataContext context){
            this.context = context;
        }

        public async Task<List<InNodoClasif1DTO>> GetAll(){            
            var query = from q in this.context.NodoClasif1 
            select new InNodoClasif1DTO {
                IdNodoClasif1 = q.id_nodo_clasif_1,
                Codigo = q.codigo,
                Descripcion = q.descripcion,
                Nivel = q.nivel,
                Activo = q.activo,
                IdPadre = q.id_padre,
                LineaConsumo = q.linea_consumo
            };

            return await query.ToListAsync();            
        }
    }
}