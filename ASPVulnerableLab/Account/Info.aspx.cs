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
    public partial class Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLoggedIn"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else
            {
                DisplayAccountInfo();
                //DisplayAccountInfo_Fixed();
            }
        }

        

        public void DisplayAccountInfo()
        {
            StringBuilder html = new StringBuilder();

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var conn = new SqlConnection(constr))
            {
                conn.Open();

                using (var cmd = new SqlCommand(@" select * from users where id=@account_id", conn))
                {
                    SqlParameter accountId = new SqlParameter("account_id", SqlDbType.Int);
                    accountId.Value = Request.QueryString["account_id"];
                    cmd.Parameters.Add(accountId);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows && dr.Read())
                    {
                        html.Append("Username: " + dr["username"] + "<br/>");
                        html.Append("Secret: " + dr["secret"]);
                    }
                    else
                    {
                        html.Append("<b style='color:red'>Invalid User id</b>");
                    }
                    AccountInfoPage.Controls.Add(new Literal { Text = html.ToString() });
                }
            }
        }

        public void DisplayAccountInfo_Fixed()
        {
            StringBuilder html = new StringBuilder();
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var conn = new SqlConnection(constr))
            {
                conn.Open();

                //Validating Part to make sure the user authorized to access the object:
                using (var cmd = new SqlCommand(@" select * from users where id=@account_id and username=@username", conn))
                {
                    SqlParameter accountId = new SqlParameter("account_id", SqlDbType.Int);
                    accountId.Value = Request.QueryString["account_id"];
                    cmd.Parameters.Add(accountId);

                    SqlParameter usernameParam = new SqlParameter("username", SqlDbType.NVarChar);
                    usernameParam.Value = Session["username"].ToString();
                    cmd.Parameters.Add(usernameParam);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (!dr.HasRows)
                    {
                        html.Append("<b style='color:red'>You are not authorized</b>");
                        AccountInfoPage.Controls.Add(new Literal { Text = html.ToString() });
                        return;
                    }

                }
            }

            //Getting the Data:
            using (var conn = new SqlConnection(constr))
            {
                conn.Open();

                using (var cmd = new SqlCommand(@" select * from users where id=@account_id and username=@username", conn))
                {
                    SqlParameter accountId = new SqlParameter("account_id", SqlDbType.Int);
                    accountId.Value = Request.QueryString["account_id"];
                    cmd.Parameters.Add(accountId);

                    SqlParameter usernameParam = new SqlParameter("username", SqlDbType.NVarChar);
                    usernameParam.Value = Session["username"].ToString();
                    cmd.Parameters.Add(usernameParam);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        html.Append("Username: " + dr["username"] + "<br/>");
                        html.Append("Secret: " + dr["secret"]);
                    }
                    else
                    {
                        html.Append("<b style='color:red'>Invalid User id</b>");
                    }
                    AccountInfoPage.Controls.Add(new Literal { Text = html.ToString() });
                }
            }
        }
    }
}