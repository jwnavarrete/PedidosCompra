using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.neptuno.models
{
    [Table("pr_proveedor")]
    public class PrProveedor
    {
        [Key]
        public int id_proveedor { get; set; }
        public int id_tipo_proveedor { get; set; }
        [MaxLength(1)]
        public string activo { get; set; } = "";
        public int? id_perfil { get; set; }
        public int? dias_inv { get; set; }
        public int? id_item_catal { get; set; }
        public decimal? tolerancia { get; set; }
        public int? reposicion { get; set; }
        public int? multiplo_facturacion { get; set; }
        public int? c_id_grupo_comp_pro { get; set; }
        public int? frecuencia_compra { get; set; }
        public string? proveedor_cobertura { get; set; }
        public int? items_orden_compra { get; set; }
        public string? es_artesano { get; set; }
        public string? emision_electronica { get; set; }
        public string? pago_regimen_fiscal { get; set; }
        public int? pago_residente { get; set; }
        public int? tipo_reg_fiscal { get; set; }
        public int? pais_reg_fiscal { get; set; }
        public int? pais_paraiso_fiscal { get; set; }
        public string? deno_reg_fiscal { get; set; }
        public int? pais_efectua_pago { get; set; }
        public string? aplica_convenio { get; set; }
        public string? pago_sujeto_ret { get; set; }

    }
}