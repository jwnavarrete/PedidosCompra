using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.neptuno.dto
{
    public class InPedidoCompraDetDTO
    {
        public int IdPedidoDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdBodega { get; set; }
        public int IdItem { get; set; }
        public string BodegaCodigo { get; set; } = "";
        public string BodegaNombre { get; set; } = "";
        public int StockActual { get; set; }
        public int VentaMes { get; set; }
        public int CantidadIngresada { get; set; }         
        public string ItemDescripcion { get; set; } = "";
        public string? ItemCodigoBarra { get; set; }       
    }
}