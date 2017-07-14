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
    public partial class DeleteStop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnSearchStop_Click(object sender, EventArgs e)
        {
            String BDstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(BDstring))
                {
                    String query = "SELECT * from Stop where (StopID LIKE '%' + @search + '%') OR (Name LIKE '%' + @search + '%')";
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
            }
            catch (SqlException exe)
            {
                throw exe;
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
                    String query = "DELETE from Stop where StopID = @stopId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@stopId", id);
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