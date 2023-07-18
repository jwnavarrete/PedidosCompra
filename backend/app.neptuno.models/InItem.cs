using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.neptuno.models
{
    [Table("in_item")]
    public class InItem
    {
        [Key]
        [Required]
        public int id_item { get; set; }
        [Required]
        [MaxLength(35)]
        public string descripcion { get; set; } = "";
        [Required]
        [MaxLength(65)]
        public string descripcion_larga { get; set; } = "";
        [Required]
        public int id_clasif_1 { get; set; }
        [Required]
        public int id_clasif_2 { get; set; }
        [Required]
        public DateTime fecha_ingreso { get; set; }
        [Required]
        public decimal precio { get; set; }
        public string? observacion { get; set; }
        [Required]
        public int id_estado_item { get; set; }
        [MaxLength(1)]
        public string tipo_item { get; set; } = "";
        public string? aplica_iva { get; set; }
        public string? cod_barra { get; set; }
        public string? cod_barra_alterno { get; set; }
        public int? codigo_alterno_1 { get; set; }
        public string? codigo_alterno_2 { get; set; }
        [Required]
        [MaxLength(25)]
        public string aud_ing_usuario { get; set; } = "";
        [Required]
        [MaxLength(65)]
        public string aud_ing_estacion { get; set; } = "";
        [Required]
        public DateTime aud_ing_fecha_hora { get; set; }
        [Required]
        [MaxLength(25)]
        public string aud_mod_usuario { get; set; } = "";
        [Required]
        [MaxLength(25)]
        public string aud_mod_estacion { get; set; } = "";
        [Required]
        public DateTime aud_mod_fecha_hora { get; set; }
        public decimal? costo_servicio { get; set; }
        public string? aplica_ice { get; set; }
        public int? cod_ice { get; set; }
        public string? serv_electronico { get; set; }
        public decimal? porc_utilidad { get; set; }
        public string? prov_electronico { get; set; }
        public string? bajar_precios { get; set; }
        public string? bajar_descuentos { get; set; }
        public string? cod_prov_producto { get; set; }
        public string? control_cambio_precio { get; set; }
        public int? id_sector_ubicacion { get; set; }
        public int? id_iva { get; set; }
        public string? aplica_irbp { get; set; }
        public int? deducible { get; set; }
        public string? codigo_alterno_3 { get; set; }
        public int? caja_primaria { get; set; }
        public int? id_marca_item { get; set; }
        public string? cod_prod_gripe { get; set; }
        public string? aplica_exento_iva { get; set; }
        public string? aplica_no_objeto_iva { get; set; }
        public string? servicio_recaudacion { get; set; }
        public string? servicio_tarjeta { get; set; }
        public decimal? precio_fraccion { get; set; }
    }
}