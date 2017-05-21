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
    public partial class EditDriver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DriverID.Visible = false;
                DriverName.Visible = false;
                DriverCity.Visible = false;
                DriverAddress.Visible = false;
                DriverNumber.Visible = false;
                DriverCNIC.Visible = false;
                LicenceNumber.Visible = false;
                DriverStatus.Visible = false;
                UpdateDriver.Visible = false;
            }
        }

        protected void BtnSearchDriver_Click(object sender, EventArgs e)
        {
            String BDstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                try
                {
                    String query = "SELECT * from Driver where (DriverID = @driverId) OR (Name LIKE '%' + @DriverName + '%')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@driverId", SearchTextBox.Text);
                    cmd.Parameters.AddWithValue("@DriverName", SearchTextBox.Text);
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

        protected void UpdateDriver_Click(object sender, EventArgs e)
        {
            String BDstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                try
                {
                    String query = "UPDATE Driver SET Name=@name,City=@city,Address=@address,PhoneNumber=@number,CNIC=@cnic,LicenceNumber=@li,Status=@status where DriverID = @driverId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@driverId", DriverID.Text);
                    cmd.Parameters.AddWithValue("@name",DriverName.Text);
                    cmd.Parameters.AddWithValue("@city", DriverCity.Text);
                    cmd.Parameters.AddWithValue("@address", DriverAddress.Text);
                    cmd.Parameters.AddWithValue("@number", DriverNumber.Text);
                    cmd.Parameters.AddWithValue("@cnic", DriverCNIC.Text);
                    cmd.Parameters.AddWithValue("@li", LicenceNumber.Text);
                    cmd.Parameters.AddWithValue("@status", DriverStatus.Text);
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

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriverID.Visible = true;
            DriverName.Visible = true;
            DriverCity.Visible = true;
            DriverAddress.Visible = true;
            DriverNumber.Visible = true;
            DriverCNIC.Visible = true;
            LicenceNumber.Visible = true;
            DriverStatus.Visible = true;
            UpdateDriver.Visible = true;
            DriverID.Text = GridView.SelectedRow.Cells[1].Text;
            DriverName.Text = GridView.SelectedRow.Cells[2].Text;
            DriverCity.Text = GridView.SelectedRow.Cells[3].Text;
            DriverAddress.Text= GridView.SelectedRow.Cells[4].Text;
            DriverNumber.Text= GridView.SelectedRow.Cells[5].Text;
            DriverCNIC.Text = GridView.SelectedRow.Cells[6].Text;
            LicenceNumber.Text = GridView.SelectedRow.Cells[7].Text;
            DriverStatus.Text = GridView.SelectedRow.Cells[8].Text;
            DriverID.ReadOnly = true;
            DriverStatus.ReadOnly = true;

        }
    }
}