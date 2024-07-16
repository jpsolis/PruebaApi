using System.ComponentModel.DataAnnotations;

namespace PruebaApi
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; } = string.Empty;
        public string passUsuario { get; set; } = string.Empty;
        public Rol? rolUsuario { get; set; }
    }
}
