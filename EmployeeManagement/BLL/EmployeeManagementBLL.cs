using EmployeeManagement.DAL;
using EmployeeManagement.DTO;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Data;
using System.Net;

namespace EmployeeManagement.BLL
{
    public class EmployeeManagementBLL
    {

        public DataTable GetEmployeeDetails()
        {
            try
            {
                return new EmployeeManagementDAL().GetEmployeeDetails();

            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetEmployeeDetails().", ex);
            }
        }

        public DataTable GetSearchEmployeeDetails(string search)
        {
            try
            {
                if(search == null|| search == "")
                {
                    throw new Exception("Invalid Search Employee Name or Contact");
                }
                return new EmployeeManagementDAL().GetSearchEmployeeDetails(search);

            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetEmployeeDetails().", ex);
            }
        }

        public int SaveEmployeeDetails(List<EmployeeManagementDTO> employeeList)
        {
            try
            {
                if (employeeList == null || employeeList.Count == 0)
                {
                    throw new Exception("Employee list is empty.");
                }
                foreach (var objEmployeeManagementDTO in employeeList)
                {
                    if (objEmployeeManagementDTO.empName == null || objEmployeeManagementDTO.empName == "")
                    {
                        throw new Exception("Invalid Employee Name");
                    }
                    if (objEmployeeManagementDTO.empDob == DateTime.MinValue)
                    {
                        throw new Exception("Date of Birth is required.");
                    }
                    if (objEmployeeManagementDTO.empEmail == null || objEmployeeManagementDTO.empEmail == "")
                    {
                        throw new Exception("Invalid Employee Email Address");
                    }
                    if (objEmployeeManagementDTO.empPhone == null || objEmployeeManagementDTO.empPhone == "")
                    {
                        throw new Exception("Invalid Employee Phone Number");
                    }
                    if (objEmployeeManagementDTO.empAddress == null || objEmployeeManagementDTO.empAddress == "")
                    {
                        throw new Exception("Invalid Employee Address");
                    }
                    if (objEmployeeManagementDTO.empGender == null || objEmployeeManagementDTO.empGender == "")
                    {
                        throw new Exception("Invalid Employee Gender");
                    }
                    if (objEmployeeManagementDTO.empRole == null || objEmployeeManagementDTO.empRole == "")
                    {
                        throw new Exception("Invalid Employee Role");
                    }
                    if (objEmployeeManagementDTO.empSalary == null || objEmployeeManagementDTO.empSalary == "")
                    {
                        throw new Exception("Invalid Employee Salary");
                    }
                    if (objEmployeeManagementDTO.empAdharcardNumber == null || objEmployeeManagementDTO.empAdharcardNumber == "")
                    {
                        throw new Exception("Invalid Employee Adhar Card Number");
                    }
                }

                //if (objEmployeeManagementDTO.empImage == null || objEmployeeManagementDTO.empImage.Length == 0)
                //{
                //    throw new Exception("Invalid Employee Image");
                //}

                return new EmployeeManagementDAL().SaveEmployeeDetails(employeeList);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching SaveEmployeeDetails().", ex);
            }
        }
        public DataTable GetEmployeeDetails(int empId)
        {
            try
            {
                if (empId == 0)
                {
                    throw new Exception("Invalid Employee Id");
                }
                return new EmployeeManagementDAL().GetEmployeeDetails(empId);

            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetEmployeeDetails().", ex);
            }
        }
        public int UpdateEmployeeDetails(EmployeeManagementDTO objEmployeeManagementDTO)
        {
            try
            {
                if (objEmployeeManagementDTO.empId == 0)
                {
                    throw new Exception("Invalid Employee Id");
                }
                if (objEmployeeManagementDTO.empName == null || objEmployeeManagementDTO.empName == "")
                {
                    throw new Exception("Invalid Employee Name");
                }
                if (objEmployeeManagementDTO.empDob == DateTime.MinValue)
                {
                    throw new Exception("Date of Birth is required.");
                }
                if (objEmployeeManagementDTO.empEmail == null || objEmployeeManagementDTO.empEmail == "")
                {
                    throw new Exception("Invalid Employee Email Address");
                }
                if (objEmployeeManagementDTO.empPhone == null || objEmployeeManagementDTO.empPhone == "")
                {
                    throw new Exception("Invalid Employee Phone Number");
                }
                if (objEmployeeManagementDTO.empAddress == null || objEmployeeManagementDTO.empAddress == "")
                {
                    throw new Exception("Invalid Employee Address");
                }
                if (objEmployeeManagementDTO.empGender == null || objEmployeeManagementDTO.empGender == "")
                {
                    throw new Exception("Invalid Employee Gender");
                }
                if (objEmployeeManagementDTO.empRole == null || objEmployeeManagementDTO.empRole == "")
                {
                    throw new Exception("Invalid Employee Role");
                }
                if (objEmployeeManagementDTO.empSalary == null || objEmployeeManagementDTO.empSalary == "")
                {
                    throw new Exception("Invalid Employee Salary");
                }
                if (objEmployeeManagementDTO.empAdharcardNumber == null || objEmployeeManagementDTO.empAdharcardNumber == "")
                {
                    throw new Exception("Invalid Employee Adhar Card Number");
                }
                //if (objEmployeeManagementDTO.empImage == null || objEmployeeManagementDTO.empImage.Length == 0)
                //{
                //    throw new Exception("Invalid Employee Image");
                //}

                return new EmployeeManagementDAL().UpdateEmployeeDetails(objEmployeeManagementDTO);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching UpdateEmployeeDetails().", ex);
            }
        }
        public int DeleteEmployeeData(int empId)
        {
            try
            {
                if (empId == 0) {
                    throw new Exception("Invalid Employee Id");
                }
                return new EmployeeManagementDAL().DeleteEmployeeData(empId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching DeleteEmployeeData().", ex);
            }
        }
        #region[============= Employee Atteandance ==============]
        public int SaveAttendance(AttendanceDTO objAttendanceDTO)
        {
            try
            {
                if (objAttendanceDTO.empId == 0)
                {
                    throw new Exception("Invalid Employee Id");
                }

                return new EmployeeManagementDAL().SaveAttendance(objAttendanceDTO);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching SaveAttendance().", ex);
            }
           
        }
        #endregion


    }
}
