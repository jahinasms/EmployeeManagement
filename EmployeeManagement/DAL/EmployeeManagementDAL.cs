using EmployeeManagement.DTO;
using MySql.Data.MySqlClient;
using System.Data;

namespace EmployeeManagement.DAL
{
    public class EmployeeManagementDAL
    {

        public string connectionString = "server=localhost;user=root;password=jahina@123;database=employee;port=3306;";

        public DataTable GetEmployeeDetails()
        {
            try
            {
                DataTable dtEmployee = new DataTable();
                using (MySqlConnection MySqlConnection = new MySqlConnection(connectionString))
                {
                    string query = @"select emp_id empId, emp_name empName, emp_dob empDob, emp_email empEmail, emp_phone empPhone, emp_address empAddress, emp_gender empGender, emp_role empRole, emp_salary empSalary, emp_adharcard_number empAdharcardNumber, emp_image empImage from employee";

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

        public DataTable GetSearchEmployeeDetails(string search)
        {
            try
            {
                DataTable dtEmployee = new DataTable();
                using (MySqlConnection MySqlConnection = new MySqlConnection(connectionString))
                {
                    string query = @"select emp_id empId, emp_name empName, emp_dob empDob, emp_email empEmail, emp_phone empPhone, emp_address empAddress, emp_gender empGender, emp_role empRole, emp_salary empSalary, emp_adharcard_number empAdharcardNumber, emp_image empImage from employee where emp_id='" + search + "' or emp_name ='" + search + "' or emp_phone = '" + search + "'";

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

        public int SaveEmployeeDetails(List<EmployeeManagementDTO> employeeList)
        {
            int totalInserted = 0;

            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open(); 

                    foreach (var emp in employeeList)
                    {
                        string query = @"INSERT INTO employee
                (emp_name, emp_dob, emp_email, emp_phone, emp_address, emp_gender, emp_role, emp_salary, emp_adharcard_number, emp_image)
                VALUES
                (?empName, ?empDob, ?empEmail, ?empPhone, ?empAddress, ?empGender, ?empRole, ?empSalary, ?empAdharcardNumber, ?empImage)";

                        using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("?empName", emp.empName);
                            cmd.Parameters.AddWithValue("?empDob", emp.empDob.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("?empEmail", emp.empEmail);
                            cmd.Parameters.AddWithValue("?empPhone", emp.empPhone);
                            cmd.Parameters.AddWithValue("?empAddress", emp.empAddress);
                            cmd.Parameters.AddWithValue("?empGender", emp.empGender);
                            cmd.Parameters.AddWithValue("?empRole", emp.empRole);
                            cmd.Parameters.AddWithValue("?empSalary", emp.empSalary);
                            cmd.Parameters.AddWithValue("?empAdharcardNumber", emp.empAdharcardNumber);
                            cmd.Parameters.AddWithValue("?empImage", emp.empImage); // 👈 Safe null handling

                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                                totalInserted += result;
                            else
                                throw new Exception("Failed to save employee: " + emp.empName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while saving employee details.", ex);
            }

            return totalInserted;
        }


        public DataTable GetEmployeeDetails(int empId)
        {
            try
            {
                DataTable dtEmployee = new DataTable();
                using (MySqlConnection MySqlConnection = new MySqlConnection(connectionString))
                {
                    string query = @"select emp_id empId, emp_name empName, emp_dob empDob, emp_email empEmail, emp_phone empPhone, emp_address empAddress, emp_gender empGender, emp_role empRole, emp_salary empSalary, emp_adharcard_number empAdharcardNumber, emp_image empImage from employee where emp_id='" + empId + "'";

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

        public int UpdateEmployeeDetails(EmployeeManagementDTO objEmployeeManagementDTO)
        {

            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    string query = @"Update employee set emp_name=?empName, emp_dob=?empDob, emp_email=?empEmail, emp_phone=?empPhone, emp_address=?empAddress, emp_gender=?empGender, emp_role=?empRole, emp_salary=?empSalary, emp_adharcard_number=?empAdharcardNumber, emp_image=?empImage where emp_id='" + objEmployeeManagementDTO.empId + "'";
                    using (MySqlCommand MySqlCommand = new MySqlCommand(query, mySqlConnection))
                    {
                        MySqlCommand.Parameters.AddWithValue("?empName", objEmployeeManagementDTO.empName);
                        MySqlCommand.Parameters.AddWithValue("?empDob", objEmployeeManagementDTO.empDob.ToString("yyyy-MM-dd"));
                        MySqlCommand.Parameters.AddWithValue("?empEmail", objEmployeeManagementDTO.empEmail);
                        MySqlCommand.Parameters.AddWithValue("?empPhone", objEmployeeManagementDTO.empPhone);
                        MySqlCommand.Parameters.AddWithValue("?empAddress", objEmployeeManagementDTO.empAddress);
                        MySqlCommand.Parameters.AddWithValue("?empGender", objEmployeeManagementDTO.empGender);
                        MySqlCommand.Parameters.AddWithValue("?empRole", objEmployeeManagementDTO.empRole);
                        MySqlCommand.Parameters.AddWithValue("?empSalary", objEmployeeManagementDTO.empSalary);
                        MySqlCommand.Parameters.AddWithValue("?empAdharcardNumber", objEmployeeManagementDTO.empAdharcardNumber);
                        MySqlCommand.Parameters.AddWithValue("?empImage", objEmployeeManagementDTO.empImage);

                        mySqlConnection.Open();

                        int result = MySqlCommand.ExecuteNonQuery();

                        if (result > 0)
                        {

                            return result;

                        }
                        else
                        {
                            throw new Exception("Failed To Save.");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching employee details.", ex);
            }

        }

        public int DeleteEmployeeData(int empId)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    string query = @"Delete from employee where emp_id='" + empId + "'";
                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        int res = mySqlCommand.ExecuteNonQuery();
                        if (res > 0)
                        {
                            return res;
                        }
                        else
                        {
                            throw new Exception("Failed To Delete.");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching employee details.", ex);
            }
        }

        #region[========= Employee Attandance ============]

        public int SaveAttendance(AttendanceDTO objAttendanceDTO)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"INSERT INTO employee_attendance(emp_id, attendance_date, check_in, check_out, status)
                                 VALUES (@empId, @attendanceDate, @checkIn, @checkOut, @status)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@empId", objAttendanceDTO.empId);
                        cmd.Parameters.AddWithValue("@attendanceDate", objAttendanceDTO.attendanceDate.ToString("yyyy-MM-dd"));

                        cmd.Parameters.AddWithValue("@checkIn",(objAttendanceDTO.checkIn?.ToString(@"hh\:mm\:ss")));

                        cmd.Parameters.AddWithValue("@checkOut", objAttendanceDTO.checkOut?.ToString(@"hh\:mm\:ss"));
                        cmd.Parameters.AddWithValue("@status", objAttendanceDTO.status);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                            return result;
                        else
                            throw new Exception("Failed to save employee:");
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error while saving employee details.", ex);
            }
        }
        #endregion

        public List<EmailAutomationDTO> GetTodayBirthdays()
        {
            List<EmailAutomationDTO> list = new List<EmailAutomationDTO>();
            

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT emp_id, emp_name, emp_email 
                             FROM employee 
                             WHERE DATE_FORMAT(emp_dob, '%m-%d') = DATE_FORMAT(CURDATE(), '%m-%d')";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new EmailAutomationDTO
                        {
                            empId = Convert.ToInt32(reader["emp_id"]),
                            empName = reader["emp_name"].ToString(),
                            empEmail = reader["emp_email"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
