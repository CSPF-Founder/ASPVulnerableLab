using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPVulnerableLab
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DisplayError();
            //this.DisplayError_Fixed();
        }

        protected void DisplayError_Fixed()
        {
            StringBuilder html = new StringBuilder();
            String msg = Request.QueryString["error"];
            html.Append("<script>document.write('" + HttpUtility.HtmlEncode(msg) + "');</script>");
            ErrorMessage.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void DisplayError()
        {
            StringBuilder html = new StringBuilder();
            String msg = Request.QueryString["error"];
            html.Append("<script>document.write('" + msg + "');</script>");
            ErrorMessage.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}