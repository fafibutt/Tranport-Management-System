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
    public partial class EditStop : System.Web.UI.Page
    {
        String BDstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                StopID.Visible = false;
                StopName.Visible = false;
                StopLocation.Visible = false;
                StopRoute.Visible = false;
                UpdateStop.Visible = false;
            }
        }

        protected void BtnSearchStop_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                String query = "SELECT StopID,Name,Location,RouteID from Stop where (StopID LIKE '%' + @search + '%') OR (Name LIKE '%' + @search + '%')";
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

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopID.Visible = true;
            StopName.Visible = true;
            StopLocation.Visible = true;
            StopRoute.Visible = true;
            UpdateStop.Visible = true;
            StopID.Text = GridView.SelectedRow.Cells[1].Text;
            StopName.Text = GridView.SelectedRow.Cells[2].Text;
            StopLocation.Text = GridView.SelectedRow.Cells[3].Text;
            StopRoute.Text = GridView.SelectedRow.Cells[4].Text;

            StopID.ReadOnly = true;
            StopRoute.ReadOnly = true;
        }

        protected void UpdateStop_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                try
                {
                    String query = "UPDATE Stop SET Name=@name,Location=@lo,RouteID=@route where StopID = @stopId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@stopId", StopID.Text);
                    cmd.Parameters.AddWithValue("@name", StopName.Text);
                    cmd.Parameters.AddWithValue("@lo", StopLocation.Text);
                    cmd.Parameters.AddWithValue("@route", StopRoute.Text);
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