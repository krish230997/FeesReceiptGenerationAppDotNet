using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Pratice1
{
    public partial class ViewSession : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if(!IsPostBack)
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

                
                string iframeHtml = $"<iframe width='920' height='600' src='{iframeUrl}' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>";

                
                ltrYouTubePlayer.Text = iframeHtml;

            }
        }

        protected void gridPlaylists_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label l1 = (Label)gridPlaylists.Rows[e.RowIndex].FindControl("Label3");
            string q = "delete from Playlists where id='" + l1.Text + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            BindPlaylists(); // Create a method to bind data to the GridView
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