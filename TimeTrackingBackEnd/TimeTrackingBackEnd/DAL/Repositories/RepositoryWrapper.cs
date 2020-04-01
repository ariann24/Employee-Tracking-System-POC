using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrackingBackEnd.Context;
using TimeTrackingBackEnd.DAL.Interface;

namespace TimeTrackingBackEnd.DAL.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MainDbContext _repoContext;
        private IEmployeeRepository _employee;

        public IEmployeeRepository Employees
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }

                return _employee;
            }
        }

        public RepositoryWrapper(MainDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
