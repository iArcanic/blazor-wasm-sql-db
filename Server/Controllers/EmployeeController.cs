using blazor_was_sql_db.Server.Data;
using blazor_wasm_sql_db.Client.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blazor_wasm_sql_db.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Employee>>> GetEmployees(int id)
        {
            var dbEmployee = await _context.Employees.FindAsync(id);

            if (dbEmployee == null)
            {
                return NotFound("This Employee does not exist!");
            }
            
            return Ok(dbEmployee);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployees(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return await GetAllEmployees();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployees(int id, Employee employee)
        {
            var dbEmployee = await _context.Employees.FindAsync(id);

            if (dbEmployee == null)
            {
                return NotFound("This Employee does not exist!");
            }

            dbEmployee.Id = employee.Id;
            dbEmployee.Code = employee.Code;
            dbEmployee.FullName = employee.FullName;
            dbEmployee.Address = employee.Address;
            dbEmployee.JoiningDate = employee.JoiningDate;

            _context.Add(dbEmployee);
            await _context.SaveChangesAsync();

            return await GetAllEmployees();
        }
    }
}
