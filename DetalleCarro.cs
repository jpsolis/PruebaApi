using System.ComponentModel.DataAnnotations;

namespace PruebaApi
{
    public class DetalleCarro
    {
        [Key]
        [Required]
        public int idDetalleCarro { get; set; }
        public int CarroCompraId { get; set; }
        public CarroCompra? CarroCompra { get; set; }   
        public ICollection<Producto>? Productos { get; set; }

    }
}
