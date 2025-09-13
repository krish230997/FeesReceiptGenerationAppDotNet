using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pratice1
{
    public partial class NewEmp : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
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
            FileUpload1.SaveAs(Server.MapPath("Photos/") + Path.GetFileName(FileUpload1.FileName));
            string stimage = "Photos/" + Path.GetFileName(FileUpload1.FileName);
            string dt = txtDate.Text;

            string query = "INSERT INTO emptbl (Name, Contact, Email, Date, Course, Fees,img) VALUES ('" + name + "','" + contact + "','" + email + "','" + dt + "','" + course + "','" + fees + "','"+stimage+"')";


            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Emp Added Successfully!!')</script>");

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowEmp.aspx");
        }
    }
}