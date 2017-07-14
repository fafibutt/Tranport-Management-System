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
    public partial class RegisterStudent : System.Web.UI.Page
    {
        String DbString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DbString))
            {
                String Q = "SELECT * from Student where UniID = @uniId";
                SqlCommand command = new SqlCommand(Q, conn);
                command.Parameters.AddWithValue("@uniId", GridView.SelectedRow.Cells[0].Text);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    String query = "UPDATE Student SET UniID=@uniId,Name=@name,CNIC=@cnic,Address=@address,PhoneNumber=@number,City=@city,Route=@route,Stop=@stop,Status@status where UniID = @uniId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uniId",GridView.SelectedRow.Cells[1].Text);
                    cmd.Parameters.AddWithValue("@name", GridView.SelectedRow.Cells[2].Text);
                    cmd.Parameters.AddWithValue("@cnic",Convert.ToInt32( GridView.SelectedRow.Cells[3].Text));
                    cmd.Parameters.AddWithValue("@address", GridView.SelectedRow.Cells[4].Text);
                    cmd.Parameters.AddWithValue("@number",Convert.ToInt32( GridView.SelectedRow.Cells[5].Text));
                    cmd.Parameters.AddWithValue("@city", GridView.SelectedRow.Cells[6].Text);
                    cmd.Parameters.AddWithValue("@route", GridView.SelectedRow.Cells[7].Text);
                    cmd.Parameters.AddWithValue("@stop", GridView.SelectedRow.Cells[8].Text);
                    cmd.Parameters.AddWithValue("@status", "Active");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    String Query = "Delete FROM StudentRegistration where UniID = @uniId";
                    SqlCommand cmd1 = new SqlCommand(Query, conn);
                    cmd1.Parameters.AddWithValue("@uniId", GridView.SelectedRow.Cells[0].Text);
                    cmd1.ExecuteNonQuery();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    String query = "INSERT into Student(UniID,Name,CNIC,Address,PhoneNumber,City,Route,Stop,Status) values(@uniId,@name,@cnic,@address,@number,@city,@route,@stop,@status)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uniId",  GridView.SelectedRow.Cells[1].Text);
                    cmd.Parameters.AddWithValue("@name", GridView.SelectedRow.Cells[2].Text);
                    cmd.Parameters.AddWithValue("@cnic",Convert.ToInt32( GridView.SelectedRow.Cells[3].Text));
                    cmd.Parameters.AddWithValue("@address", GridView.SelectedRow.Cells[4].Text);
                    cmd.Parameters.AddWithValue("@number",Convert.ToInt32( GridView.SelectedRow.Cells[5].Text));
                    cmd.Parameters.AddWithValue("@city", GridView.SelectedRow.Cells[6].Text);
                    cmd.Parameters.AddWithValue("@route", GridView.SelectedRow.Cells[7].Text);
                    cmd.Parameters.AddWithValue("@stop", GridView.SelectedRow.Cells[8].Text);
                    cmd.Parameters.AddWithValue("@status", "Active");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    String Query = "Delete FROM StudentRegistration where UniID = @uniId";
                    SqlCommand cmd1 = new SqlCommand(Query, conn);
                    cmd1.Parameters.AddWithValue("@uniId", GridView.SelectedRow.Cells[0].Text);
                    cmd1.ExecuteNonQuery();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }

            }
        }
    }
}