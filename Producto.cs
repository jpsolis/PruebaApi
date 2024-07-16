using System.ComponentModel.DataAnnotations;

namespace PruebaApi
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        public string descripcion { get; set; } = string.Empty;
        public int precio { get; set; }

        public string imgPath { get; set; } = string.Empty;



        //public IFormFile? MyFile { get; set; }

        //public string FilePath { get; set; } = string.Empty;

        //public string FileName { get; set; } = string.Empty;
        //public string FileExtension { get; set; } = string.Empty;
        //public string MimeType { get; set; } = string.Empty;
    }
}
