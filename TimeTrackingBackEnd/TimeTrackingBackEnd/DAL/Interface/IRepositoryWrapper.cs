using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTrackingBackEnd.DAL.Interface
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employees { get; }
        void Save();
    }
}
