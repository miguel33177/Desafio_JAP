using System.Threading.Tasks;
using DesafioJAP.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioJAP.Services
{
  public static class ClientesValidator
{
    public static bool EmailExiste(AppDbContext context, string email, int? clienteId = null)
    {
        if (clienteId.HasValue)
        {
            return context.Clientes.Any(c => c.Email == email && c.Id != clienteId);
        }
        return context.Clientes.Any(c => c.Email == email);
    }
}

}
