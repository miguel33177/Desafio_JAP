using Microsoft.AspNetCore.Mvc;
using DesafioJAP.Data;
using DesafioJAP.Models;
using Microsoft.EntityFrameworkCore;
using DesafioJAP.Services;

namespace DesafioJAP.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // get clientes
        public async Task<IActionResult> Index()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return View(clientes);
        }
        //get create
        public IActionResult Create()
        {
            ViewBag.CategoriasCartaConducao = new List<string> { "A", "B", "B1", "C", "D", "E" };
            return View(new Cliente());
        }

        //post create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,Email,Telefone,CartaConducao")] Cliente cliente)
        {
            if (ClientesValidator.EmailExiste(_context, cliente.Email))
            {
                ModelState.AddModelError("Email", "O email já está registado. Por favor, insira um email diferente.");
                ViewBag.CategoriasCartaConducao = new List<string> { "A", "B", "B1", "C", "D", "E" };
                return View(cliente);
            }

            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // get delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes.FirstOrDefaultAsync(v => v.Id == id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // post delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}