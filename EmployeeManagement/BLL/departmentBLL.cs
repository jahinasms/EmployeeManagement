using EmployeeManagement.DAL;
using EmployeeManagement.DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System.Data;
using System.Reflection.Metadata;
using Document = iTextSharp.text.Document;

namespace EmployeeManagement.BLL
{
    public class departmentBLL
    {
        public DataTable GetDepartmentDistributionCount()
        {
            try
            {
                return new departmentDAL().GetDepartmentDistributionCount();

            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetDepartmentDistributionCount().", ex);
            }
        }

        public int AddNewDepartment(string departmentName)
        {
            try
            {
                if(departmentName ==null || departmentName == "")
                {
                    throw new Exception("Invalid Department Name");
                }
                return new departmentDAL().AddNewDepartment(departmentName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region[======================= Recent Activities ====================]
        public DataTable GetRecentActivites()
        {
            try
            {
                return new departmentDAL().GetRecentActivites();

            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetRecentActivites().", ex);
            }
        }
        public int AddNewACtivite(int empId, string activity)
        {
            try
            {
                if (empId == 0)
                {
                    throw new Exception("Invalid Employee Id");
                }
                if (activity == null || activity == "")
                {
                    throw new Exception("Invalid Activity Name");
                }
                return new departmentDAL().AddNewACtivite(empId, activity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching AddNewACtivite().", ex);
            }
           
        }
        #endregion

        #region[ ============================ Employee Reports =======================]
        public byte[] EmployeeDetailsAndDepartmentPDF()
        {
            try
            {
                DataTable dt = new departmentDAL().GetEmployeeReportDatas();

                using (MemoryStream stream = new MemoryStream())
                {
                    Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    Paragraph header = new Paragraph("Employee Report", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
                    header.Alignment = Element.ALIGN_CENTER;
                    doc.Add(header);
                    doc.Add(new Paragraph("\n"));

                    PdfPTable table = new PdfPTable(dt.Columns.Count);
                    foreach (DataColumn column in dt.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var cell in row.ItemArray)
                        {
                            table.AddCell(cell.ToString());
                        }
                    }

                    doc.Add(table);
                    doc.Close();

                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error while fetching EmployeeDetailsAndDepartmentPDF().", ex);
            }
           
        }

        public byte[] GetEmployeeSalaryData()
        {
            try
            {
                DataTable dt = new departmentDAL().GetEmployeeSalaryData();

                using (MemoryStream stream = new MemoryStream())
                {
                    Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    Paragraph header = new Paragraph("Employee Salary Report", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
                    header.Alignment = Element.ALIGN_CENTER;
                    doc.Add(header);
                    doc.Add(new Paragraph("\n"));

                    PdfPTable table = new PdfPTable(dt.Columns.Count);
                    foreach (DataColumn column in dt.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var cell in row.ItemArray)
                        {
                            table.AddCell(cell.ToString());
                        }
                    }

                    doc.Add(table);
                    doc.Close();

                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetEmployeeSalaryData().", ex);
            }
            
        }
        public byte[] GetEmployeeAttandanceReport(string empName)
        {
            try
            {
                DataTable dt = new departmentDAL().GetEmployeeAttandanceReport(empName);

                using (MemoryStream stream = new MemoryStream())
                {
                    Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    Paragraph header = new Paragraph("Employee Salary Report", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
                    header.Alignment = Element.ALIGN_CENTER;
                    doc.Add(header);
                    doc.Add(new Paragraph("\n"));

                    PdfPTable table = new PdfPTable(dt.Columns.Count);
                    foreach (DataColumn column in dt.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var cell in row.ItemArray)
                        {
                            table.AddCell(cell.ToString());
                        }
                    }

                    doc.Add(table);
                    doc.Close();

                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetEmployeeAttandanceReport().", ex);
            }
            
        }
        #endregion

        public DataTable GetEmployeeStatsReport()
        {
            try
            {
               
                return new departmentDAL().GetEmployeeStatsReport();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching GetEmployeeStatsReport().", ex);
            }
           
        }

    }
}
