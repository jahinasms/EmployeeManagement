using EmployeeManagement.DAL;
using System.Data;

namespace EmployeeManagement.BLL
{
    public class usersBLL
    {
        public DataTable GetUserDetails()
        {
            try
            {
                return new usersDAL().GetUserDetails();

            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetEmployeeDetails().", ex);
            }
        }
        public DataTable GetEmployeeDetailsVisibleToAdmin(string Role)
        {
            try
            {
                return new usersDAL().GetEmployeeDetailsVisibleToAdmin(Role);

            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetEmployeeDetails().", ex);
            }
        }
    }
}
