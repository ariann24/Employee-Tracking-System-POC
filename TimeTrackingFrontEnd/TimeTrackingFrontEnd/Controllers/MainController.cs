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
    public class MainController : Controller
    {
        EmployeeService employeeService;

        public MainController()
        {
            employeeService = new EmployeeService();
        }

        // GET: Main
        public ActionResult Main(string button)
        {
            if (button == "LogOut")
            {
                GlobalModels.client_http = null;
                HttpContext.Session.Remove("token");
                ViewBag.Message = "User logged out successfully!";
                return RedirectToAction("EnterLogIn", "Login");
            }
            else
            {
                ViewData.Model = employeeService.GetAllEmployees();
            }

            if (button == "Search")
            {
                var id = Request.Form["UserId"];
                var result = int.Parse(id);
                if (result > 0)
                {
                    ViewData.Model = employeeService.GetEmployeeById(int.Parse(id));
                }
                else
                {
                    ViewData.Model = employeeService.GetAllEmployees();
                }
            }

            return View();
        }

        // GET: Main/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Main/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Main/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Main));
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Main/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Main));
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Main/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Main));
            }
            catch
            {
                return View();
            }
        }
    }
}