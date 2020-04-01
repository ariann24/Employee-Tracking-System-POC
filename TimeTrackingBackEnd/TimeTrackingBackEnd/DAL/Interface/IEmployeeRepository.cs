using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrackingBackEnd.Context;

namespace TimeTrackingBackEnd.DAL.Interface
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
    }
}
