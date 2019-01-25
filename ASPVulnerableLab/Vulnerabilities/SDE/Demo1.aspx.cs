using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPVulnerableLab.Vulnerabilities.SDE
{
    public partial class Demo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayPage();
            //DisplayPage_Fixed();
        }

        protected void DisplayPage()
        {
            StringBuilder html = new StringBuilder();

            int i;
            i = Int32.Parse(Request.QueryString["id"].ToString());
            //Int32.TryParse(Request.QueryString["id"].ToString(), out i);
            String dbPassword = "DbSecurePassword:(";
            html.Append("Given Input: " + i);

            SecMisConfig1.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void DisplayPage_Fixed()
        {
            StringBuilder html = new StringBuilder();
            /*
             * * Catching all exceptions
             * * Using "TryParse" method instead of Parse
             */

            try
            {
                int i;
                if (Int32.TryParse(Request.QueryString["id"].ToString(), out i))
                {

                    html.Append("Given Input: " + i);
                }
                else
                {
                    html.Append("Invalid Input given");
                }
                String dbPassword = "DbSecurePassword:)";
            }
            catch (NullReferenceException e)
            {
                html.Append("Invalid Input");
            }
            catch (Exception e)
            {
                html.Append("Error Occurred");
            }

            SecMisConfig1.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}