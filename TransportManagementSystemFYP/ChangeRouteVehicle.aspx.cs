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
    public partial class ChangeRouteVehicle : System.Web.UI.Page
    {
        String DBstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RouteId.Visible = false;
                RouteName.Visible = false;
                VehicleDropDown.Visible = false;
                UpdateVehicle.Visible = false;
            }
        }

        protected void BtnSearchRoute_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBstring))
                {
                    String query = "SELECT  * from VehicleRoute where (RouteID LIKE '%' + @search + '%') OR (RouteName LIKE '%' + @search + '%')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", SearchTextBox.Text);
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable DT = new DataTable();
                    sda.Fill(DT);
                    if (DT.Columns.Count != 0)
                    {
                        GridView.DataSource = DT;
                        GridView.DataBind();
                    }
                }
            }
            catch (SqlException exe)
            {
                throw exe;
            }
        }

        protected void UpdateVehicle_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DBstring))
            {
                String query = "UPDATE VehicleRoute SET VehicleID=@vehicleId,RouteID=@routeId,VehicleNumber=@vehicleNumber,RouteName=@routeName where RouteID=@routeId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@vehicleId", VehicleDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@routeId", RouteId.Text);
                cmd.Parameters.AddWithValue("@vehicleNumber", VehicleDropDown.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@routeName", RouteName.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "confirm('Vehicle Route Change sccessfully')");
                Response.Redirect(Request.Url.AbsoluteUri);

            }
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RouteId.Visible = true;
            RouteName.Visible = true;
            VehicleDropDown.Visible = true;
            UpdateVehicle.Visible = true;
            RouteId.Text = GridView.SelectedRow.Cells[1].Text;
            RouteName.Text = GridView.SelectedRow.Cells[3].Text;
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
    }
}