using WebAPIDBFirstApproach.Models;

namespace WebAPIDBFirstApproach.BAL
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();

        
        void AddEmployee(Employee Employee);
        void UpdateEmployee(Employee Employee);
        void DeleteEmployee(Employee Employee);
        Employee GetById(int id);
    }
}
