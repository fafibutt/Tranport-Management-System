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
    public partial class StudentRegistration : System.Web.UI.Page
    {
        String DbString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
                using (SqlConnection con = new SqlConnection(DbString))
                {
                    String query = "SELECT City,RouteID From Route";
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(query,con);
                    sda.Fill(dt);
                    if (dt.Columns.Count != 0)
                    {
                        StudentCity.DataSource = dt;
                        StudentCity.DataTextField = "City";
                        StudentCity.DataValueField = "RouteID";
                        StudentCity.DataBind();
                    }
                    ListItem liCity = new ListItem("Select City", "-1");
                    StudentCity.Items.Insert(0, liCity);

                    ListItem liRoute = new ListItem("Select Route", "-1");
                    StudentRoute.Items.Insert(0, liRoute);

                    ListItem liStop = new ListItem("Select Stop", "-1");
                    StudentStop.Items.Insert(0, liCity);

                    StudentRoute.Enabled = false;
                    StudentStop.Enabled = false;
                }
            }
        }
        protected void StudentCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StudentCity.SelectedValue == "-1")
            {
                StudentRoute.SelectedIndex = 0;
                StudentStop.SelectedIndex = 0;
                StudentRoute.Enabled = false;
                StudentStop.Enabled = false;
            }
            else
            {
                StudentRoute.Enabled = true;
                using (SqlConnection con = new SqlConnection(DbString))
                {
                    String query = "Select Name,RouteID from Route where City = @city";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@city", StudentCity.SelectedItem.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Columns.Count != 0)
                    {
                        StudentRoute.DataSource = dt;
                        StudentRoute.DataTextField = "Name";
                        StudentRoute.DataValueField = "RouteID";
                        StudentRoute.DataBind();

                        ListItem liRoute = new ListItem("Select Route", "-1");
                        StudentRoute.Items.Insert(0, liRoute);

                        StudentStop.SelectedIndex = 0;
                        StudentStop.Enabled = false;
                    }

                }
            }
        }
        protected void StudentRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StudentRoute.SelectedValue == "-1")
            {
                StudentStop.SelectedIndex = 0;
                StudentStop.Enabled = false;
            }
            else
            {
                StudentStop.Enabled = true;
                using (SqlConnection con = new SqlConnection(DbString))
                {
                    String query = "SELECT Name,RouteID FROM Stop where RouteID = @routeId ";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@routeId", StudentRoute.SelectedValue);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Columns.Count != 0)
                    {
                        StudentStop.DataSource = dt;
                        StudentStop.DataTextField = "Name";
                        StudentStop.DataValueField = "RouteID";
                        StudentStop.DataBind();

                        ListItem liStop = new ListItem("Select Stop","-1");
                        StudentStop.Items.Insert(0, liStop);
                    }
                }
            }
        }
        protected void RegistrationStudent_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DbString))
            {
                String query = "select UniID,Name from StudentRegistration where UniID =@uniId and Name = @name";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@uniId", UniID.Text);
                command.Parameters.AddWithValue("@name",StudentName.Text);
                SqlDataAdapter SDA = new SqlDataAdapter(command);
                DataTable DT = new DataTable();
                SDA.Fill(DT);
                if (DT.Rows.Count != 1)
                {
                    try
                    {
                        String Query = "INSERT into StudentRegistration(UniID,Name,CNIC,Address,PhoneNumber,City,Route,Stop) values(@uniId,@name,@cnic,@address,@number,@city,@route,@stop)";
                        SqlCommand sqlCommand = new SqlCommand(Query, conn);
                        sqlCommand.Parameters.AddWithValue("@uniId",UniID.Text);
                        sqlCommand.Parameters.AddWithValue("@name",StudentName.Text);
                        sqlCommand.Parameters.AddWithValue("@cnic", StudentCNIC.Text);
                        sqlCommand.Parameters.AddWithValue("@address", StudentAddress.Text);
                        sqlCommand.Parameters.AddWithValue("@number", StudentNumber.Text);
                        sqlCommand.Parameters.AddWithValue("@city", StudentCity.SelectedItem.Text);                                      
                        sqlCommand.Parameters.AddWithValue("@route", StudentRoute.SelectedItem.Text);
                        sqlCommand.Parameters.AddWithValue("@stop", StudentStop.SelectedItem.Text);
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "confirm('Student register successfully')");
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                    catch (SqlException sqlExce)
                    {
                        throw sqlExce;
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "confirm('Student already exist')");
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }  
    }
}