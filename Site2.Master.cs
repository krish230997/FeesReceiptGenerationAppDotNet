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
    public partial class Site2 : System.Web.UI.MasterPage
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
            Label1.Text = Session["MyUser"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text, contact = TextBox2.Text, email = TextBox3.Text,stream=TextBox4.Text,suser= Session["MyUser"].ToString();
            string qu = "select * from auth where authemail='"+suser+"'";
            SqlCommand c = new SqlCommand(qu,conn);
            SqlDataReader r = c.ExecuteReader();
            r.Read();
            string em=r["authuser"].ToString();
            string q = "insert into refer(name,contact,email,stream,referby) values('" + name + "','" + contact + "','" + email + "','" + stream + "','"+em+"')";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Reference Added Success');</script>");
        }
    }
}