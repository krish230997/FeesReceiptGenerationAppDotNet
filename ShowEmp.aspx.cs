using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pratice1
{
    public partial class ShowEmp : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {

                BindGridView();
            }
        }

        private void BindGridView()
        {
            string query = "SELECT TOP 1000 [id], [Name], [Contact], [Email], [Date], [Course], [Fees] FROM [corporate].[dbo].[emptbl]";


            SqlCommand command = new SqlCommand(query, conn);

            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
                else
                {
                    // Handle the case where no data is returned
                    // You can display a message or hide the GridView
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label l1 = (Label)GridView1.Rows[e.RowIndex].FindControl("Label3");
            string q = "delete from emptbl where id='" + l1.Text + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            BindGridView(); // Create a method to bind data to the GridView
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("addemp.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("receipt.aspx");
        }
    }
}