using CRUDContatos.Data;
using CRUDContatos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 
        // GET: /Contato/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Contato/Criar
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var contato = _context.Contato.Find(id);
            if (contato == null)
                return NotFound();

            // Mapeia para o model de edição
            var model = new ContatoCriacaoEdicao
            {
                Nome = contato.Nome,
                TelefonePessoal = contato.TelefonePessoal,
                TelefoneComercial = contato.TelefoneComercial,
                Empresa = contato.Empresa,
                ListaEmails = contato.Emails?.Split(';')
            };

            ViewBag.ContatoId = contato.Id;
            return View(model);
        }

        // POST: /Contato/Editar/5
        [HttpPost]
        public IActionResult Editar(int id, ContatoCriacaoEdicao model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ContatoId = id;
                return View(model);
            }

            var contato = _context.Contato.Find(id);
            if (contato == null)
                return NotFound();

            contato.Nome = model.Nome;
            contato.TelefonePessoal = model.TelefonePessoal;
            contato.TelefoneComercial = model.TelefoneComercial;
            contato.Empresa = model.Empresa;
            contato.Emails = model.ListaEmails != null ? string.Join(";", model.ListaEmails) : null;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /// POST: /Contato/Criar
        [HttpPost]
        public IActionResult CriarContato(ContatoCriacaoEdicao contatoCriacaoEdicao)
        {
            if (!ModelState.IsValid)
                return View("Criar", contatoCriacaoEdicao);

            Contato novoContato = new Contato()
            {
                Nome = contatoCriacaoEdicao.Nome,
                TelefonePessoal = contatoCriacaoEdicao.TelefonePessoal,
                TelefoneComercial = contatoCriacaoEdicao.TelefoneComercial,
                Empresa = contatoCriacaoEdicao.Empresa,
                Emails = contatoCriacaoEdicao.ListaEmails != null ? string.Join(";", contatoCriacaoEdicao.ListaEmails) : null
            };

            _context.Contato.Add(novoContato);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // aqui vai ser adicionado o número da página e a string para o campo de filtro ambos não obrigatórios
        [HttpGet]
        public IActionResult Listar()
        {
            return Json(_context.Contato.ToList());
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var contato = _context.Contato.Find(id);
            if (contato == null)
                return NotFound();

            _context.Contato.Remove(contato);
            _context.SaveChanges();
            return Ok();
        }
    }
}