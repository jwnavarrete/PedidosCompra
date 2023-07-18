using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.neptuno.models
{
    [Table("in_venta_det")]
    public class InVentaDet
    {
        [Key]
        public int id_venta_det { get; set; }
        public int id_venta_cab { get; set; }
        public int id_venta_cab_rel { get; set; }
        public int id_venta_det_rel { get; set; }
        [MaxLength(3)]
        public string tipo_transaccion { get; set; } = "";
        [MaxLength(25)]
        public string id_numero_doc { get; set; } = "";
        public int secuencia_det { get; set; }
        [MaxLength(1)]
        public string tipo_movimiento { get; set; } = "";
        public int id_bodega { get; set; }
        public decimal moneda { get; set; }
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
        [MaxLength(3)]
        public string estado_detalle { get; set; } = "";


    }
}
