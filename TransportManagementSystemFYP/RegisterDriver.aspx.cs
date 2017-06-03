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
    public partial class RegisterDriver : System.Web.UI.Page
    {
        String DbString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
      
            }
        }

        protected void DriverRegistration_Click(object sender, EventArgs e)
        {
            String Status = "Active";
            using (SqlConnection conn = new SqlConnection(DbString))
            {
                String query = "select CNIC from Driver where CNIC = @cnic";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@cnic",DriverCNIC.Text);
                SqlDataAdapter SDA = new SqlDataAdapter(command);
                DataTable DT = new DataTable();
                SDA.Fill(DT);
                if (DT.Rows.Count != 1)
                {
                    try
                    {
                        String Query = "INSERT into Driver(Name,City,Address,PhoneNumber,CNIC,LicenceNumber,Status) values(@name,@city,@address,@number,@cnic,@LN,@status)";
                        SqlCommand sqlCommand = new SqlCommand(Query, conn);
                        sqlCommand.Parameters.AddWithValue("@name", DriverName.Text);
                        sqlCommand.Parameters.AddWithValue("@city", DriverCity.Text);
                        sqlCommand.Parameters.AddWithValue("@address", DriverAddress.Text);
                        sqlCommand.Parameters.AddWithValue("@number", DriverNumber.Text);
                        sqlCommand.Parameters.AddWithValue("@cnic", DriverCNIC.Text);
                        sqlCommand.Parameters.AddWithValue("@LN", LicenceNumber.Text);
                        sqlCommand.Parameters.AddWithValue("@status", Status);
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Data insert successfully')");
                    }
                    catch (SqlException sqlExce)
                    {
                        throw sqlExce;
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Data already exist')");
                }
            }
        }
    }
}