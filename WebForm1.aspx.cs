using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

namespace ASPNET_RDLC
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load the report data and set it to the ReportViewer
                LoadReport();
            }
        }

        private void LoadReport()
        {
            // Get the data from the database
            DataTable studentData = GetStudentData();

            // Set the Report Path
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("StudentRPT.rdlc");

            // Clear any existing data sources
            ReportViewer1.LocalReport.DataSources.Clear();

            // Create a new ReportDataSource with the name of your dataset in the RDLC
            ReportDataSource rds = new ReportDataSource("DataSet1", studentData);

            // Add the data source to the report
            ReportViewer1.LocalReport.DataSources.Add(rds);

            // Refresh the report
            ReportViewer1.LocalReport.Refresh();
        }

        private DataTable GetStudentData()
        {
            // Define the query
            string query = "SELECT * FROM StudentTbl";

            // Create a DataTable to hold the data
            DataTable dt = new DataTable();

            // Use ADO.NET to fetch data from the database
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        // Fill the DataTable with data from the database
                        sda.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}
