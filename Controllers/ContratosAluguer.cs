using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DesafioJAP.Data;
using DesafioJAP.Models;
using Microsoft.EntityFrameworkCore;
using DesafioJAP.Services;

namespace DesafioJAP.Controllers
{
    public class ContratosAluguerController : Controller
    {
        private readonly AppDbContext _context;

        public ContratosAluguerController(AppDbContext context)
        {
            _context = context;
        }

        // get contratos
        public async Task<IActionResult> Index()
        {
            var contratos = await _context.ContratosAluguer
                .Include(c => c.Cliente)
                .Include(c => c.Veiculo)
                .ToListAsync();
            return View(contratos);
        }

        // get create contratos
        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_context.Clientes, "Id", "Nome");
            ViewBag.Veiculos = new SelectList(_context.Veiculos.Where(v => v.Disponivel == true), "Id", "Modelo");
            return View(new ContratoAluguer());
        }

        // post create contratos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ClienteId, int VeiculoId, DateTime DataInicio, DateTime DataFim, int Km)
        {
            var veiculo = await _context.Veiculos.FindAsync(VeiculoId);

            if (!ContratoAluguerValidator.ValidarDataInicio(DataInicio))
            {
                ModelState.AddModelError("DataInicio", "A data de início não pode ser anterior à data atual.");
            }

            if (!ContratoAluguerValidator.ValidarDataFim(DataFim, DataInicio))
            {
                ModelState.AddModelError("DataFim", "A data de fim deve ser posterior à data de início.");
            }
            if (!veiculo.Disponivel)
            {
                ModelState.AddModelError("", "O veículo selecionado já está alugado.");
                return View();
            }

            if (ModelState.IsValid)
            {
                var contratoAluguer = new ContratoAluguer
                {
                    ClienteId = ClienteId,
                    VeiculoId = VeiculoId,
                    DataInicio = DataInicio,
                    DataFim = DataFim,
                    Km = Km
                };

                _context.Add(contratoAluguer);
                veiculo.Disponivel = false;
                _context.Veiculos.Update(veiculo);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            else
            {
                ViewBag.Clientes = new SelectList(_context.Clientes, "Id", "Nome", ClienteId);
                ViewBag.Veiculos = new SelectList(_context.Veiculos.Where(v => v.Disponivel == true), "Id", "Modelo");
                return View();
            }


        }
        // get delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var contrato = await _context.ContratosAluguer.FirstOrDefaultAsync(v => v.Id == id);
            if (contrato == null) return NotFound();

            return View(contrato);
        }

        // post delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var contrato = await _context.ContratosAluguer.FindAsync(id);
            if (contrato == null) return NotFound();

            var veiculo = await _context.Veiculos.FindAsync(contrato.VeiculoId);
            if (veiculo != null)
            {
                veiculo.Disponivel = true;
                _context.Veiculos.Update(veiculo);
            }

            _context.ContratosAluguer.Remove(contrato);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        private bool ContratoAluguerExists(int id)
        {
            return _context.ContratosAluguer.Any(e => e.Id == id);
        }
    }
}