using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.netMVCCoreWithEFCore.Models;
using Microsoft.Extensions.Logging;

namespace Asp.netMVCCoreWithEFCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;
        private readonly ILogger _logger;
        public EmployeeController(EmployeeContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _context.Employees.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                throw;
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await _context.Employees
                    .FirstOrDefaultAsync(m => m.EmployeeId == id);

                if (employee == null)
                {
                    return NotFound();

                }

                return View(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                throw;
            }
        }

        public IActionResult CreateorUpdate(int id=0)
        {
            try
            {
                _logger.LogInformation("Log message in the CreateorUpdate(id=" + id + ") method");
                if (id == 0)
                    return View(new Employee());
                else
                    return View(_context.Employees.Find(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                throw;
            }
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateorUpdate([Bind("EmployeeId,FullName,EmpCode,Designation,OfficeLocations")] Employee employee)
        {
            try
            {
                _logger.LogInformation("Log message in the CreateorUpdate(EmployeeId=" + employee.EmployeeId+ "FullName=" + employee.FullName+ " EmpCode" + employee.EmpCode+ ") method");
                //check whether modelstate is valid
                if (ModelState.IsValid)
                {
                    if (employee.EmployeeId == 0)
                        _context.Add(employee);
                    else
                        _context.Update(employee);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Log message end in CreateorUpdate()");
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                throw;
            }
           
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                _logger.LogInformation("Log message in the Delete(id=" + id + ") method");
                var employee = await _context.Employees.FindAsync(id);
                _context.Remove(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                throw;
            }
        }
    }
}
