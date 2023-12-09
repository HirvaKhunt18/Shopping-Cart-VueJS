using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using VueProj.Lib;

namespace VueProj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromBody] AuthViewModel model)
        {
            if(model.UserName == "admin" && model.Password == "admin@123") { 
                return Json(new {success = true});
            }
            else
            {
                return Json(new { success = false });
            }
        }

    }
}
