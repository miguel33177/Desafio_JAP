using System.ComponentModel.DataAnnotations;

namespace DesafioJAP.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, insira o nome.")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, insira o email.")]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(9)]
        [RegularExpression(@"^[2-9][0-9]{8}$", ErrorMessage = "Por favor, insira um número de telefone válido (exemplo: 912345678).")]
        public string Telefone { get; set; }

       [Required(ErrorMessage = "Por favor, selecione uma categoria de carta de condução.")]
        public string CartaConducao { get; set; }
    }
}
