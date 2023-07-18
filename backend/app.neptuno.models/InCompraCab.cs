using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.neptuno.models
{
    [Table("in_compra_cab")]
    public class InCompraCab
    {
        [Key]
        public int id_compra_cab { get; set; }
        public int id_compra_cab_rel { get; set; }
        public string tipo_transaccion { get; set; } = ""; // tipo udt_tipo_tran_inv
        public string id_numero_doc { get; set; } = ""; // tipo udt_numero_doc]
        public int id_bodega { get; set; }
        public string tipo_movimiento { get; set; } = "";  // tipo [udt_tipo_mov_inv]
        public DateTime fecha { get; set; }
        public string descripcion { get; set; } = ""; // tipo udt_descripcion]
        public string moneda { get; set; } = ""; // tipo [udt_tipo_moneda]
        public string estado_documento { get; set; } = ""; // tipo udt_estado_tran_inv]
        public decimal cotizacion_costeo { get; set; }
        public decimal costo_total_0 { get; set; }
        public decimal costo_total_1 { get; set; }
        public string? observacion { get; set; }
        public string? motivo_anulacion { get; set; }
        public string? observacion_anulacion { get; set; } // tipo udt_observacion
        public string? aud_emit_usuario { get; set; } // tipo [udt_nombre_corto]
        public string? aud_emit_estacion { get; set; } // tipo udt_nombre_corto
        public DateTime? aud_emit_fecha_hora { get; set; }
        public string? aud_ulpr_usuario { get; set; } // tipo [udt_nombre_corto]
        public string? aud_ulpr_estacion { get; set; } // tipo udt_nombre_corto
        public DateTime? aud_ulpr_fecha_hora { get; set; }
        public string? aud_ptot_usuario { get; set; } // tipo udt_nombre_corto
        public string? aud_ptot_estacion { get; set; } // tipo [udt_nombre_corto]
        public DateTime? aud_ptot_fecha_hora { get; set; }
        public string? aud_anul_usuario { get; set; } // tipo udt_nombre_corto
        public string? aud_anul_estacion { get; set; } /// tipo udt_nombre_corto
        public DateTime? aud_anul_fecha_hora { get; set; }
        public string? aud_elim_usuario { get; set; } // tipo [udt_nombre_corto]
        public string? aud_elim_estacion { get; set; } // tipo udt_nombre_corto
        public DateTime? aud_elim_fecha_hora { get; set; }
    }
}
