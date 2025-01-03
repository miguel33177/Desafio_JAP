using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioJAP.Models
{
    public class ContratoAluguer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, selecione um cliente.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Por favor, selecione um veículo.")]
        public int VeiculoId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "Por favor, insira a quilometragem inicial.")]
        [Range(0, long.MaxValue, ErrorMessage = "A quilometragem deve ser um número positivo.")]
        public long Km { get; set; }

        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
