using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.neptuno.models
{
    [Table("in_producto")]
    public class InProducto
    {
        [Key]
        public int id_producto { get; set; }
        public string? presentacion { get; set; }
        public string? medida { get; set; }
        public string? concentracion { get; set; }
        public int stock_unidad { get; set; }
        public int stock_fraccion { get; set; }
        public int stk_ing_unid { get; set; }
        public int stk_ing_fracc { get; set; }
        public int stk_egr_unid { get; set; }
        public int stk_egr_fracc { get; set; }
        public int num_fraccion { get; set; }
        public string tipo_vencimiento { get; set; } = "";
        public int stk_minimo { get; set; }
        public int stk_maximo { get; set; }
        public int? id_fabricante { get; set; }
        public decimal costo_prom_0 { get; set; }
        public decimal costo_prom_1 { get; set; }
        [MaxLength(1)]
        public string generico { get; set; } = "";
        public decimal vvf { get; set; }
        public decimal pvf { get; set; }
        public int fra_minima { get; set; }
        public int fra_maxima { get; set; }
        [MaxLength(1)]
        public string restric_medica { get; set; } = "";
        [MaxLength(1)]
        public string cronico { get; set; } = "";
        [MaxLength(1)]
        public string validapreciocosto { get; set; } = "";
        public decimal costo_ult_compra { get; set;  }
        [MaxLength(1)]
        public string requiere_medico { get; set; } = "";
        [MaxLength(1)]
        public string vender_al_costo { get; set; } = "";
        [MaxLength(3)]
        public string tipo_costo { get; set; } = "";
        public DateTime? fecha_ini { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? oro { get; set; }
        public string? venta_sin_stock { get; set; }
        public string? registra_cliente { get; set; }
        public string? tipo_convenio { get; set; }
        public string? sustancias_consep { get; set; }
    }
}
