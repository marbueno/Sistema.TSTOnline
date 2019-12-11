using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.Cadastros
{
    public class LogoTipoEN
    {
        #region Properties

        [Key]
        public int IDLogo { get; set; }
        public string NomeReal { get; set; }
        public string Tipo { get; set; }
        public int Company { get; set; }

        #endregion Properties
    }
}
