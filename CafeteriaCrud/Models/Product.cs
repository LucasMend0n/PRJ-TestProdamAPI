using System.ComponentModel.DataAnnotations;

namespace CafeteriaCrud.Models
{
    public class Product
    {
        [Key()]
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário um nome para o produto!")]
        [MaxLength(255,ErrorMessage = "Tamanho do nome incompatível!") ]
        public string Name { get; set; }
        [Required(ErrorMessage = "É necessário uma descrição para o produto!")]
        [MaxLength(300, ErrorMessage = "Tamanho da descrição incompatível!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "É necessário informar a marca do produto!")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "É necessário um valor para o produto!")]
        public double Price { get; set; }
        
    }
}
