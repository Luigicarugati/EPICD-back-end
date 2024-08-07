using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoliziaApp.DAO;
using PoliziaApp.Models;
using Microsoft.Extensions.Configuration;

namespace PoliziaApp.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleDAO _verbaleDAO;
        private readonly AnagraficaDAO _anagraficaDAO;
        private readonly TipoViolazioneDAO _tipoViolazioneDAO;

        public VerbaleController(IConfiguration configuration)
        {
            _verbaleDAO = new VerbaleDAO(configuration);
            _anagraficaDAO = new AnagraficaDAO(configuration);
            _tipoViolazioneDAO = new TipoViolazioneDAO(configuration);
        }

        public IActionResult Index()
        {
            var verbali = _verbaleDAO.GetAll();
            return View(verbali);
        }

        public IActionResult Create()
        {
            ViewBag.Anagrafiche = new SelectList(_anagraficaDAO.GetAll(), "IdAnagrafica", "Cognome");
            ViewBag.TipiViolazioni = new SelectList(_tipoViolazioneDAO.GetAll(), "IdViolazione", "Descrizione");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                _verbaleDAO.Add(verbale);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Anagrafiche = new SelectList(_anagraficaDAO.GetAll(), "IdAnagrafica", "Cognome", verbale.IdAnagrafica);
            ViewBag.TipiViolazioni = new SelectList(_tipoViolazioneDAO.GetAll(), "IdViolazione", "Descrizione", verbale.IdViolazione);
            return View(verbale);
        }

        public IActionResult Edit(int id)
        {
            var verbale = _verbaleDAO.GetAll().FirstOrDefault(v => v.IdVerbale == id);
            if (verbale == null)
            {
                return NotFound();
            }
            ViewBag.Anagrafiche = new SelectList(_anagraficaDAO.GetAll(), "IdAnagrafica", "Cognome", verbale.IdAnagrafica);
            ViewBag.TipiViolazioni = new SelectList(_tipoViolazioneDAO.GetAll(), "IdViolazione", "Descrizione", verbale.IdViolazione);
            return View(verbale);
        }

        [HttpPost]
        public IActionResult Edit(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                _verbaleDAO.Update(verbale);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Anagrafiche = new SelectList(_anagraficaDAO.GetAll(), "IdAnagrafica", "Cognome", verbale.IdAnagrafica);
            ViewBag.TipiViolazioni = new SelectList(_tipoViolazioneDAO.GetAll(), "IdViolazione", "Descrizione", verbale.IdViolazione);
            return View(verbale);
        }

        public IActionResult Delete(int id)
        {
            var verbale = _verbaleDAO.GetAll().FirstOrDefault(v => v.IdVerbale == id);
            if (verbale == null)
            {
                return NotFound();
            }
            return View(verbale);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _verbaleDAO.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
