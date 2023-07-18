using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.neptuno.dto
{
    public class InItemDTO
    {
        public int IdItem { get; set; }
        public string Descripcion { get; set; } = "";
        public string? CodBarra { get; set; }
        public decimal Precio { get; set; }
        public string TipoItem { get; set; } = "";
        public string? AplicaIva { get; set; }
        public List<InItemBodegaDTO> ItemXBodega { get; set; }

        public InItemDTO()
        {
            this.ItemXBodega = new List<InItemBodegaDTO>();
        }
    }
}