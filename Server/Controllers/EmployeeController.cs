using blazor_wasm_sql_db.Client.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blazor_wasm_sql_db.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var list = new List<Employee>
            { 
                new Employee
                {
                    Id = 1,
                    Code = "HR1",
                    FullName = "Joe Bloggs",
                    Address = "123 New Street",
                    JoiningDate = new DateTime(2023, 12, 13)
                }
            };

            return Ok(list);
        }
    }
}
