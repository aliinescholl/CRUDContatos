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

        // GET: /Contato/Editar
        public IActionResult Editar()
        {
            return View();
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
        public async Task<List<ContatoResumido>> BuscarContatosPaginados()
        {
            List<Contato> contatos = await _context.Contato.ToListAsync();
            List<ContatoResumido> contatosResumidos = new List<ContatoResumido>();

            foreach (Contato contato in contatos)
            {
                contatosResumidos.Add(new ContatoResumido()
                {
                    Id = contato.Id,
                    Nome = contato.Nome,
                    TelefonePessoal = contato.TelefonePessoal
                });
            }

            return contatosResumidos;
        }
    }
}
