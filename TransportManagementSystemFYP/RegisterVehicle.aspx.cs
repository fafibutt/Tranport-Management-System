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
    public partial class RegisterVehicle : System.Web.UI.Page
    {
        String DbString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            }
        }

        protected void VehicleRegistration_Click(object sender, EventArgs e)
        {
            String Status = "Active";
            using (SqlConnection conn = new SqlConnection(DbString))
            {
                String query = "Select ChassisNumber from Vehicle where ChassisNumber = @chassisNumber";
                SqlDataAdapter sda = new SqlDataAdapter(query,conn);
                sda.SelectCommand.Parameters.AddWithValue("@chassisNumber", VehicleChassisNumber.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 1)
                {
                    try
                    {
                        String Query = "insert into Vehicle(Name,Number,ChassisNumber,OwnerName,Status) values(@name,@number,@chassisNumber,@ownerName,@status)";
                        SqlCommand cmd = new SqlCommand(Query,conn);
                        cmd.Parameters.AddWithValue("@name", VehicleName.Text);
                        cmd.Parameters.AddWithValue("@number", VehicleNumber.Text);
                        cmd.Parameters.AddWithValue("@chassisNumber", VehicleChassisNumber.Text);
                        cmd.Parameters.AddWithValue("@ownerName", VehicleOwner.Text);
                        cmd.Parameters.AddWithValue("@status", Status);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", "confirm('Vehicle register successfully')");
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                    catch (SqlException exe)
                    {
                        throw exe;
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "confirm('Vehicle register successfully')");
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }
    }
}