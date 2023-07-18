namespace app.neptuno.dto
{
    public class PrProveedorDTO
    {
        public int IdProveedor { get; set; }
        public int IdTipoProveedor { get; set; }
        public string Activo { get; set; } = "";
        public string NombreCompleto { get; set; } = "";
        public string NumDocumIden { get; set; } = "";
    }
}