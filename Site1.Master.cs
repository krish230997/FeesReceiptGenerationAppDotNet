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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
            if (Session["MyUser"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            Label1.Text= Session["MyUser"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string email=TextBox3.Text,user = TextBox1.Text, pass = TextBox2.Text,role="User";
            string q = "insert into auth(authemail,authpass,authuser,urole) values('"+user+"','"+pass+"','"+email+"','"+role+"')";
            SqlCommand cmd=new SqlCommand(q,conn);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('User Registered Success');</script>");
        }
    }
}