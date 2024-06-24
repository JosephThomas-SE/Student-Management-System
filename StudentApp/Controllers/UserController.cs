using Microsoft.AspNetCore.Mvc;
using StudentApp.Data;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            var validUser = _context.Users
                .FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

            if (validUser != null)
            {
                // Clear session data upon successful login
                HttpContext.Session.Clear();

                // Redirect to the Student Index if login is successful
                return RedirectToAction("Index", "Student");
            }

            // Set error message
            ViewData["ErrorMessage"] = "Invalid username or password. Please try again ... ";

            // Clear the model state to prevent retaining invalid inputs
            ModelState.Clear();

            // Return the view with the model to display errors
            return View(user);
        }

        //// GET: User/Logout
        //public IActionResult Logout()
        //{
        //    // Clear the session
        //    HttpContext.Session.Clear();

        //    // Redirect to the Login page
        //    return RedirectToAction("Login");
        //}
    }
}
