using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPVulnerableLab.Posts
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.Display_Posts();
                //this.Display_Posts_Fixed();
            }
        }

        protected void Display_Posts()
        {
            String userInput = Request.QueryString["id"];
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            StringBuilder html = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();

                //Vulnerable - Direct user input - Dynamic Query
                SqlCommand cmd = new SqlCommand("SELECT title,content FROM Posts where id=" + userInput, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        html.Append(String.Format("<h3>{0}</h3>", reader["title"]));
                        html.Append(String.Format("<div class='post-content'>{0}</div>", reader["content"]));
                    }
                }

            }

            PostsPlace.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void Display_Posts_Fixed()
        {
            String userInput = Request.QueryString["id"];
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StringBuilder html = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();

                //Parameterized Query:
                SqlCommand cmd = new SqlCommand("SELECT title,content FROM Posts where id=@id", conn);
                SqlParameter postId = new SqlParameter("id", SqlDbType.Int);
                postId.Value = userInput;
                cmd.Parameters.Add(postId);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        html.Append(String.Format("<h3>{0}</h3>", reader["title"]));
                        html.Append(String.Format("<div class='post-content'>{0}</div>", reader["content"]));
                    }
                }
            }

            PostsPlace.Controls.Add(new Literal { Text = html.ToString() });
        }
        
    }
}