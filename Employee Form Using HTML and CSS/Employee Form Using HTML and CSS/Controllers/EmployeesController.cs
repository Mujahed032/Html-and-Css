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
            try
            {
                List<Employee> employees = await _context.employees.ToListAsync();

                if (employees == null)
                {
                    ModelState.AddModelError("", "Error retrieving employee data.");
                    return View();
                }

                return View(employees);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request.");
                return View();
            }
           
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {

            if (!ModelState.IsValid)
            {
                return  View(employee);
            }

            try
            {
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

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while adding the employee.");
                return View(employee);
            }
           
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var employee = await _context.employees.FirstOrDefaultAsync(x => x.Id == id);

                if (employee != null)
                {
                    var result = new Employee()
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Email = employee.Email,
                        Salary = employee.Salary,
                        DateOfBirth = employee.DateOfBirth,
                        Department = employee.Department
                    };

                    return View("Edit", result);
                }

                ModelState.AddModelError("", "Employee not found.");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("", "An error occurred while retrieving employee data.");
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
                if (!ModelState.IsValid)
                {
                    return View(employee);
                }

                try
                {
                    var result = await _context.employees.FindAsync(employee.Id);

                    if (result != null)
                    {
                        result.Name = employee.Name;
                        result.Email = employee.Email;
                        result.Salary = employee.Salary;
                        result.DateOfBirth = employee.DateOfBirth;
                        result.Department = employee.Department;

                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError("", "Employee not found.");
                    return View(employee);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while updating the employee.");
                    return View(employee); 
                }
        }

    }
}
