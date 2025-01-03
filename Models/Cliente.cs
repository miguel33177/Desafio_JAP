using System.ComponentModel.DataAnnotations;

namespace DesafioJAP.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telefone { get; set; }

       [Required(ErrorMessage = "Por favor, selecione uma categoria de carta de condução.")]
        public string CartaConducao { get; set; }
    }
}
