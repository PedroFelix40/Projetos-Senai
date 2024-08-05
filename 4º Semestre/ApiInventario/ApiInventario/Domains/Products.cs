using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiInventario.Domains
{
    [Table("Product")]
    public class Products
    {
        [Key]
        public Guid IdProduct { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string? Name { get; set; }


        [Column(TypeName = "DECIMAL(18, 2)")]
        [Required(ErrorMessage = "O preço é obrigatório!")]
        public decimal? Price { get; set; }
    }
}
