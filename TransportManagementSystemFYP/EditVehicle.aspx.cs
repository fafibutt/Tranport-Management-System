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
    public partial class EditVehicle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VehicleID.Visible = false;
                VehicleName.Visible = false;
                VehicleNumber.Visible = false;
                VehicleChassisNumber.Visible = false;
                VehicleOwner.Visible = false;
                VehicleStatus.Visible = false;
                UpdateVehicle.Visible = false;
            }
        }
        protected void BtnSearchVehicle_Click(object sender, EventArgs e)
        {
            String BDstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                try
                {
                    String query = "SELECT * from Vehicle where (VehicleID = @vehicleId) OR (Name LIKE '%' + @VehicleName + '%')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@vehicleId", SearchTextBox.Text);
                    cmd.Parameters.AddWithValue("@VehicleName", SearchTextBox.Text);
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
        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            VehicleID.Visible = true;
            VehicleName.Visible = true;
            VehicleNumber.Visible = true;
            VehicleChassisNumber.Visible = true;
            VehicleOwner.Visible = true;
            VehicleStatus.Visible = true;
            UpdateVehicle.Visible = true;
            VehicleID.Text = GridView.SelectedRow.Cells[1].Text;
            VehicleName.Text = GridView.SelectedRow.Cells[2].Text;
            VehicleNumber.Text = GridView.SelectedRow.Cells[3].Text;
            VehicleChassisNumber.Text = GridView.SelectedRow.Cells[4].Text;
            VehicleOwner.Text = GridView.SelectedRow.Cells[5].Text;
            VehicleStatus.Text = GridView.SelectedRow.Cells[6].Text;
            VehicleID.ReadOnly = true;
            VehicleStatus.ReadOnly = true;
        }

        protected void UpdateVehicle_Click(object sender, EventArgs e)
        {
            String BDstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                try
                {
                    String query = "UPDATE Vehicle SET Name=@name,Number=@Number,ChassisNumber=@CNumber,OwnerName=@ownerName,Status=@status where VehicleID = @VehicleId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@VehicleId",VehicleID.Text);
                    cmd.Parameters.AddWithValue("@name", VehicleName.Text);
                    cmd.Parameters.AddWithValue("@Number", VehicleNumber.Text);
                    cmd.Parameters.AddWithValue("@CNumber", VehicleChassisNumber.Text);
                    cmd.Parameters.AddWithValue("@ownerName", VehicleOwner.Text);
                    cmd.Parameters.AddWithValue("@status", VehicleStatus.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Data update successfully')");
                }
                catch (SqlException exe)
                {
                    throw exe;
                }
            }
        }
    }
}