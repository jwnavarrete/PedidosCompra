using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.neptuno.models
{
    [Table("in_bodega")]
    public class InBodega
    {
        [Key]
        [Required]
        public int id_bodega { get; set; }
        [MaxLength(5)]
        [Required]
        public string codigo { get; set; } = "";
        [MaxLength(25)]
        [Required]
        public string nombre { get; set; } = "";
        [MaxLength(35)]
        [Required]
        public string direccion { get; set; } = "";
        [Required]
        public int id_grupo_bodega { get; set; }
        [MaxLength(35)]
        public string? telefono { get; set; }
        [MaxLength(120)]
        public string? observacion { get; set; }
        [MaxLength(15)]
        public string? ruc { get; set; }
        [MaxLength(10)]
        public string? id_zona { get; set; }
        public int? id_ciudad { get; set; }
        [Required]
        public decimal venta_objetiva { get; set; }
        [Required]
        public decimal produc_objetiva { get; set; }
        [Required]
        public double porcentaje_objetivo { get; set; }
        [Required]
        public decimal venta_equivalente { get; set; }
        [Required]
        public double productividad { get; set; }
        public DateTime? fecha_ult_calculo { get; set; }
        public int? id_closeup { get; set; }
        [MaxLength(1)]
        [Required]
        public string activo { get; set; } = "";
        [MaxLength(15)]
        [Required]
        public string aud_ing_usuario { get; set; } = "";
        [MaxLength(15)]
        [Required]
        public string aud_ing_estacion { get; set; } = "";
        [Required]
        public DateTime aud_ing_fecha_hora { get; set; }
        [MaxLength(15)]
        [Required]
        public string aud_mod_usuario { get; set; } = "";
        [MaxLength(15)]
        [Required]
        public string aud_mod_estacion { get; set; } = "";
        [Required]
        public DateTime aud_mod_fecha_hora { get; set; }
        public int? id_tipo_cliente_def { get; set; }
        [MaxLength(1)]
        public string? tipo_bodega { get; set; }
        public int? zona { get; set; }
        [MaxLength(3)]
        public string? codigo_switch { get; set; }
        [MaxLength(200)]
        public string? ruta_entrada_switch { get; set; }
        [MaxLength(200)]
        public string? ruta_resp_switch { get; set; }
        [MaxLength(2)]
        public string? tipo_pos { get; set; }
        [MaxLength(200)]
        public string? url_extreme { get; set; }
        [MaxLength(10)]
        public string? codigo_extreme { get; set; }
        [MaxLength(10)]
        public string? tipo_cadena { get; set; }
        public DateTime? fecha_inicio_pca { get; set; }
        public DateTime? fecha_fin_pca { get; set; }
        [MaxLength(4)]
        public string? hora_inicio_pca { get; set; }
        [MaxLength(4)]
        public string? hora_fin_pca { get; set; }
        [MaxLength(7)]
        public string? dias_pca { get; set; }
        [MaxLength(1)]
        public string? aplica_pca { get; set; }
        [MaxLength(80)]
        public string? direccion_larga { get; set; }
        [MaxLength(1)]
        public string? se_liquida { get; set; }
        [MaxLength(5)]
        public string? cod_bodega_mc { get; set; }
        [MaxLength(30)]
        public string? codigo_localidad { get; set; }
        [MaxLength(3)]
        public string? secuencia_bodega { get; set; }
        public int? numero_estaciones { get; set; }
        [MaxLength(65)]
        public string? nombre_largo { get; set; }
        [MaxLength(100)]
        public string? nombre_comercial { get; set; }
        [MaxLength(30)]
        public string? clave_asignada { get; set; }
        public int? id_propietario { get; set; }
        [MaxLength(10)]
        public string? cod_cadena { get; set; }
        public string? id_parroquia { get; set; }
        [MaxLength(25)]
        public string? rue { get; set; }
        [MaxLength(1)]
        public string? conciliando_rec_su { get; set; }
        [MaxLength(1)]
        public string? conciliando_disp_su { get; set; }

    }
}
