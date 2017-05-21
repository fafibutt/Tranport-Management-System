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
            String DbString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(DbString))
            {
                String query = "Select VehicleID,Name from Vehicle where VehicleID = @vehicleId and Name = @name";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("vehicleId", VehicleID.Text);
                command.Parameters.AddWithValue("@name", VehicleName.Text);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 1)
                {
                    try
                    {
                        String Query = "insert into Vehicle(VehicleID,Name,Number,ChassisNumber,OwnerName,Status) values(@vehicleId,@name,@number,@chassisNumber,@ownerName,@status)";
                        SqlCommand cmd = new SqlCommand(Query,conn);
                        cmd.Parameters.AddWithValue("@vehicleId", VehicleID.Text);
                        cmd.Parameters.AddWithValue("@name", VehicleName.Text);
                        cmd.Parameters.AddWithValue("@number", VehicleNumber.Text);
                        cmd.Parameters.AddWithValue("@chassisNumber", VehicleChassisNumber.Text);
                        cmd.Parameters.AddWithValue("@ownerName", VehicleOwner.Text);
                        cmd.Parameters.AddWithValue("@status", Status);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Data insert successfully')");
                    }
                    catch (SqlException exe)
                    {
                        throw exe;
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Data already exist')");
                }
            }
        }
    }
}