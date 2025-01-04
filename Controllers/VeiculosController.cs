using Microsoft.AspNetCore.Mvc;
using DesafioJAP.Data;
using DesafioJAP.Models;
using Microsoft.EntityFrameworkCore;
using DesafioJAP.Services;

namespace Desafio_JAP.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }
        // get veiculo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Veiculos.ToListAsync());
        }
        // get create veiculo
        public IActionResult Create()
        {
            return View(new Veiculo());
        }

        // create veiculo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Matricula,AnoFabrico,TipoCombustivel,Disponivel")] Veiculo veiculo)
        {
             if (!VeiculosValidator.ValidarAnoFabrico(veiculo.AnoFabrico))
            {
                ModelState.AddModelError("AnoFabrico", "O ano de fabrico não pode ser posterior ao ano atual.");
            }

            if (VeiculosValidator.MatriculaExiste(_context, veiculo.Matricula))
            {
                ModelState.AddModelError("Matricula", "A matrícula já está registada. Por favor, insira uma matrícula diferente.");
            }
            
            if (ModelState.IsValid)
            {
                _context.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }

        // get delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var veiculo = await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == id);
            if (veiculo == null) return NotFound();

            return View(veiculo);
        }

        // post delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        { 
            var veiculo = await _context.Veiculos.FindAsync(id);

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoExists(int id)
        {
            return _context.Veiculos.Any(v => v.Id == id);
        }

    }
}