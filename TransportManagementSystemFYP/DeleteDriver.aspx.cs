using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace TransportManagementSystemFYP
{
    public partial class DeleteDriver : System.Web.UI.Page
    {
        String DbString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnSearchDriver_Click(object sender, EventArgs e)
        {


            using (SqlConnection conn = new SqlConnection(DbString))
            {
                try
                {
                    String query = "SELECT * from Driver where (DriverID LIKE '%' + @search + '%') OR (Name LIKE '%' + @search + '%') AND Status = 'Active'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", SearchTextBox.Text);
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
        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = GridView.DataKeys[e.RowIndex].Values[0].ToString();
            using (SqlConnection conn = new SqlConnection(DbString))
            {
                try
                {
                    String query = "update driver set Status = 'Unactive' where DriverID = @driverId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@driverId", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                catch (SqlException exe)
                {
                    throw exe;
                }
            }
        }
    }
}