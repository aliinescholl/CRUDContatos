using System.Text.Encodings.Web;
using CRUDContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDContatos.Controllers
{
    public class ContatoController : Controller
    {
        // 
        // GET: /HelloWorld/
        public string Index()
        {
            return "This is my default action...";
        }

        // GET: /Contatos/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: /Contatos/Create
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            if (ModelState.IsValid)
            {
                // Salve o contato no banco (adicione a lógica aqui)
                // _context.Contato.Add(contato);
                // _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contato);
        }
    }
}
