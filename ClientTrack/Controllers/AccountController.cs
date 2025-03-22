using Microsoft.AspNetCore.Mvc;


namespace ClientTrack.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult    ForgotPass()
        {
            return View();
        }
    }
}
