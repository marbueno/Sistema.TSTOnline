using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Web.Areas.Admin.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class UtilsController : Controller
    {
        [HttpGet]
        [Route("listarMeses")]
        public JsonResult ListarMeses()
        {
            return Json(Helper.ListarMeses());
        }

        [HttpGet]
        [Route("listarEstados")]
        public JsonResult ListarEstados()
        {
            return Json(Helper.ListarEstados());
        }
    }
}