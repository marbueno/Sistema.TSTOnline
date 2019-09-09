using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.Cadastros
{    
    public class EmpresaEN
    {
        #region Properties

        [Key]
        public int IDEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        #endregion Properties

        #region Constructor

        public EmpresaEN() { }

        #endregion Constructor
    }
}