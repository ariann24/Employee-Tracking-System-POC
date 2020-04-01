using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TimeTrackingBackEnd.Context;
using Xunit;

namespace TimeTrackingUnitTest
{
    public class TimeTrackingUniteTest
    {
        [Fact]
        public void GET_All_Employee_Success_Scenario()
        {
            HttpClient client = GetJWTAuthentication();
            HttpResponseMessage employeeResponse = client.GetAsync("/api/employee").Result;
            string stringEmployeeData = employeeResponse.Content.ReadAsStringAsync().Result;
            List<Employee> dataEmployee = JsonConvert.DeserializeObject<List<Employee>>(stringEmployeeData);

            List<Employee> expected = new List<Employee>();
            expected.Add(new Employee() { Active = true, ClockInTime = DateTime.Parse("30/03/2020 9:00:00 AM"), ClockOutTime = DateTime.Parse("30/03/2020 6:00:00 AM"), NameOfEmployee = "Ariann28", UserId = 1 });
            expected.Add(new Employee() { Active = true, ClockInTime = DateTime.Parse("30/03/2020 9:00:00 AM"), ClockOutTime = DateTime.Parse("30/03/2020 6:00:00 AM"), NameOfEmployee = "AriannJr", UserId = 3 });

            Assert.Equal(expected.Count, dataEmployee.Count);
        }

        [Fact]
        public void GET_All_Employee_Failing_Scenario()
        {
            HttpClient client = GetJWTAuthentication();
            HttpResponseMessage employeeResponse = client.GetAsync("/api/employee").Result;
            string stringEmployeeData = employeeResponse.Content.ReadAsStringAsync().Result;
            List<Employee> dataEmployee = JsonConvert.DeserializeObject<List<Employee>>(stringEmployeeData);

            List<Employee> expected = new List<Employee>();
            expected.Add(new Employee() { Active = false, ClockInTime = DateTime.Parse("30/03/2020 9:00:00 AM"), ClockOutTime = DateTime.Parse("30/03/2020 6:00:00 AM"), NameOfEmployee = "Ariann", UserId = 1 });
            expected.Add(new Employee() { Active = false, ClockInTime = DateTime.Parse("30/03/2020 9:00:00 AM"), ClockOutTime = DateTime.Parse("30/03/2020 6:00:00 AM"), NameOfEmployee = "AriannJr", UserId = 3 });

            Assert.NotEqual(expected, dataEmployee);
        }

        [Fact]
        public void GET_Employee_ById_Success_Scenario()
        {
            HttpClient client = GetJWTAuthentication();
            HttpResponseMessage employeeResponse = client.GetAsync("/api/employee/1").Result;
            string stringEmployeeData = employeeResponse.Content.ReadAsStringAsync().Result;
            List<Employee> dataEmployee = JsonConvert.DeserializeObject<List<Employee>>(stringEmployeeData);

            List<Employee> expected = new List<Employee>();
            expected.Add(new Employee() { Active = true, ClockInTime = DateTime.Parse("30/03/2020 9:00:00 AM"), ClockOutTime = DateTime.Parse("30/03/2020 6:00:00 AM"), NameOfEmployee = "Ariann28", UserId = 1 });

            Assert.Equal(expected.Count, dataEmployee.Count);
        }

        [Fact]
        public void GET_Employee_ById_Failing_Scenario()
        {
            HttpClient client = GetJWTAuthentication();
            HttpResponseMessage employeeResponse = client.GetAsync("/api/employee/1").Result;
            string stringEmployeeData = employeeResponse.Content.ReadAsStringAsync().Result;
            List<Employee> dataEmployee = JsonConvert.DeserializeObject<List<Employee>>(stringEmployeeData);

            List<Employee> expected = new List<Employee>();
            expected.Add(new Employee() { Active = false, ClockInTime = DateTime.Parse("30/03/2020 9:00:00 AM"), ClockOutTime = DateTime.Parse("30/03/2020 6:00:00 AM"), NameOfEmployee = "SampleEmp", UserId = 1 });

            Assert.NotEqual(expected, dataEmployee);
        }

        [Fact]
        public void Post_Employee_Success_Scenario()
        {
            HttpClient client = GetJWTAuthentication();
            Employee employeeModel = new Employee();
            employeeModel.NameOfEmployee = "Ariann";
            employeeModel.ClockInTime = DateTime.Parse("30/03/2020 9:00:00 AM");
            employeeModel.ClockOutTime = DateTime.Parse("30/03/2020 6:00:00 AM");
            employeeModel.Active = true;

            string stringData = JsonConvert.SerializeObject(employeeModel);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("/api/employee", contentData).Result;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void Post_Employee_Failing_Scenario()
        {
            HttpClient client = GetJWTAuthentication();
            Employee employeeModel = new Employee();
            employeeModel.NameOfEmployee = "Ariann";
            employeeModel.ClockInTime = DateTime.Parse("30/03/2020 9:00:00 AM");
            employeeModel.ClockOutTime = DateTime.Parse("30/03/2020 6:00:00 AM");
            employeeModel.Active = true;

            string stringData = JsonConvert.SerializeObject(employeeModel);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("/api/employee/1", contentData).Result;

            Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void Put_Employee_Success_Scenario()
        {
            HttpClient client = GetJWTAuthentication();
            Employee employeeModel = new Employee();
            employeeModel.UserId = 1;
            employeeModel.NameOfEmployee = "Ariann28";
            employeeModel.ClockInTime = DateTime.Parse("30/03/2020 9:00:00 AM");
            employeeModel.ClockOutTime = DateTime.Parse("30/03/2020 6:00:00 AM");
            employeeModel.Active = true;

            string stringData = JsonConvert.SerializeObject(employeeModel);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync("/api/employee/1", contentData).Result;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void Put_Employee_Failing_Scenario()
        {
            HttpClient client = GetJWTAuthentication();
            Employee employeeModel = new Employee();
            employeeModel.UserId = 1;
            employeeModel.NameOfEmployee = "Ariann28";
            employeeModel.ClockInTime = DateTime.Parse("30/03/2020 9:00:00 AM");
            employeeModel.ClockOutTime = DateTime.Parse("30/03/2020 6:00:00 AM");
            employeeModel.Active = true;

            string stringData = JsonConvert.SerializeObject(employeeModel);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync("/api/employee/2", contentData).Result;

            Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void Delete_Employee_Success_Scenario()
        {
            HttpClient client = GetJWTAuthentication();
            HttpResponseMessage response = client.DeleteAsync("/api/employee/7").Result;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void Delete_Employee_Failing_Scenario()
        {
            HttpClient client = GetJWTAuthentication();
            HttpResponseMessage response = client.DeleteAsync("/api/employee/79").Result;

            Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public HttpClient GetJWTAuthentication()
        {
            string baseUrl = "http://localhost:59323";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            User userModel = new User();
            userModel.UserName = "test";
            userModel.Password = "test";

            string stringData = JsonConvert.SerializeObject(userModel);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("/api/user", contentData).Result;
            string stringUserData = response.Content.ReadAsStringAsync().Result;
            User dataUser = JsonConvert.DeserializeObject<User>(stringUserData);

            // client.DefaultRequestHeaders.Authorization =
            // new AuthenticationHeaderValue("Basic", dataUser.Token);

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + dataUser.Token);

            return client;
        }
    }
}
