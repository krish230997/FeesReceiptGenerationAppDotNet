using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Pratice1
{
    public partial class Addemp : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf= ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string contact = txtContact.Text;
            string email = txtEmail.Text;
            string course = "Dot Net Full Stack Developer";
            decimal fees = Convert.ToDecimal(30000);

            string dt = txtDate.Text;

            string query = "INSERT INTO emptbl (Name, Contact, Email, Date, Course, Fees) VALUES ('"+name+"','"+contact+"','"+email+"','"+dt+"','"+course+"','"+fees+"')";

            
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
      
            Response.Write("Employee added successfully!");

            Response.Redirect("addemp.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisplayEmp.aspx");
        }
    }
}