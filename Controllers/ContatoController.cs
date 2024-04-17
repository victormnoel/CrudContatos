using CrudContatos.Models;
using CrudContatos.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ContatoService _contatoService;
        public ContatoController(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Contato>? allContatos = await _contatoService.GetAllAsync();

            return View(allContatos);
        }

        [HttpGet]
        public async Task<ActionResult<Contato>> Details(Guid id)
        {
            Contato? contato = await _contatoService.GetByIdAsync(id);

            return View(contato);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contato novoContato)
        {
            novoContato.Id = Guid.NewGuid();
            await _contatoService.CreateAsync(novoContato);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Contato? contato = await _contatoService.GetByIdAsync(id);
            if (contato != null)
                return View(contato);
            else
                return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Contato contatoAtualizado)
        {
            await _contatoService.UpdateAsync(id, contatoAtualizado);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _contatoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
