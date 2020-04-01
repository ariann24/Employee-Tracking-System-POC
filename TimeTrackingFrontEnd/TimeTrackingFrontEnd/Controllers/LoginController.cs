using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackingFrontEnd.Models;
using TimeTrackingFrontEnd.Services;

namespace TimeTrackingFrontEnd.Controllers
{
    public class LoginController : Controller
    {
        private LoginService loginService;

        public LoginController()
        {
            loginService = new LoginService();
        }

        // GET: Login
        public ActionResult EnterLogIn(Login login)
        {
            GlobalModels.client_http = loginService.GetJWTAuthentication(login.Username, login.Password);
            if (login.Username != null || login.Password != null)
            {
                var token = loginService.GetToken(login.Username, login.Password);

                if (token != null)
                {
                    HttpContext.Session.SetString("token", token);
                    ViewBag.Message = "User logged in successfully!";
                    return RedirectToAction("Main", "Main");
                }
                else
                {
                    ViewBag.Message = "Wrong username or password!";
                }
            }
            else
            {
               // ViewBag.Message = "Please enter username and password";
            }

            return View();
        }
    }
}