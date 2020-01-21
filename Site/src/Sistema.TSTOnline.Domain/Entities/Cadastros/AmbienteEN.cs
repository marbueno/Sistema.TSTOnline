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
        public string Matricula { get; set; }
        public string RazaoSocial { get; set; }
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

        #endregion Constructor
    }
}