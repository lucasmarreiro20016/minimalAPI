using System.ComponentModel.DataAnnotations;

namespace AplicacaoMinima
{
    public class Pessoa
    {
        [Key]
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Ocupacao { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Identidade { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string TipoMoradia { get; set; }
        public float? ValorAluguel { get; set; }
        public bool BolsaFamilia { get; set; }
        public bool BeneficioINSS { get; set; }
        public bool Aposentadoria { get; set; }
        public bool Autonoma { get; set; }
        public float? RendaFamiliar { get; set; }
        public DateTime? DataUltimaCesta { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
