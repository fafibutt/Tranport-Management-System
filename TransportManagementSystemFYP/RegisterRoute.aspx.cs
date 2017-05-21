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
    public partial class RegisterRoute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            }
        }

        protected void RouteRegistration_Click(object sender, EventArgs e)
        {
            String DBString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(DBString))
            {              
                String query = "select RouteID,Name from Route where RouteID =@routeId and Name = @name";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@routeId", RouteID.Text);
                command.Parameters.AddWithValue("@name",RouteName.Text);
                SqlDataAdapter SDA = new SqlDataAdapter(command);
                DataTable DT = new DataTable();
                SDA.Fill(DT);
                if (DT.Rows.Count != 1)
                {
                    try
                    {
                        String Query = "INSERT into Route(RouteID,Name,City,Road) values(@routeId,@name,@city,@road)";
                        SqlCommand sqlCommand = new SqlCommand(Query, conn);
                        sqlCommand.Parameters.AddWithValue("@routeId", RouteID.Text);
                        sqlCommand.Parameters.AddWithValue("@name", RouteName.Text);
                        sqlCommand.Parameters.AddWithValue("@city", RouteCity.Text);
                        sqlCommand.Parameters.AddWithValue("@road", RouteRoad.Text);
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