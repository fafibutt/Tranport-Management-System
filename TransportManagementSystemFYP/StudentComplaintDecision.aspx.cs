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
    public partial class StudentComplaintDecision : System.Web.UI.Page
    {
        String Dstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UniId"] != null)
            {
                TextBox1.Text = Session["UniId"].ToString();
                String id = TextBox1.Text;
                using (SqlConnection con = new SqlConnection(Dstring))
                {
                    String query = "SELECT * FROM [TransportManagementSystem].[dbo].[Complaint] where [UniID] =@uniId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@uniId", id);
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