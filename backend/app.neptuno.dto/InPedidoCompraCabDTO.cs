using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.neptuno.dto
{
    public class InPedidoCompraCabDTO
    {
        public int IdPedido { get; set; }
        public string TipoPedido { get; set; } = "";
        public int IdProveedor { get; set; }
        public int IdLaboratorio { get; set; }
        public string Estado { get; set; } = "";
        public DateTime Fecha { get; set; }
        public List<InPedidoCompraDetDTO> PedidoCompraDet;

        public InPedidoCompraCabDTO(){
            this.PedidoCompraDet = new List<InPedidoCompraDetDTO>();
        }                 
    }
}