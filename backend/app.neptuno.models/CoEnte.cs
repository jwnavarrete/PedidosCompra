using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.neptuno.models
{
    [Table("co_ente")]
    public class CoEnte
    {
        [Key]
        public int id_ente { get; set; }
        [MaxLength(65)]
        public string nombre_completo { get; set; } = "";
        [MaxLength(25)]
        public string num_docum_iden { get; set; } = "";
        public string? actividad { get; set; }
        public string? pagina_web { get; set; }
        public string? observacion { get; set; }
        public bool verificado { get; set; }
        [MaxLength(1)]
        public string activo { get; set; } = "";
        [MaxLength(1)]
        public string tipo_ente { get; set; } = "";
        public string? p_titulo { get; set; }
        public string? p_primer_nombre { get; set; }
        public string? p_segundo_nombre { get; set; }
        public string? p_primer_apellido { get; set; }
        public string? p_segundo_apellido { get; set; }
        public string? p_apellido_casada { get; set; }
        public string? p_nombres_aux { get; set; }
        public string? p_nombre_compl_aux { get; set; }
        public string? p_sexo { get; set; }
        public string? p_estado_civil { get; set; }
        public int? p_conyugue_id { get; set; }
        public string? p_conyuge_nombre { get; set; }
        public DateTime? p_fecha_nacimiento { get; set; }
        public int? p_ciudad_nacimiento { get; set; }
        public string? p_nacionalidad { get; set; }
        public string? p_profesion { get; set; }
        public int? c_represent_id { get; set; }
        public string? c_represent_nombre { get; set; }
        public int? c_id_grupo_comp { get; set; }
        public DateTime? c_fecha_constitu { get; set; }
        public bool? c_contrib_especial { get; set; }
        [MaxLength(25)]
        public string aud_ing_usuario { get; set; } = "";
        [MaxLength(25)]
        public string aug_ing_estacion { get; set; } = "";
        public DateTime aud_ing_fecha_hora { get; set; }
        [MaxLength(25)]
        public string aud_mod_usuario { get; set; } = "";
        [MaxLength(25)]
        public string aug_mod_estacion { get; set; } = "";
        public DateTime aud_mod_fecha_hora { get; set; }
        public string? aud_ver_usuario { get; set; }
        public string? aug_ver_estacion { get; set; }
        public DateTime? aud_ver_fecha_hora { get; set; }
        public string? cod_prov_zeus { get; set; }
        public int? c_numero_resolucion { get; set; }
        public int? id_ente_bmaestra { get; set; }
        public string? c_tipo_contrib { get; set; }
        public string? parte_relacionada { get; set; }
        public string? codigo_tipo_identificacion { get; set; }
        public string? es_hijo { get; set; }
    }
}