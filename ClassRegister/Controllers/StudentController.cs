using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegister.Controllers
{
    public class StudentController : Controller
    {
        [Authorize(Roles = Models.Roles.Student)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
