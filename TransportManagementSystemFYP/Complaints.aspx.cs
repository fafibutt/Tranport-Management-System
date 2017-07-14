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
    public partial class Complaints : System.Web.UI.Page
    {
        String DBString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CID.Visible = false;
                UniID.Visible = false;
                StudentComplaint.Visible = false;
                ComplaintDecision.Visible = false;
                SendDecision.Visible = false;
            }
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            CID.Visible = true;
            UniID.Visible = true;
            StudentComplaint.Visible = true;
            ComplaintDecision.Visible = true;
            CID.Text = GridView.SelectedRow.Cells[1].Text;
            UniID.Text=GridView.SelectedRow.Cells[2].Text;
            StudentComplaint.Text = GridView.SelectedRow.Cells[3].Text;
        }

        protected void SendDecision_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DBString))
            {
                String query = "INSERT into Complaint(ComplaintID,UniID,Complaint,Decision) values(@cId,@uId,@cplt,@des)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cId", CID.Text);
                cmd.Parameters.AddWithValue("@uId", UniID.Text);
                cmd.Parameters.AddWithValue("@cplt", StudentComplaint.Text);
                cmd.Parameters.AddWithValue("@des", ComplaintDecision.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                String Query = "Delete from StudentComplaint where ComplaintID = @cID";
                SqlCommand cmd1 = new SqlCommand(Query, conn);
                cmd1.Parameters.AddWithValue("@cID", CID.Text);
                cmd1.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "confirm('Your decision has been save sceessully')");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}