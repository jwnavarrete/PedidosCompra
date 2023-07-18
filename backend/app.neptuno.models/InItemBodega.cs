using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.neptuno.models
{
    [Table("in_item_bodega")]
    public class InItemBodega
    {
        [Key]
        public int id_item_bodega { get; set; }

        [Required]
        public int id_bodega { get; set; }

        [Required]
        public int id_item { get; set; }

        public string? id_ubicacion { get; set; }

        [Required]
        public int id_estado_item { get; set; }

        [Required]
        [MaxLength(1)]
        public string tipo_item { get; set; } = "";

        [Required]
        [MaxLength(1)]
        public string habilitado { get; set; } = "";

        [Required]
        public int stock_unidad { get; set; }

        [Required]
        public int stock_fraccion { get; set; }

        [Required]
        public int stk_ing_unid { get; set; }
        
        [Required]
        public int stk_ing_fracc { get; set; }

        [Required]
        public int stk_egr_unid { get; set; }

        [Required]
        public int stk_egr_fracc { get; set; }

        public int? stk_minimo { get; set; }
        public int? stk_maximo { get; set; }
        public int? stk_minimo_fra { get; set; }
        public int? stk_maximo_fra { get; set; }

        public DateTime? fecha_venc_1 { get; set; }
        public DateTime? fecha_venc_2 { get; set; }
        public DateTime? fecha_venc_3 { get; set; }
        public DateTime? fecha_ult_venta { get; set; }
        public DateTime? fecha_ult_compra { get; set; }
        public DateTime? fecha_ult_trans { get; set; }
        public DateTime? fecha_ult_ajuste { get; set; }
        public DateTime? fecha_maxmin { get; set; }

        public float? prom_ventas { get; set; }


        public string? tipo_convenio { get; set; } = "";

        public string? co_mensaje { get; set; } = "";
        public decimal? precio_ant { get; set; }  

    }
}
