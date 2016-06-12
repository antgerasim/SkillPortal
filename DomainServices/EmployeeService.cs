using System.Collections.Generic;
using System.Linq;
using DomainModel;
using DomainPersistance;

namespace DomainServices
{
    public interface IEmployeeService
    {
        IList<Employee> GetAll();
        Employee GetById(int id);
        void Create(Employee product);
        void Update(Employee product);
        void Delete(int id);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IList<Employee> GetAll()
        {
            return _employeeRepository.GetAll().ToList();
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public void Create(Employee product)
        {
            _employeeRepository.Create(product);
        }

        public void Update(Employee product)
        {
            _employeeRepository.Update(product);
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }
    }
}