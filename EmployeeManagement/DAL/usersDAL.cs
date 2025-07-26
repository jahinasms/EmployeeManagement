using EmployeeManagement.DTO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace EmployeeManagement.DAL
{
    public class usersDAL
    {
        public string connectionString = "server=localhost;user=root;password=jahina@123;database=users;port=3306;";
        public DataTable GetUserDetails()
        {
            try
            {
                DataTable dtUsers = new DataTable();
                using (MySqlConnection MySqlConnection = new MySqlConnection(connectionString))
                {
                    string query = @"select user_id userId, user_name userName, user_password userPassword, user_role userRole from Users";

                    using (MySqlCommand MySqlCommand = new MySqlCommand(query, MySqlConnection))
                    {

                        using (MySqlDataAdapter DataAdapter = new MySqlDataAdapter(MySqlCommand))
                        {
                            DataAdapter.Fill(dtUsers);
                            if (dtUsers != null && dtUsers.Rows.Count > 0)
                            {
                                return dtUsers;
                            }
                            else
                            {
                                throw new Exception("No Data Found.");
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching employee details.", ex);
            }
        }
        public DataTable GetEmployeeDetailsVisibleToAdmin(string Role)
        {
            try
            {
                string query = string.Empty;

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    if (Role == "Admin")
                    {
                        query = @"SELECT emp_name empName, emp_dob empDob, emp_email empEmail, emp_phone empPhone, emp_address empAddress, emp_gender empGender, emp_role empRole, 
                                 emp_salary empSalary, emp_adharcard_number empAdharCardNo, emp_image, emp_pf_salary empPFSalary, emp_gross_salary empGrossSalary, 
                                 emp_monthly_salary empMonthlySalary, ra.activity
                          FROM employee.employee eempName
                          INNER JOIN employee.employee_attendance ea ON e.emp_id = ea.id
                          INNER JOIN employee.recent_activities ra ON e.emp_id = ra.id";
                    }
                    else if (Role == "HR")
                    {
                        query = @"SELECT emp_name empName, emp_dob empDob, emp_email empEmail, emp_phone empPhone, emp_address empAddress, emp_gender empGender, emp_role empRole,d.dep_name depName 
                          FROM employee.employee e
                          inner join employee.department d on d.dep_id = e.dep_id";
                    }
                    else if (Role == "Employee")
                    {
                        query = @"SELECT emp_name empName, emp_dob empDob, emp_email empEmail, emp_phone empPhone, emp_address empAddress, emp_gender empGender, emp_role empRole 
                          FROM employee.employee";
                    }
                    else
                    {
                        throw new Exception("Invalid role.");
                    }

                    using (MySqlCommand com = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(com))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                return dt;
                            }
                            else
                            {
                                throw new Exception("No Data Found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching employee details.", ex);
            }
        }

    }
}
