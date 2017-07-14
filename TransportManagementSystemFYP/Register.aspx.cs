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
    public partial class Register : System.Web.UI.Page
    {
        String DBstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DBstring))
            {
                String query = "INSERT into UserDetail(UniID,Name,Email,Password,Designation) Values(@uniId,@name,@email,@password,'Student')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@uniId",UniId.Text);
                cmd.Parameters.AddWithValue("@name", UserName.Text);
                cmd.Parameters.AddWithValue("@email", UserEmail.Text);
                cmd.Parameters.AddWithValue("@password", Password.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('You have been successfully register');window.location='Login.aspx';</script>'");
                Response.Redirect("index.aspx");
            }
        }
    }
}