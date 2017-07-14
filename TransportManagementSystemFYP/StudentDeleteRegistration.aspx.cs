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
    public partial class StudentDeleteRegistration : System.Web.UI.Page
    {
        String Dstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        public void BindData()
        {
            if (Session["UniId"] != null)
            {
                TextBox1.Text = Session["UniId"].ToString();
                String id = TextBox1.Text;
                using (SqlConnection con = new SqlConnection(Dstring))
                {
                    String query = "SELECT * FROM [TransportManagementSystem].[dbo].[StudentRegistration] where [UniID] =@uniId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@uniId", id);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    if (sdr.HasRows)
                    {
                        dt.Load(sdr);
                        GridView.DataSource = dt;
                        GridView.DataBind();
                    }
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
                    String query = "DELETE from StudentRegistration where UniID = @uniId ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uniId", id);
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