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
    public partial class EditStudent : System.Web.UI.Page
    {
        String BDstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UniID.Visible = false;
                StudentName.Visible = false;
                StudentCNIC.Visible = false;
                StudentAddress.Visible = false;
                StudentNumber.Visible = false;
                UpdateStudent.Visible = false;
            }
        }

        protected void BtnSearchVehicle_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                try
                {
                    String query = "SELECT UniID,Name,CNIC,Address,PhoneNumber from Student where (UniID LIKE '%' + @search + '%' OR Name LIKE '%' + @search + '%') AND Status = 'Active'";
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

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UniID.Visible = true;
            StudentName.Visible = true;
            StudentCNIC.Visible = true;
            StudentAddress.Visible = true;
            StudentNumber.Visible = true;
            UpdateStudent.Visible = true;
            UniID.Text = GridView.SelectedRow.Cells[1].Text;
            StudentName.Text = GridView.SelectedRow.Cells[2].Text;
            StudentCNIC.Text = GridView.SelectedRow.Cells[3].Text;
            StudentAddress.Text = GridView.SelectedRow.Cells[4].Text;
            StudentNumber.Text = GridView.SelectedRow.Cells[5].Text;
            UniID.ReadOnly = true;
        }

        protected void UpdateStudent_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                try
                {
                    String query = "UPDATE Student SET UniID=@uniId,Name=@name,CNIC=@cnic,Address=@address,PhoneNumber=@Number where UniID = @uniId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uniId", UniID.Text);
                    cmd.Parameters.AddWithValue("@name", StudentName.Text);
                    cmd.Parameters.AddWithValue("@cnic", StudentCNIC.Text);
                    cmd.Parameters.AddWithValue("@address", StudentAddress.Text);
                    cmd.Parameters.AddWithValue("@number", StudentNumber.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "confirm('Student Update Sccessfully')");
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