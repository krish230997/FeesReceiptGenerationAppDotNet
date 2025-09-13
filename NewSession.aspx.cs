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
    public partial class NewSession : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
        }

        protected void btnAddPlaylist_Click(object sender, EventArgs e)
        {

            string title = txtTitle.Text;
            string youTubeUrl = txtYouTubeUrl.Text;


            string query = "INSERT INTO Playlists (Title, YouTubeUrl) VALUES (@Title, @YouTubeUrl)";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@YouTubeUrl", youTubeUrl);


            command.ExecuteNonQuery();


            Response.Write("<script>alert('Session Added Successfully!');</script>");
        }
    }
}