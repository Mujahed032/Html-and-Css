using Employee_Form_Using_HTML_and_CSS.Data;
using Employee_Form_Using_HTML_and_CSS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Employee_Form_Using_HTML_and_CSS.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _context.employees.ToListAsync();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid) { return View(employee); }
            
                var result = new Employee()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department

                };

                await _context.employees.AddAsync(result);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");

            }
            
        
    }
}
