using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TimeTrackingFrontEnd.Models;

namespace TimeTrackingFrontEnd.Services
{
    public class EmployeeService
    {
        public EmployeeService() { }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            HttpResponseMessage employeeResponse = GlobalModels.client_http.GetAsync("/api/employee").Result;
            string stringEmployeeData = employeeResponse.Content.ReadAsStringAsync().Result;
            IEnumerable<EmployeeModel> dataEmployee = JsonConvert.DeserializeObject<List<EmployeeModel>>(stringEmployeeData);

            return dataEmployee;
        }

        public IEnumerable<EmployeeModel> GetEmployeeById(int userId)
        {
            HttpResponseMessage employeeResponse = GlobalModels.client_http.GetAsync("/api/employee/" + userId).Result;
            string stringEmployeeData = employeeResponse.Content.ReadAsStringAsync().Result;
            List<EmployeeModel> dataEmployee = JsonConvert.DeserializeObject<List<EmployeeModel>>(stringEmployeeData);

            return dataEmployee;
        }

        public HttpStatusCode PostEmployee(EmployeeModel model)
        {
            string stringData = JsonConvert.SerializeObject(model);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = GlobalModels.client_http.PostAsync("/api/employee", contentData).Result;

            return response.StatusCode;
        }

        public HttpStatusCode PutEmployee(int userId, EmployeeModel model)
        {
            string stringData = JsonConvert.SerializeObject(model);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = GlobalModels.client_http.PutAsync("/api/employee/" + userId, contentData).Result;

            return response.StatusCode;
        }

        public HttpStatusCode DeleteEmployee(int userId)
        {
            HttpResponseMessage response = GlobalModels.client_http.DeleteAsync("/api/employee/" + userId).Result;

            return response.StatusCode;
        }
    }
}
