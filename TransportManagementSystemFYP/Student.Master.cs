using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TransportManagementSystemFYP
{
    public partial class Student : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UniId"] != null)
            {
                UserId.Text = Session["UniId"].ToString();
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void BtnLogout_Click1(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("index.aspx");
        }
    }
}