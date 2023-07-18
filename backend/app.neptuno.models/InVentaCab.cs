using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.neptuno.models
{
    [Table("in_venta_cab")]
    public class InVentaCab
    {
        [Key]
        public int id_venta_cab { get; set; }
        public int id_venta_cab_rel { get; set; }
        [MaxLength(3)]
        public string tipo_transaccion { get; set; } = "";
        [MaxLength(25)]
        public string id_numero_doc { get; set; } = "";
        public int id_bodega { get; set; }
        [MaxLength(1)]
        public string tipo_movimiento { get; set; } = "";
        public DateTime fecha { get; set; }
        [MaxLength(35)]
        public string descripcion { get; set; } = "";
        public Byte moneda { get; set; }
        [MaxLength(3)]
        public string estado_documento { get; set; } = "";
        public decimal cotizacion_costeo { get; set; }
        public decimal costo_total_0 { get; set; }
        public decimal costo_total_1 { get; set; }
        public string? observacion { get; set; }
        public string? motivo_anulacion { get; set; }
        public string? observacion_anulacion { get; set; }
        public string? aud_emit_usuario { get; set; }
        public string? aud_emit_estacion { get; set; }
        public DateTime? aud_emit_fecha_hora { get; set; }
        public string? aud_ulpr_usuario { get; set; }
        public string? aud_ulpr_estacion { get; set; }
        public DateTime? aud_ulpr_fecha_hora { get; set; }
        public string? aud_ptot_usuario { get; set; }
        public string? aud_ptot_estacion { get; set; }
        public DateTime? aud_ptot_fecha_hora { get; set; }
        public string? aud_anul_usuario { get; set; }
        public string? aud_anul_estacion { get; set; }
        public DateTime? aud_anul_fecha_hora { get; set; }
        public string? aud_elim_usuario { get; set; }
        public string? aud_elim_estacion { get; set; }
        public DateTime? aud_elim_fecha_hora { get; set; }
    }
}
