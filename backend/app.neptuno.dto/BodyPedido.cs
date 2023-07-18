using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.neptuno.dto
{
    public class BodyPedido
    {
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdClasif1 { get; set; }
        public List<int> Bodegas { get; set; }

        public BodyPedido(){
            this.Bodegas = new List<int>();
        }
    }
}