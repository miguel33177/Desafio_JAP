using System.ComponentModel.DataAnnotations;

namespace DesafioJAP.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Matricula { get; set; }
        public int AnoFabrico { get; set; }
        public string TipoCombustivel { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}