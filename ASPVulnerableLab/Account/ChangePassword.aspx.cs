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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            this.ChangePasswordAction();
        }

        protected void ChangePasswordAction() 
        {
            StringBuilder html = new StringBuilder();

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                if (Session["user_id"] != null)
                {
                    int user_id = (Int32)Session["user_id"];
                    string updSql = @"UPDATE users SET password = '" + NewPassword.Text + "' where id=" + user_id;
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

            ChangePasswordStatus.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}