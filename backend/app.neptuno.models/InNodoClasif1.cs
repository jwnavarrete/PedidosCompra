using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.neptuno.models
{
    [Table("in_nodo_clasif_1")]
    public class InNodoClasif1
    {
        [Key]
        public int id_nodo_clasif_1 { get; set; }
        public string codigo { get; set; } = "";
        [MaxLength(35)]
        public string descripcion {get; set; } = "";
        public int nivel {get; set; }
        [MaxLength(1)]
        public string activo { get; set ;} = "";
        public int? id_padre { get; set; }
        public string? linea_consumo { get; set; }
    }
}