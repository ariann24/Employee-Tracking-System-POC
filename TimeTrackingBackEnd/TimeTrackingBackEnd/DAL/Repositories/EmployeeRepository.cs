using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrackingBackEnd.Context;
using TimeTrackingBackEnd.DAL.Interface;

namespace TimeTrackingBackEnd.DAL.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MainDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
