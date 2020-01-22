using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.Cadastros
{    
    public class AmbienteEN
    {
        #region Properties

        [Key]
        public int IDAmb { get; set; }
        public int IDUser { get; set; }
        public int IDCompany { get; set; }
        public string StatusAtivo { get; set; }
        public string NomeEstab { get; set; }
        public string EmailEstab { get; set; }
        public string CepEstab { get; set; }
        public string EnderecoEstab { get; set; }
        public string NumEstab { get; set; }
        public string ComplementoEstab { get; set; }
        public string BairroEstab { get; set; }
        public string CidadeEstab { get; set; }
        public string UFEstab { get; set; }
        public string TelefoneEstab { get; set; }
        public string CelularEstab { get; set; }

        #endregion Properties

        #region Constructor

        public AmbienteEN() { }

        public AmbienteEN(int IDCompany, int IDUser, string NomeEstab, string CepEstab, string EnderecoEstab, string NumEstab, string ComplementoEstab, string BairroEstab, string CidadeEstab, string UFEstab)
        {
            ValidateAndSetProperties(IDCompany, IDUser, NomeEstab, CepEstab, EnderecoEstab, NumEstab, ComplementoEstab, BairroEstab, CidadeEstab, UFEstab);
        }

        public void UpdateProperties(int IDCompany, int IDUser, string NomeEstab, string CepEstab, string EnderecoEstab, string NumEstab, string ComplementoEstab, string BairroEstab, string CidadeEstab, string UFEstab)
        {
            ValidateAndSetProperties(IDCompany, IDUser, NomeEstab, CepEstab, EnderecoEstab, NumEstab, ComplementoEstab, BairroEstab, CidadeEstab, UFEstab);
        }

        private void ValidateAndSetProperties(int IDCompany, int IDUser, string NomeEstab, string CepEstab, string EnderecoEstab, string NumEstab, string ComplementoEstab, string BairroEstab, string CidadeEstab, string UFEstab)
        {
            DomainException.When(IDCompany == 0, "Compania não informada.");
            DomainException.When(IDUser == 0, "Usuário não informado.");
            DomainException.When(string.IsNullOrEmpty(NomeEstab), "Nome do Estabelecimento não informada.");
            DomainException.When(string.IsNullOrEmpty(CepEstab), "CEP não informado.");
            DomainException.When(string.IsNullOrEmpty(EnderecoEstab), "Endereço não informado.");
            DomainException.When(string.IsNullOrEmpty(NumEstab), "Número não informado.");
            DomainException.When(string.IsNullOrEmpty(BairroEstab), "Bairro não informado.");
            DomainException.When(string.IsNullOrEmpty(CidadeEstab), "Cidade não informada.");
            DomainException.When(string.IsNullOrEmpty(UFEstab), "UF não informada.");

            this.IDCompany = IDCompany;
            this.IDUser = IDUser;
            this.StatusAtivo = "a";
            this.NomeEstab = NomeEstab;
            this.CepEstab = CepEstab;
            this.EnderecoEstab = EnderecoEstab;
            this.NumEstab = NumEstab;
            this.ComplementoEstab = ComplementoEstab;
            this.BairroEstab = BairroEstab;
            this.CidadeEstab = CidadeEstab;
            this.UFEstab = UFEstab;
        }

        #endregion Constructor
    }
}