using System.ComponentModel.DataAnnotations;

namespace DesafioJAP.Models
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A marca é obrigatória.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A matrícula é obrigatória.")]
        [RegularExpression(@"^[A-Z]{2}-\d{2}-[A-Z]{2}$", ErrorMessage = "A matrícula deve estar no formato correto (ex: AB-12-CD).")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "O ano de fabrico é obrigatório.")]
        [Range(1900, 9999, ErrorMessage = "Insira um ano de fabrico válido.")]
        public int AnoFabrico { get; set; }

        [Required(ErrorMessage = "O tipo de combustível é obrigatório.")]
        public string TipoCombustivel { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}