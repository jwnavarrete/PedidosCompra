using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.neptuno.models
{
    [Table("in_compra_det")]
    public class InCompraDet
    {
        [Key]
        public int id_compra_det { get; set; }
        public int id_compra_cab { get; set; }
        public int id_compra_cab_rel { get; set; }
        public int id_compra_det_rel { get; set; }
        public string tipo_transaccion { get; set; } = ""; // tipo [udt_tipo_tran_inv]
        public string id_numero_doc { get; set; } = ""; // tipo [udt_numero_doc]
        public int secuencia_det { get; set; }
        public string tipo_movimiento { get; set; } = ""; // tipo [udt_tipo_mov_inv]
        public int id_bodega { get; set; }
        public string moneda { get; set; } = ""; // tipo [udt_tipo_moneda]
        public int id_producto { get; set; }
        public int cantidad_unid { get; set; }
        public int cantidad_frac { get; set; }
        public int pendiente_unid { get; set; }
        public int pendiente_frac { get; set; }
        public int procesado_unid { get; set; }
        public int procesado_frac { get; set; }
        public int anulado_unid { get; set; }
        public int anulado_frac { get; set; }
        public decimal cotizacion_costeo { get; set; }
        public decimal costo_unitario_0 { get; set; }
        public decimal costo_unitario_1 { get; set; }
        public decimal costo_total_0 { get; set; }
        public decimal costo_total_1 { get; set; }
        public string estado_detalle { get; set; } = ""; // tipo [udt_estado_tran_inv]
    }
}