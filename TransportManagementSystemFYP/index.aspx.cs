using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TransportManagementSystemFYP
{
    public partial class index : System.Web.UI.Page
    {
        String Db = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        String role = "";
        String password = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Db))
            {
                String Query = "SELECT UniID,Email,Password,Designation from UserDetail where Email =@email and Password = @pass";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@email",email.Text);
                cmd.Parameters.AddWithValue("@pass",pass.Text);
                conn.Open();
                SqlDataReader SDR = cmd.ExecuteReader();
                int count = 0;
                while (SDR.Read())
                {
                    count += 1;
                    role = SDR["Designation"].ToString();
                    password = SDR["Password"].ToString();
                    Session["Designation"] = role;
                    Session["Email"] = email.Text;
                    Session["UniId"] = SDR["UniID"].ToString();
                }
                if (count == 1)
                {
                    if (role.Trim() == "Admin")
                    {
                        Response.Redirect("TransportManagerHome.aspx");
                    }
                    else if (role.Trim() == "Student")
                    {
                        Response.Redirect("StudentHome.aspx");

                    }
                }
                else
                {
                    email.Text = role+password;
                    pass.Text = password;
                    email.BorderColor = System.Drawing.Color.Red;
                    pass.BorderColor = System.Drawing.Color.Red;
                }

            }
        }
    }
}