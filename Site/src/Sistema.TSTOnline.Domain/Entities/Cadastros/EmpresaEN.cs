using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.Cadastros
{    
    public class EmpresaEN
    {
        #region Properties

        [Key]
        public int IDEmpresa { get; set; }
        public string NrMatricula { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        #endregion Properties

        #region Constructor

        public EmpresaEN() { }

        #endregion Constructor
    }
}