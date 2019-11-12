using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.Cadastros
{
    public class CompanyEN
    {
        #region Properties

        [Key]
        public int IDCompanies { get; set; }
        public int IDCompany { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string NomeResponsavel { get; set; }
        public string Cpf { get; set; }

        #endregion Properties

        #region Constructor

        public CompanyEN() { }

        #endregion Constructor
    }
}
