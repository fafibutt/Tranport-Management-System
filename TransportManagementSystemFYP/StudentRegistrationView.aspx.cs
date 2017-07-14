using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TransportManagementSystemFYP
{
    public partial class StudentRegistrationView : System.Web.UI.Page
    {
        String Dstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //TextBox1.Visible = false;
                if (Session["UniId"] != null)
                {
                    using (SqlConnection con = new SqlConnection(Dstring))
                    {
                        TextBox1.Text = Session["UniId"].ToString();
                        String query = "SELECT * FROM [TransportManagementSystem].[dbo].[StudentRegistration] where [UniID] =@uniId";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@uniId", TextBox1.Text);
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        if (sdr.HasRows)
                        {
                            dt.Load(sdr);
                            GridView.DataSource = dt;
                            GridView.DataBind();
                        }
                    }
                }
            }
        }
    }
}