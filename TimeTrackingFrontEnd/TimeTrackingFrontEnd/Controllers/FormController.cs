using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackingFrontEnd.Models;
using TimeTrackingFrontEnd.Services;

namespace TimeTrackingFrontEnd.Controllers
{
    public class FormController : Controller
    {
        EmployeeService employeeService;
        public FormController() 
        {
            employeeService = new EmployeeService();
        }

        // GET: Form
        public ActionResult Index(EmployeeModel model, string button)
        {
            var result = employeeService.GetEmployeeById(model.UserId);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;

            if (button == "Save")
            {
                if (result.Count() > 0)
                {
                    statusCode = employeeService.PutEmployee(model.UserId, model);

                    if (statusCode.ToString() == "OK")
                    {
                        ViewBag.Message = "Data successfuly updated!";
                        return RedirectToAction("Main", "Main");
                    }
                    else
                    {
                        return View(model);
                    }
                }
                else
                {
                    statusCode = employeeService.PostEmployee(model);

                    if (statusCode.ToString() == "OK")
                    {
                        ViewBag.Message = "Data successfuly saved!";
                        return RedirectToAction("Main", "Main");
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }

            if (button == "Delete")
            {
                statusCode = employeeService.DeleteEmployee(model.UserId);

                if (statusCode.ToString() == "OK")
                {
                    ViewBag.Message = "Data successfuly deleted!";
                    return RedirectToAction("Main", "Main");
                }
                else
                {
                    return View(model);
                }
            }

            if (button == "Clear all to save new")
            {
                model = new EmployeeModel();
                return RedirectToAction("Index", "Form");
            }
            else
            {
                View(model);
            }

            return View();
        }

        // GET: Form/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

       
    }
}