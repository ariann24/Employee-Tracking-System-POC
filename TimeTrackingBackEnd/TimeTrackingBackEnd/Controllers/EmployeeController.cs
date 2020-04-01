using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TimeTrackingBackEnd.Context;
using TimeTrackingBackEnd.DAL.Interface;

namespace TimeTrackingBackEnd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public EmployeeController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            try
            {
                var allEmployee = await _repoWrapper.Employees.FindByCondition(x => x.Active).ToListAsync();
                return Ok(allEmployee);
            }
            catch (Exception e)
            {
                return StatusCode(400, new { Error = string.Concat(e.Message, e.InnerException.Message ?? "") });
            }
        }

        // GET: api/Employee/5
        [HttpGet("{userid}", Name = "Get")]
        public async Task<ActionResult<string>> Get(int userId)
        {
            try
            {
                var employee = await _repoWrapper.Employees.FindByCondition(x => x.UserId == userId).ToListAsync();
                return Ok(employee);
            }
            catch (Exception e)
            {
                return StatusCode(400, new { Error = string.Concat(e.Message, e.InnerException.Message ?? "") });
            }
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            try
            {
                _repoWrapper.Employees.Create(employee);
                _repoWrapper.Save();

                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(400, new { Error = string.Concat(e.Message, e.InnerException.Message ?? "") });
            }
        }

        // PUT: api/Employee/5
        [HttpPut("{userId}")]
        public IActionResult Put(int userId, Employee employee)
        {
            try
            {
                if (employee.UserId != userId)
                {
                    return BadRequest();
                }

                _repoWrapper.Employees.Update(employee);
                _repoWrapper.Save();

                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(400, new { Error = string.Concat(e.Message, e.InnerException.Message ?? "") });
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            try
            {
                var employee = await _repoWrapper.Employees.FindByCondition(x => x.UserId == userId).SingleAsync<Employee>();
                _repoWrapper.Employees.Delete(employee);
                _repoWrapper.Save();

                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(400, new { Error = string.Concat(e.Message, e.InnerException.Message ?? "") });
            }
        }
    }
}
