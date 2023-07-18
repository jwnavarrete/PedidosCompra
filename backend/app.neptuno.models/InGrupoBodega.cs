using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.neptuno.models
{
    [Table("in_grupo_bodega")]
    public class InGrupoBodega
    {
        [Key]
        public int id_grupo_bodega { get; set; }
        [MaxLength(4)]
        [Required]
        public string codigo { get; set; } = "";
        [MaxLength(35)]
        [Required]
        public string descripcion { get; set; } = "";
        public int? id_padre { get; set; }
        [Required]
        public int nivel { get; set; }
        [MaxLength(1)]
        [Required]
        public string activo { get; set; } = "";
    }
}
