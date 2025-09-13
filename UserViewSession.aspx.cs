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
    public partial class UserViewSession : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                BindPlaylists();
            }
        }

        protected void gridPlaylists_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Play")
            {
                int playlistId = Convert.ToInt32(e.CommandArgument);


                string query = "SELECT YouTubeUrl FROM Playlists WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Id", playlistId);


                string yt = command.ExecuteScalar().ToString();
                string iframeUrl = $"https://www.youtube.com/embed/{yt}";

                // Generate the iframe HTML code
                string iframeHtml = $"<iframe width='920' height='600' src='{iframeUrl}' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>";

                // Set the generated HTML to the Literal control
                ltrYouTubePlayer.Text = iframeHtml;

            }
        }

        

        private void BindPlaylists()
        {

            string query = "SELECT Id, Title FROM Playlists";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();


            adapter.Fill(dataTable);

            gridPlaylists.DataSource = dataTable;
            gridPlaylists.DataBind();

        }
    }
}