using Microsoft.AspNetCore.Http;

namespace Sistema.TSTOnline.Domain.Services.Usuario
{
    public class UsuarioService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public UsuarioService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void SetUserId(int idCompany, int idUser)
        {
            if (idCompany != 0)
                _session.SetString("idCompany", idCompany.ToString());

            if (idUser != 0)
                _session.SetString("idUser", idUser.ToString());
        }

        public int GetCompanyId()
        {
            var idCompany = _session.GetString("idCompany");

            if (!string.IsNullOrEmpty(idCompany))
                return int.Parse(idCompany);
            else
                return 0;
        }

        public int GetUserId()
        {
            var idUser = _session.GetString("idUser");

            if (!string.IsNullOrEmpty(idUser))
                return int.Parse(idUser);
            else
                return 0;
        }
    }
}
