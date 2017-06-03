using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TransportManagementSystemFYP
{
    public partial class StudentComplaint : System.Web.UI.Page
    {
        String DBstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterComplaint_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(DBstring))
            {
                String query = "INSERT into StudentComplaint(UniID,Complaint) values(@uniId,@complaint)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@uniId", UniID.Text);
                cmd.Parameters.AddWithValue("@complaint", StudentComplaintRegistration.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Data insert successfully')");
            }
        }

    }
}