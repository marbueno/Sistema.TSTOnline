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
        public void SetUserId(int idUser)
        {
            if (idUser != 0)
                _session.SetString("idUser", idUser.ToString());
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
