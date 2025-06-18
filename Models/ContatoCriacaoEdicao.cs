using System.ComponentModel.DataAnnotations;

namespace CRUDContatos.Models
{
    public class ContatoCriacaoEdicao
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }
        public string[]? ListaEmails { get; set; }
        public string? TelefonePessoal { get; set; }
        public string? TelefoneComercial { get; set; }
        public string? Empresa { get; set; }

        public void SepararEmailsPorPontoVirgula(string emails)
        {
            ListaEmails = emails?.Split(';');
        }
    }
}
