using Sistema.TSTOnline.Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Sistema.TSTOnline.Web.Areas.Admin.Controllers
{
    public class UtilsController : Controller
    {
        public JsonResult ListarMeses()
        {
            return Json(Helper.ListarMeses());
        }
        public JsonResult ListarEstados()
        {
            return Json(Helper.ListarEstados());
        }
    }
}