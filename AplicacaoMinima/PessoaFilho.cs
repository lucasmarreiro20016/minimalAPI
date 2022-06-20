using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoMinima
{
    public class PessoaFilho
    {
        [Key]
        public int IdPessoaFilho { get; set; }

        [ForeignKey("IdPessoa")]
        public virtual Pessoa IdPessoa { get; set; }

        public string Nome { get; set; }
        public string Parentesco { get; set; }
        public int Idade { get; set; }
        public string Ocupacao { get; set; }
        public float? Renda { get; set; }
    }
}
