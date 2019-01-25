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

namespace ASPVulnerableLab.Application
{
    public partial class EditTitle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (Session["isLoggedIn"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }*/
        }
        protected void ChangeTitleButton_Click(object sender, EventArgs e)
        {
            EditTitleAction();
        }

        protected void EditTitleAction()
        {
            StringBuilder html = new StringBuilder();

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                string updSql = @"UPDATE AppSettings SET Value = '" + NewAppTitle.Text + "' where Name='AppTitle'";
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

            ChangeTitleStatus.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}