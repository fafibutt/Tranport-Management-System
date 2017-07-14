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
    public partial class AssignRouteToVehicle : System.Web.UI.Page
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
                        ListItem liVehicle = new ListItem("Select Vehicle", "-1");
                        VehicleDropDown.Items.Insert(0, liVehicle);
                    }

                }
                using (SqlConnection con = new SqlConnection(DBstring))
                {
                    String q2 = "SELECT RouteID,Name from Route";
                    SqlDataAdapter sda = new SqlDataAdapter(q2, con);
                    DataTable dt2 = new DataTable();
                    sda.Fill(dt2);
                    if (dt2.Columns.Count != 0)
                    {
                        RouteDropDown.DataSource = dt2;
                        RouteDropDown.DataTextField = "Name";
                        RouteDropDown.DataValueField = "RouteID";
                        RouteDropDown.DataBind();
                        ListItem liRoute = new ListItem("Select Route", "-1");
                        RouteDropDown.Items.Insert(0, liRoute);
                    }
                }
            }
        }

        protected void AssignRoute_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DBstring))
            {
                String query = "Insert into VehicleRoute(VehicleID,RouteID,VehicleNumber,RouteName) values(@vehicleId,@routeId,@vehicleNumber,@routeName)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@vehicleId", VehicleDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@routeId", RouteDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@vehicleNumber", VehicleDropDown.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@routeName", RouteDropDown.SelectedItem.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "confirm('Assignment complete')");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}