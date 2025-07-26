using EmployeeManagement.DTO;
using MySql.Data.MySqlClient;
using System.Data;

namespace EmployeeManagement.DAL
{
    public class departmentDAL
    {
        public string connectionString = "server=localhost;user=root;password=jahina@123;database=employee;port=3306;";

        #region[================= Employee stats]
        public DataTable GetEmployeeStatsReport()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Title");
                dt.Columns.Add("Value");

                string query = @"
                   
                         SELECT 
                         (SELECT COUNT(*) FROM employee) AS total_employees,
                         (SELECT COUNT(*) FROM employee_attendance 
                         WHERE status = 'Leave' AND attendance_date = CURDATE()) AS on_leave_today,
                        (SELECT COUNT(*) FROM employee 
                         WHERE MONTH(emp_dob) = MONTH(CURDATE()) AND YEAR(emp_dob) = YEAR(CURDATE())) AS new_joinees,
                         (SELECT GROUP_CONCAT(emp_name SEPARATOR ', ') 
                          FROM employee 
                         WHERE DAY(emp_dob) = DAY(CURDATE())  AND MONTH(emp_dob) = MONTH(CURDATE())) AS birthdays_today;

                       SELECT d.dep_name AS department, COUNT(e.emp_id) AS emp_count
                       FROM department d
                       LEFT JOIN employee e ON d.dep_id = e.dep_id
                       GROUP BY d.dep_id; ";



                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // First Result Set: Stats
                        if (reader.Read())
                        {
                            dt.Rows.Add("Total Employees", reader["total_employees"].ToString());
                            dt.Rows.Add("On Leave Today", reader["on_leave_today"].ToString());
                            dt.Rows.Add("New Joinees This Month", reader["new_joinees"].ToString());

                            string birthdayList = reader["birthdays_today"] == DBNull.Value ? "" : reader["birthdays_today"].ToString();
                            if (!string.IsNullOrWhiteSpace(birthdayList))
                            {
                                foreach (var name in birthdayList.Split(','))
                                {
                                    if (!string.IsNullOrWhiteSpace(name))
                                        dt.Rows.Add("Birthday Today", name.Trim());
                                }
                            }
                            else
                            {
                                dt.Rows.Add("Birthday Today", "None");
                            }
                        }

                        // Move to second result set: Department counts
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                string dept = reader["department"].ToString();
                                string count = reader["emp_count"].ToString();
                                dt.Rows.Add($"Department - {dept}", count);
                            }
                        }
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching employee Stat details.", ex);
            }

        }
        #endregion

        #region
        public DataTable GetDepartmentDistributionCount()
        {
            try
            {
                DataTable dtEmployee = new DataTable();
                using (MySqlConnection MySqlConnection = new MySqlConnection(connectionString))
                {
                    string query = @"SELECT  d.dep_name AS departmentName, COUNT(e.emp_id) AS employeeCount
                                      FROM department d
                                      LEFT JOIN  employee e ON d.dep_id = e.dep_id GROUP BY  d.dep_id, d.dep_name";

                    using (MySqlCommand MySqlCommand = new MySqlCommand(query, MySqlConnection))
                    {

                        using (MySqlDataAdapter DataAdapter = new MySqlDataAdapter(MySqlCommand))
                        {
                            DataAdapter.Fill(dtEmployee);
                            if (dtEmployee != null && dtEmployee.Rows.Count > 0)
                            {
                                return dtEmployee;
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
        public int AddNewDepartment(string departmentName)
        {

            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    string query = @"insert into department(dep_name)values(?depName)";
                    using (MySqlCommand MySqlCommand = new MySqlCommand(query, mySqlConnection))
                    {
                        MySqlCommand.Parameters.AddWithValue("?depName", departmentName);


                        mySqlConnection.Open();

                        int result = MySqlCommand.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return result;
                        }
                        else
                        {
                            throw new Exception("Failed To Add.");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching users details.", ex);
            }

        }
        #endregion


        #region[===== Recent Activities ======]
        public DataTable GetRecentActivites()
        {
            try
            {
                DataTable dtActivites = new DataTable();
                using (MySqlConnection MySqlConnection = new MySqlConnection(connectionString))
                {
                    string query = @"SELECT ra.id activityID, e.emp_name, ra.activity, ra.activity_time
                                     FROM recent_activities ra
                                     INNER JOIN employee e ON ra.emp_id = e.emp_id";

                    using (MySqlCommand MySqlCommand = new MySqlCommand(query, MySqlConnection))
                    {

                        using (MySqlDataAdapter DataAdapter = new MySqlDataAdapter(MySqlCommand))
                        {
                            DataAdapter.Fill(dtActivites);
                            if (dtActivites != null && dtActivites.Rows.Count > 0)
                            {
                                return dtActivites;
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
        public int AddNewACtivite(int empId,string activity)
        {

            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    string query = @"insert into recent_activities(emp_id,activity)values(?empId,?activity)";
                    using (MySqlCommand MySqlCommand = new MySqlCommand(query, mySqlConnection))
                    {
                        MySqlCommand.Parameters.AddWithValue("?empId", empId);
                        MySqlCommand.Parameters.AddWithValue("?activity", activity);

                        mySqlConnection.Open();

                        int result = MySqlCommand.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return result;
                        }
                        else
                        {
                            throw new Exception("Failed To Add.");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching users details.", ex);
            }

        }
        #endregion

        #region[ ================================= Employee Reports ==========================]
        public DataTable GetEmployeeReportDatas()
        {
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"SELECT e.emp_name empName,emp_dob empDob, e.emp_email empEmail, e.emp_phone empPhone,e.emp_address empAddress,e.emp_gender empGender,e.emp_role empRole,d.dep_name AS Department 
                                 FROM employee e 
                                 INNER JOIN department d ON e.dep_id = d.dep_id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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
            catch (Exception ex)
            {
                throw new Exception("Error while fetching employee details.", ex);
            }
            
        }

        public DataTable GetEmployeeSalaryData()
        {
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"SELECT emp_name empName,emp_salary empSalary,emp_pf_salary empPFSalary,emp_gross_salary empGrossSalary,emp_monthly_salary empMonthlySalary
                                 FROM employee e";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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
            catch (Exception ex)
            {
                throw new Exception("Error while fetching employee salary details.", ex);
            }
            
        }

        public DataTable GetEmployeeAttandanceReport(string empName)
        {
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"SELECT e.emp_name AS empName,ed.day,ed.attendance_date AS attendanceDate,ed.check_in AS checkIn,ed.check_out AS checkOut,ed.status
                                   FROM employee_attendance ed
                                   INNER JOIN employee e ON ed.emp_id = e.emp_id WHERE e.emp_name='" + empName + "'";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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
            catch (Exception ex)
            {
                throw new Exception("Error while fetching employee Attandance details.", ex);
            }
            
           
        }
        #endregion

       


    }
}
