using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.neptuno.dto
{
    public class InGrupoBodegaDTO
    {
        public int IdGrupoBodega { get; set; }        
        public string Codigo { get; set; } = "";        
        public string Descripcion { get; set; } = "";
        public int? IdPadre { get; set; }        
        public int Nivel { get; set; }
        public string Activo { get; set; } = "";
        public List<InGrupoBodegaDTO> Children { get; set; }
        public List<InBodegaDTO> Bodegas { get; set; }

        // constructor
        public InGrupoBodegaDTO(){
            this.Children = new List<InGrupoBodegaDTO>();
            this.Bodegas = new List<InBodegaDTO>();
        }
    }
}