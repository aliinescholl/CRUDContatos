namespace CRUDContatos.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        /// <summary>
        /// Os emails são armazenados em uma string separada por ";" e só podem ser adicionados a partir do método AdicionarEmail.
        /// </summary>
        private string? ListaEmails { get; set; }
        public string? TelefonePessoal { get; set; }
        public string? TelefoneComercial { get; set; }
        public string? Empresa { get; set; }

        public string[] ObterEmails()
        {
            return ListaEmails?.Split(';') ?? Array.Empty<string>();
        }

        public void AdicionarEmail(string email)
        {
            if (string.IsNullOrEmpty(ListaEmails))           
                ListaEmails = email;
            else
                ListaEmails += ";" + email;
        }
    }
}
