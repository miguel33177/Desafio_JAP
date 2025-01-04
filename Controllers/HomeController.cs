using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Desafio_JAP.Models;
using DesafioJAP.Data;
using Microsoft.EntityFrameworkCore;

namespace Desafio_JAP.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var totalVeiculos = await _context.Veiculos.CountAsync();
        var totalClientes = await _context.Clientes.CountAsync();
        var contratosAtivos = await _context.ContratosAluguer.CountAsync(c => c.DataFim > DateTime.Now);

        ViewData["TotalVeiculos"] = totalVeiculos;
        ViewData["TotalClientes"] = totalClientes;
        ViewData["ContratosAtivos"] = contratosAtivos;

        return View();
    }
}
