using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.neptuno.dto
{
    public class InVentaDetDTO
    {
        public int IdVentaDet { get; set; }
        public int IdVentaCab { get; set; }
        public int SecuenciaDet {get; set; }
        public int IdBodega { get; set; }
        public int IdProducto {get; set; }
        public int CantidadUnidad { get; set; }
        public int CantidadFrac { get; set; }
        public decimal CostoUnitario0 { get; set; }
        public decimal CostoUnitario1 { get; set; }
        public decimal CostoTotal0 { get; set; }
        public decimal CostoTotal1 { get; set; }
    }
}