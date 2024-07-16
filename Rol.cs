using System.ComponentModel.DataAnnotations;

namespace PruebaApi
{
    public class Rol
    {
        [Key]
        public int idRol { get; set; }
        public string rolDescripcion { get; set; } = String.Empty;
    }
}
