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
    public partial class DeleteStudent : System.Web.UI.Page
    {
        String DBstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSearchStudent_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DBstring))
            {
                try
                {
                    String query = "SELECT * from Student where (UniID LIKE '%' + @search + '%' OR Name LIKE '%' + @search + '%') AND Status = 'Active'";
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
            using (SqlConnection conn = new SqlConnection(DBstring))
            {
                try
                {
                    String query = "UPDATE Student SET Status = 'DeActive' where UniID = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
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