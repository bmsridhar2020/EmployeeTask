using System.Collections.Generic;
using System.IO;
using System.Linq;
using EmployeeTask.Model;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTask.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeDataController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Employee> users = new List<Employee>();
            var fileName = "./100 Records.xlsx";
            if (!System.IO.File.Exists(fileName))
            {
                return Ok(ErrorHelper.FormatErrorMessage("FileInfoError", "File Not Exist"));
            }
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read()) //Each row of the file
                    {
                        users.Add(new Employee
                        {
                            EmpId = reader.GetValue(0).ToString(),
                            FirstName = reader.GetValue(1).ToString(),
                            LastName = reader.GetValue(2).ToString(),
                            Gender = reader.GetValue(3).ToString(),
                            Email = reader.GetValue(4).ToString(),
                            Age = reader.GetValue(5).ToString(),
                            DateOfJoining = reader.GetValue(6).ToString()
                        });
                    }
                }
            }
            return Ok(users.Skip(1));
        }        
    } 
}
