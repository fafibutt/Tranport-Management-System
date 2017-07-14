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
    public partial class AssignDriverToVehicle : System.Web.UI.Page
    {
        String DBstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(DBstring))
                {
                    String q1 = "SELECT VehicleID,Number from Vehicle where Status = 'Active'";
                    SqlDataAdapter sda = new SqlDataAdapter(q1, conn);
                    DataTable dt1 = new DataTable();
                    sda.Fill(dt1);
                    if (dt1.Columns.Count != 0)
                    {
                        VehicleDropDown.DataSource = dt1;
                        VehicleDropDown.DataTextField = "Number";
                        VehicleDropDown.DataValueField = "VehicleID";
                        VehicleDropDown.DataBind();

                        ListItem LiVehicle = new ListItem("Select Vehicle", "-1");
                        VehicleDropDown.Items.Insert(0, LiVehicle);
                    }

                }
                using (SqlConnection con = new SqlConnection(DBstring))
                {
                    String q2 = "SELECT DriverID,Name from Driver where Status = 'Active'";
                    SqlDataAdapter sda = new SqlDataAdapter(q2, con);
                    DataTable dt2 = new DataTable();
                    sda.Fill(dt2);
                    if (dt2.Columns.Count != 0)
                    {
                        DriverDropDown.DataSource = dt2;
                        DriverDropDown.DataTextField = "Name";
                        DriverDropDown.DataValueField = "DriverID";
                        DriverDropDown.DataBind();

                        ListItem LiDriver = new ListItem("Select driver", "-1");
                        DriverDropDown.Items.Insert(0, LiDriver);
                    }
                }
            }
        }

        protected void AssignDriver_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DBstring))
            {
                String query = "Insert into VehicleDriver(VehicleID,DriverID,VehicleNumber,DriverName) values(@vehicleId,@driverId,@vehicleNumber,@driverName)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@vehicleId", VehicleDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@driverId", DriverDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@vehicleNumber", VehicleDropDown.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@driverName", DriverDropDown.SelectedItem.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "confirm('Assignment complete')");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}