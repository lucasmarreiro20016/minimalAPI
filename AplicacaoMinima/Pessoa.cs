using System.ComponentModel.DataAnnotations;

namespace AplicacaoMinima
{
    public class Pessoa
    {
        [Key]
        public int Id_pessoa { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}
