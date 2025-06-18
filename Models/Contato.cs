namespace CRUDContatos.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        /// <summary>
        /// Os emails são armazenados em uma string separada por ";" e só podem ser adicionados a partir do método AdicionarEmail.
        /// </summary>
        public string? Emails { get; set; }
        public string? TelefonePessoal { get; set; }
        public string? TelefoneComercial { get; set; }
        public string? Empresa { get; set; }
    }
}
