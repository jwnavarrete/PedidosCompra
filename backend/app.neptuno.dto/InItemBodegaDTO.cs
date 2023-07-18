using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.neptuno.dto
{
    public class InItemBodegaDTO
    {
        public int IdItemBodega { get; set; }
        public int IdBodega { get; set; }
        public int IdItem { get; set; }
        public int IdEstadoItem { get; set; }
        public string Habilitado { get; set; } = "";
        public int StockUnidad { get; set; }
        public int StockFraccion { get; set; }
        public InItemDTO Item { get; set; }
        public InBodegaDTO Bodega { get; set; }
        public int StockActual { get; set; } = 0;
        public int VentaMes { get; set; } = 0;
        public int CantidadIngresada { get; set; } = 0;

        // constructor
        public InItemBodegaDTO()
        {
            this.Item = new InItemDTO();
            this.Bodega = new InBodegaDTO();
        }

    }
}