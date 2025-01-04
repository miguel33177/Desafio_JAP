using System.Threading.Tasks;
using DesafioJAP.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioJAP.Services
{
    public static class VeiculosValidator
    {
        public static bool ValidarAnoFabrico(int anoFabrico)
        {
            return anoFabrico <= DateTime.Now.Year;
        }

        public static bool MatriculaExiste(AppDbContext context, string matricula)
        {
            return context.Veiculos.Any(v => v.Matricula == matricula);
        }
    }
}