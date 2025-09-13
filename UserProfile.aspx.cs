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
    public partial class UserProfile : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!Page.IsPostBack)
            {
                showUsers();
            }

        }

        public void showUsers()
        {
            string suser=Session["MyUser"].ToString();
            string q1 = "select * from auth where authemail='"+suser+"'";
            SqlCommand cmd1=new SqlCommand(q1, conn);
            SqlDataReader r = cmd1.ExecuteReader();
            r.Read();
            string em=r["authuser"].ToString();

            string q = "select * from emptbl where Email='"+em+"'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataList1.DataSource = reader;
            DataList1.DataBind();
        }
    }
}