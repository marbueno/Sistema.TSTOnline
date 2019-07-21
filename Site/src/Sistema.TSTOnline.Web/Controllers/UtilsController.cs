using Sistema.Competicao.Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Sistema.Competicao.Web.Areas.Admin.Controllers
{
    public class UtilsController : Controller
    {
        public JsonResult ListarMeses()
        {
            return Json(Helper.ListarMeses());
        }
    }
}