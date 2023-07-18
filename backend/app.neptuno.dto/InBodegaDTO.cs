using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.neptuno.dto
{
    public class InBodegaDTO
    {
        public int IdBodega { get; set; }
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Activo { get; set; } = "";
        public string? NombreCompleto { get; set; }

    }
}
