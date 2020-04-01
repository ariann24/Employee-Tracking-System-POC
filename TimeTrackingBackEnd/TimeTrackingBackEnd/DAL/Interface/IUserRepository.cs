using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrackingBackEnd.Context;

namespace TimeTrackingBackEnd.DAL.Interface
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
