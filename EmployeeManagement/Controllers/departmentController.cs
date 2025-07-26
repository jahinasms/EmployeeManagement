using EmployeeManagement.BLL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;

namespace EmployeeManagement.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class departmentController : Controller
    {
        [HttpGet("GetDepartmentDistributionCount")]
        public IActionResult GetDepartmentDistributionCount()
        {
            try
            {
                DataTable dt = new departmentBLL().GetDepartmentDistributionCount();
                if (dt == null || dt.Rows.Count == 0)
                {
                    return NotFound(new { message = "No Record Found" });
                }

                string JsonResult = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(JsonResult);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetDepartmentDistributionCount().", ex);
            }
        }
        [HttpPost("AddNewDepartment")]
        public int AddNewDepartment(string departmentName)
        {
            try
            {
                int result = new departmentBLL().AddNewDepartment(departmentName);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Error while fetching AddNewDepartment().", ex);
            }
        }


        #region[======================= Recent Activities ==============================]

        [HttpGet("GetRecentActivites")]
        public IActionResult GetRecentActivites()
        {
            try
            {
                DataTable dt = new departmentBLL().GetRecentActivites();
                if (dt == null || dt.Rows.Count == 0)
                {
                    return NotFound(new { message = "No Record Found" });
                }

                string JsonResult = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(JsonResult);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetRecentActivites().", ex);
            }
        }

        [HttpPost("AddNewACtivite")]
        public int AddNewACtivite(int empId, string activity)
        {
            try
            {
                int result = new departmentBLL().AddNewACtivite(empId, activity);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Error while fetching AddNewACtivite().", ex);
            }
        }
        #endregion

        #region [================================== Employee Reports ===================] 
        [HttpGet("EmployeePDF")]
        public IActionResult GetEmployeeDetailsAndDepartmentPDF()
        {
            try
            {
                var pdfBytes = new departmentBLL().EmployeeDetailsAndDepartmentPDF();

                return File(pdfBytes, "application/pdf", "EmployeeReport.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Error generating PDF report: {ex.Message}");
            }
        }
        [HttpGet("GetEmployeeSalaryData")]
        public IActionResult GetEmployeeSalaryData()
        {
            try
            {
                var pdfBytes = new departmentBLL().GetEmployeeSalaryData();

                return File(pdfBytes, "application/pdf", "EmployeeReport.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Error generating PDF report: {ex.Message}");
            }
        }
        [HttpGet("GetEmployeeAttandanceReport")]
        public IActionResult GetEmployeeAttandanceReport(string empName)
        {
            try
            {
                var pdfBytes = new departmentBLL().GetEmployeeAttandanceReport(empName);

                return File(pdfBytes, "application/pdf", "EmployeeReport.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Error generating PDF report: {ex.Message}");
            }
        }
        #endregion
        [HttpGet("GetEmployeeStatsReport")]
        public IActionResult GetEmployeeStatsReport()
        {
            try
            {
                DataTable dt = new departmentBLL().GetEmployeeStatsReport();
                if (dt == null || dt.Rows.Count == 0)
                {
                    return NotFound(new { message = "No Record Found" });
                }

                string JsonResult = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(JsonResult);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetEmployeeStatsReport().", ex);
            }
        }

    }
}
