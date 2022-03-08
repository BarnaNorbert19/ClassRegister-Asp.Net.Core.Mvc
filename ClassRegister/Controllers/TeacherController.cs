using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegister.Controllers
{
    public class TeacherController : Controller
    {
        [Authorize(Roles = Models.Roles.Teacher)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
