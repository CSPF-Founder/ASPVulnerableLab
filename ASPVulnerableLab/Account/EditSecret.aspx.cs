using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ASPVulnerableLab.Account
{
    public partial class EditSecret : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["isLoggedIn"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            DisplayCurrentSecret();

        }

        protected void ChangeSecretButton_Click(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                if (Session["user_id"] != null)
                {
                    int user_id = (Int32)Session["user_id"];
                    string updSql = @"UPDATE users SET secret = '" + NewSecret.Text + "' where id=" + user_id;
                    using (var cmd = new SqlCommand(updSql, conn))
                    {
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            html.Append("<b style='color:green'>Updated</b>");
                        }
                        else
                        {
                            html.Append("<b style='color:red'>No changes made</b>");
                        }
                    }
                }
                else
                {
                    html.Append("<b style='color:red'>Login before to change the password</b>");
                }
            }

            ChangeSecretStatus.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void DisplayCurrentSecret()
        {
            StringBuilder html = new StringBuilder();

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var conn = new SqlConnection(constr))
            {
                conn.Open();

                using (var cmd = new SqlCommand(@" select secret from users where id='" + Session["user_id"] + "' ", conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows && dr.Read())
                    {
                        html.Append(dr["secret"].ToString());
                    }
                }
            }
            CurrentSecretPlace.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}