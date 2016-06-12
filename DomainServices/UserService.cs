using System;
using DomainModel;
using DomainPersistance;

namespace DomainServices
{
    public interface IUserService
    {
        Employee GetEmployeeForCurrentUser();
    }

    public class UserService : IUserService
    {
        private Guid _TEMP_TESTING_GUID = new Guid("11111111-1111-1111-1111-111111111111");

        //private Guid _TEMP_TESTING_GUID = new Guid("3623F015-72CD-475B-BF08-A606015CDA86");
        
        public Employee GetEmployeeForCurrentUser()
        {
            return new EmployeeRepository().GetEmployee(_TEMP_TESTING_GUID);
        }
    }
}