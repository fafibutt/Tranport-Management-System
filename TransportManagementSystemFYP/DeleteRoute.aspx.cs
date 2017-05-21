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
    public partial class DeleteRoute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = GridView.DataKeys[e.RowIndex].Values[0].ToString();
            String BDstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                try
                {
                    String query = "DELETE from Route where RouteID = @routeId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@routeId", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException exe)
                {
                    throw exe;
                }
            }
      
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
    }
}