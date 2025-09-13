using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pratice1
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cf);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text, pass = TextBox2.Text;
            string q = "select * from auth where authemail='" + email + "' AND authpass='" + pass + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (rdr["authemail"].Equals(email) && rdr["authpass"].Equals(pass) && rdr["urole"].Equals("Admin"))
                    {
                        Session["MyUser"] = email;
                        Response.Redirect("ShowEmp.aspx");
                    }
                    if (rdr["authemail"].Equals(email) && rdr["authpass"].Equals(pass) && rdr["urole"].Equals("User"))
                    {
                        Session["MyUser"] = email;
                        Response.Redirect("UserProfile.aspx");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Credentioals');</script>");
            }
        }
    }
}