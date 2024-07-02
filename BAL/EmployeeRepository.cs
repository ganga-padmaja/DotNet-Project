using Microsoft.EntityFrameworkCore;
using WebAPIDBFirstApproach.Models;

namespace WebAPIDBFirstApproach.BAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IndustryDbContext _context;
        public EmployeeRepository(IndustryDbContext industryDbContext)
        {
            _context = industryDbContext;
        }

        public List<Employee> GetAllEmployees() => _context.Employees.ToList();
        public void AddEmployee(Employee Employee)

        {

            try

            {

                // _context.Employee.Add(Employee);

                _context.Entry(Employee).State = EntityState.Added;

                _context.SaveChanges();

            }

            catch (Exception ex)

            {

                string str = ex.Message;

            }

        }

        public void UpdateEmployee(Employee Employee)

        {

            _context.Entry(Employee).State = EntityState.Modified;

            try

            {

                _context.SaveChanges();

            }

            catch (DbUpdateConcurrencyException)

            {

                throw;

            }

        }

        public void DeleteEmployee(Employee Employee)
        {
            _context.Employees.Remove(Employee);
            _context.SaveChanges();
        }
        public Employee GetById(int id) => _context.Employees.Find(id);
    }
}
   


