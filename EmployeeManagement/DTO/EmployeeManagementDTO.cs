using Microsoft.VisualBasic;
using System.Reflection.Metadata;

namespace EmployeeManagement.DTO
{
    public class EmployeeManagementDTO
    {

        public int empId {  get; set; }  
        public string empName { get; set; }
        public DateTime empDob { get; set; }
        public string empEmail { get; set; }
        public string empPhone { get; set; }
        public string empAddress { get; set; }
        public string empGender { get; set; }
        public string empRole { get; set; }
        public string empSalary { get; set; }
        public string empAdharcardNumber { get; set; }
        public string empImage { get; set; }
        public string Department { get; set; }

    }

    public class AttendanceDTO
    {
        public int empId { get; set; }
        public DateOnly attendanceDate { get; set; }
        public TimeOnly? checkIn { get; set; }
        public TimeOnly? checkOut { get; set; }
        public string status { get; set; } = "Present";
        
    }
    public class EmailAutomationDTO
    {
        public int empId { get; set; }
        public string empName { get; set; }
        public string empEmail { get; set; }
        public string purpose { get; set; } // welcome, birthday, leave, monthly
        public string leaveDate { get; set; }
        public string monthSummary { get; set; }
    }
    public class DepartmentStat
    {
        public string name { get; set; }
        public int count { get; set; }
    }

    public class EmployeeStatsDTO
    {
        public int totalEmployees { get; set; }
        public List<DepartmentStat> departments { get; set; }
        public int onLeaveToday { get; set; }
        public int newJoineesThisMonth { get; set; }
        public List<string> birthdayToday { get; set; }
    }
}
