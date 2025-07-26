using EmployeeManagement.BLL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace EmployeeManagement.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class usersController : Controller
    {
        [HttpGet("GetUserDetails")]
        public IActionResult GetUserDetails()
        {
            try
            {
                DataTable dt = new usersBLL().GetUserDetails();
                if (dt == null || dt.Rows.Count == 0)
                {
                    return NotFound(new { message = "No Record Found" });
                }

                string JsonResult = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(JsonResult);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetUserDetails().", ex);
            }
        }
        [HttpGet("GetEmployeeDetailsVisibleToAdmin")]
        public IActionResult GetEmployeeDetailsVisibleToAdmin(string Role)
        {
            try
            {
                DataTable dt = new usersBLL().GetEmployeeDetailsVisibleToAdmin(Role);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return NotFound(new { message = "No Record Found" });
                }

                string JsonResult = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(JsonResult);
            }
            catch (Exception ex)
            {

                throw new Exception("Error while fetching GetUserDetails().", ex);
            }
        }
    }
}
