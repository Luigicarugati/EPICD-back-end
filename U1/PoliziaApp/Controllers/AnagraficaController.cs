using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PoliziaApp.DAO;
using PoliziaApp.Models;

namespace PoliziaApp.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaDAO _anagraficaDAO;

        public AnagraficaController(IConfiguration configuration)
        {
            _anagraficaDAO = new AnagraficaDAO(configuration);
        }

        public IActionResult Index()
        {
            var anagrafiche = _anagraficaDAO.GetAll();
            return View(anagrafiche);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _anagraficaDAO.Add(anagrafica);
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }

        public IActionResult Edit(int id)
        {
            var anagrafica = _anagraficaDAO.GetAll().FirstOrDefault(a => a.IdAnagrafica == id);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Anagrafica anagrafica)
        {
            if (id != anagrafica.IdAnagrafica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _anagraficaDAO.Update(anagrafica);
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }

        public IActionResult Delete(int id)
        {
            var anagrafica = _anagraficaDAO.GetAll().FirstOrDefault(a => a.IdAnagrafica == id);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _anagraficaDAO.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
