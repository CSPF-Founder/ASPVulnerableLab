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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterAction();
            //RegisterAction_Bcrypt();
        }

        protected void RegisterAction()
        {
            StringBuilder html = new StringBuilder();

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var conn = new SqlConnection(constr))
            {
                conn.Open();

                string updSql = @"Insert into Users(username, password, privilege, secret) values('" + Username.Text + "','" + Password.Text + "', " + Privilege.Value + ",'" + Secret.Text + "');";
                using (var cmd = new SqlCommand(updSql, conn))
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        html.Append("<b style='color:green'>Registered</b>");
                    }
                    else
                    {
                        html.Append("<b style='color:red'>No changes made</b>");
                    }
                }
            }
            RegisterFormPage.Controls.Clear();
            RegisterFormPage.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void RegisterAction_Bcrypt()
        {
            StringBuilder html = new StringBuilder();

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                String hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password.Text, BCrypt.Net.BCrypt.GenerateSalt());

                string updSql = @"Insert into Users(username, password, privilege, secret) values('" + Username.Text + "','" + hashedPassword + "', " + Privilege.Value + ",'" + Secret.Text + "');";
                using (var cmd = new SqlCommand(updSql, conn))
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        html.Append("<b style='color:green'>Registered</b>");
                    }
                    else
                    {
                        html.Append("<b style='color:red'>No changes made</b>");
                    }
                }
            }
            RegisterFormPage.Controls.Clear();
            RegisterFormPage.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}