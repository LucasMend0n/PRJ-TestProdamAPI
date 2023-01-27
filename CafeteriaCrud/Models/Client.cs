using System.ComponentModel.DataAnnotations;

namespace CafeteriaCrud.Models
{
    public class Client
    {
        [Key()]
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário um nome para o cliente!")]
        [MaxLength(255,ErrorMessage ="Nome com tamanho incompatível!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "É necessário um nome para o cliente!")]
        [MaxLength(255, ErrorMessage = "Email com tamanho incompatível!")]
        public string Email { get; set; }



    }
}
