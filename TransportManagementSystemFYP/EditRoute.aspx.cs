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
    public partial class EditRoute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RouteID.Visible = false;
                RouteName.Visible = false;
                RouteCity.Visible = false;
                RouteRoad.Visible = false;
                UpdateRoute.Visible = false;
            }
        }

        protected void BtnSearchRoute_Click(object sender, EventArgs e)
        {
            String BDstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                String query = "SELECT * from Route where (RouteID = @routeId) OR (Name LIKE '%' + @RouteName + '%')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@routeId", SearchTextBox.Text);
                cmd.Parameters.AddWithValue("@RouteName", SearchTextBox.Text);
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
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RouteID.Visible = true;
            RouteName.Visible = true;
            RouteCity.Visible = true;
            RouteRoad.Visible = true;
            UpdateRoute.Visible = true;
            RouteID.Text = GridView.SelectedRow.Cells[1].Text;
            RouteName.Text = GridView.SelectedRow.Cells[2].Text;
            RouteCity.Text = GridView.SelectedRow.Cells[3].Text;
            RouteRoad.Text = GridView.SelectedRow.Cells[4].Text;
            RouteID.ReadOnly = true;
        }

        protected void UpdateRoute_Click(object sender, EventArgs e)
        {
            String BDstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                try
                {
                    String query = "UPDATE Route SET Name=@name,City=@city,Road=@road where RouteID = @routeId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@routeId", RouteID.Text);
                    cmd.Parameters.AddWithValue("@name", RouteName.Text);
                    cmd.Parameters.AddWithValue("@city", RouteCity.Text);
                    cmd.Parameters.AddWithValue("@road", RouteRoad.Text);
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