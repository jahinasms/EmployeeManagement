using EmployeeManagement.BLL;
using EmployeeManagement.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace EmployeeManagement.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class EmployeeManagementController : Controller
    {
        [HttpGet("GetEmployeeDetails")]
        public IActionResult GetEmployeeDetails()
        {
            try
            {
                DataTable dt = new EmployeeManagementBLL().GetEmployeeDetails();
                if (dt == null || dt.Rows.Count == 0)
                {
                    return NotFound(new { message = "No Record Found" });
                }

                string JsonResult = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(JsonResult);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetEmployeeDetails().", ex);
            }
        }
        [HttpGet("GetSearchEmployeeDetails")]
        public IActionResult GetSearchEmployeeDetails(string search)
        {
            try
            {
                DataTable dt = new EmployeeManagementBLL().GetSearchEmployeeDetails(search);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return NotFound(new { message = "No Record Found" });
                }

                string JsonResult = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(JsonResult);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetEmployeeDetails().", ex);
            }
        }
        [HttpPost("SaveEmployeeDetails")]
        public int SaveEmployeeDetails(List<EmployeeManagementDTO> employeeList)
        {
            try
            {
                int result = new EmployeeManagementBLL().SaveEmployeeDetails(employeeList);
                return result; 
            }
            catch (Exception ex)
            {

                throw new Exception("Error while fetching SaveEmployeeDetails().", ex);
            }
        }
        [HttpGet("GetEmployeeDetailsById")]
        public IActionResult GetEmployeeDetailsById(int empId)
        {
            try
            {
                DataTable dt = new EmployeeManagementBLL().GetEmployeeDetails(empId);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return NotFound(new { message = "No Record Found" });
                }

                string JsonResult = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(JsonResult);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetEmployeeDetails().", ex);
            }
        }

        [HttpPut("UpdateEmployeeDetails")]
        public int UpdateEmployeeDetails(EmployeeManagementDTO objEmployeeManagementDTO)
        {
            try
            {
                int result = new EmployeeManagementBLL().UpdateEmployeeDetails(objEmployeeManagementDTO);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Error while fetching SaveEmployeeDetails().", ex);
            }
        }
        [HttpDelete("DeleteEmployeeDetails")]
        public int DeleteEmployeeDetails(int empId)
        {
            try
            {
                int result = new EmployeeManagementBLL().DeleteEmployeeData(empId);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Error while fetching DeleteEmployeeData().", ex);
            }
        }

        #region[ ============= Employeee Attenadance ============]
        [HttpPost("SaveAttendance")]
        public int SaveAttendance(AttendanceDTO objAttendanceDTO)
        {
            try
            {
                int result = new EmployeeManagementBLL().SaveAttendance(objAttendanceDTO);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Error while fetching SaveEmployeeDetails().", ex);
            }
        }
        #endregion


    }
}
