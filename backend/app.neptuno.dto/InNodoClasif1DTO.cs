using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.neptuno.dto
{
    public class InNodoClasif1DTO
    {
        public int IdNodoClasif1 { get; set; }
        public string Codigo { get; set; } = "";
        public string Descripcion {get; set; } = "";
        public int Nivel {get; set; }
        public string Activo { get; set ;} = "";
        public int? IdPadre { get; set; }
        public string? LineaConsumo { get; set; }
        public List<InNodoClasif1DTO> children { get; set; }

        // constructor
        public InNodoClasif1DTO(){
            this.children = new List<InNodoClasif1DTO>();
        }
    }
}