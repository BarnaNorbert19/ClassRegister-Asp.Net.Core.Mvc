using ClassRegister.Common;
using ClassRegister.Data;
using ClassRegister.Models;
using ClassRegister.Models.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hosting = Microsoft.AspNetCore.Hosting;

namespace ClassRegister.Controllers
{

    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {

        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly Hosting.IHostingEnvironment _environment;
        private const int _itemsPerPage = 4;

        public AdminController(ILogger<AdminController> logger, ApplicationDbContext db, Hosting.IHostingEnvironment environment)
        {
            _logger = logger;
            _db = db;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return Redirect("Admin/Home");
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Courses()
        {
            return View();
        }

        public IActionResult LoadUsers(int page = 1)
        {
            var users = (from persons in _db.Person
                                      join accounts in _db.Account
                                      on persons.Id equals accounts.Id
                                      orderby persons.Firstname
                                      select new UserModel { UserInfo = persons, UserAccount = accounts }).Skip((page - 1) * _itemsPerPage).Take(_itemsPerPage);

            return PartialView("_LoadUsers", users);
        }

        public IActionResult LoadUsersPageNavigation(int page = 1)
        {
            var userCount = (from persons in _db.Person
                         join accounts in _db.Account
                         on persons.Id equals accounts.Id
                         orderby persons.Firstname
                         select new UserModel { UserInfo = persons, UserAccount = accounts }).Count();

            var navigation = new NavigationModel(userCount, 1, _itemsPerPage, page);

            return PartialView("_LoadPageNavigation", navigation);
        }

        [HttpPost]
        public IActionResult AddUser(UserModel input)
        {
            try
            {
                input.IsInputSecure();
            }
            catch (Exception ex)
            {
                _logger.LogError(ErrorMessages.AddUser + ": " + ex.ToString());
                return Redirect("Users");
            }

            if (!input.GenerateUserData())
            {
                TempData["Error"] = "Invalid data was provided.";
                return Redirect("Users"); ;
            }

            try
            {
                _db.Add(input.UserInfo);
                _db.Add(input.UserAccount);

                _db.SaveChanges();

                _logger.LogInformation($"User was created: {input.UserAccount.Id}, {input.UserAccount.LoginName} - by: {User.Identity.Name}");
            }

            catch (Exception ex)
            {
                _logger.LogError($"{ErrorMessages.AddUser}: exeption: {ex} - by: {User.Identity.Name}");
                TempData["Error"] = ErrorMessages.AddUser;

                return Redirect("Users");
            }

            return Redirect("Users");
        }

        public IActionResult DeleteUser(string id)
        {
            var user = (from persons in _db.Person
                         join accounts in _db.Account
                         on persons.Id equals accounts.Id
                         where persons.Id == id
                         select new UserModel { UserInfo = persons, UserAccount = accounts }).FirstOrDefault();

            if (user is null)
            {
                TempData["Error"] = "User was not found.";
                return Redirect("/Admin/Users");
            }

            _ = _db.Remove(user.UserInfo);
            _ = _db.SaveChanges();

            _logger.LogInformation($"User deleted successfully: {user.Id}, {user.UserAccount.LoginName} - by: {User.Identity.Name}");

            return Redirect("/Admin/Users");
        }

        [HttpPost]
        public IActionResult EditUser(UserModel input)
        {
            try
            {
                input.IsInputSecure();
            }
            catch (Exception ex)
            {
                _logger.LogError(ErrorMessages.EditUser + ": " + ex.ToString());
                return BadRequest();
            }

            var user = (from persons in _db.Person
                         join accounts in _db.Account
                         on persons.Id equals accounts.Id
                         where persons.Id == input.Id
                         select new UserModel { UserInfo = persons, UserAccount = accounts }).FirstOrDefault();

            Helper.MergeObjects<Account>(user.UserAccount, input.UserAccount);
            Helper.MergeObjects<Person>(user.UserInfo, input.UserInfo);

            _db.SaveChanges();

            return Redirect("/Admin/Users");
        }

        [HttpPost]
        public IActionResult UploadUsers(IFormFile usersFile)
        {
            if (usersFile is null)
            {
                TempData["Error"] = "An error occured while uploading the file";
                return Redirect("/Admin/Users");
            }

            string ext = usersFile.FileName.Split('.')[^1];

            if (!IsUploadedFileValid(usersFile, 10000000, ext, "xlsx", "txt"))
                return Redirect("/Admin/Users");

            ReadStream(usersFile.OpenReadStream(), ext);

            return Redirect("/Admin/Users");
        }

        [HttpPost]
        private bool IsUploadedFileValid(IFormFile file, int maxBytes, string extension, params string[] supportedExts)
        {

            if (!supportedExts.Contains(extension))
            {
                TempData["Error"] = "File type is not supported";
                return false;
            }

            if (file.Length > maxBytes)
            {
                TempData["Error"] = "File is too large";
                return false;
            }

            return true;
        }

        private void ReadStream(Stream stream, string extension)
        {
            PostedFileReader pfr = new(stream, extension);

            var text = pfr.GetLines();
        }

        public IActionResult LoadCourses()
        {
            var courses = _db.Course.ToList();

            return PartialView("_LoadCourses", courses);
        }

        public IActionResult ManageCourse()
        {
            return View();
        }

    }
}
