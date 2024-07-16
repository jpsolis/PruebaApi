using System.ComponentModel.DataAnnotations;

namespace PruebaApi
{
    public class CarroCompra
    {
        [Key]
        public int idCarroCompra { get; set; }
        public DetalleCarro? DetalleCarro { get; set; }
        public int totalCompra { get; set; }
    }
}
