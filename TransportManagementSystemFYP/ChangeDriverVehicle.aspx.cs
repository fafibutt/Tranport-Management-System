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
    public partial class ChangeDriverVehicle : System.Web.UI.Page
    {
        String DBstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DriverId.Visible = false;
                DriverName.Visible = false;
                VehicleDropDown.Visible = false;
                UpdateVehicle.Visible = false;
            }
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriverId.Visible = true;
            DriverName.Visible = true;
            VehicleDropDown.Visible = true;
            UpdateVehicle.Visible = true;
            DriverId.Text = GridView.SelectedRow.Cells[1].Text;
            DriverName.Text = GridView.SelectedRow.Cells[3].Text;
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
                    ListItem liVehicle = new ListItem("Select Vehicle", "-1");
                    VehicleDropDown.Items.Insert(0, liVehicle);
                }

            }
        }

        protected void BtnSearchDriver_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection conn = new SqlConnection(DBstring))
            {
                try
                {
                    String query = "SELECT * FROM VehicleDriver  WHERE DriverName LIKE @search OR DriverID LIKE @search";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + SearchTextBox.Text + "%");
                    conn.Open();
                    SqlDataReader SDR = cmd.ExecuteReader();
                    DataTable DT = new DataTable();
                    if (SDR.HasRows)
                    {
                        DT.Load(SDR);
                        GridView.DataSource = DT;
                        GridView.DataBind();
                    }
                }
                catch (SqlException exe)
                {
                    throw exe;
                }
            }
        }

        protected void UpdateVehicle_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DBstring))
            {
                String query = "UPDATE VehicleDriver SET VehicleID=@vehicleId,DriverID=@driverId,VehicleNumber=@vehicleNumber,DriverName=@driverName where DriverID=@driverId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@vehicleId", VehicleDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@driverId", DriverId.Text);
                cmd.Parameters.AddWithValue("@vehicleNumber", VehicleDropDown.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@driverName", DriverName.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "confirm('Assignment complete')");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}