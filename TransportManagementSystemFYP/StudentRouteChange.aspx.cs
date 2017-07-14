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
    public partial class StudentRouteChange : System.Web.UI.Page
    {
        String DbString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
                BindData();
            }
        }

        public void BindData()
        {
            if (Session["UniId"] != null)
            {
                TextBox1.Text = Session["UniId"].ToString();
                String id = TextBox1.Text;
                using (SqlConnection con = new SqlConnection(DbString))
                {
                    String query = "SELECT UniID,City,Route,Stop FROM [TransportManagementSystem].[dbo].[StudentRegistration] where [UniID] =@uniId";
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
                    else
                    {
                        
                    }
                }
            }
        }
        protected void ddl_route_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlMake = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlMake.NamingContainer;
            if (row != null)
            {
                if ((row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlRoute = (DropDownList)row.FindControl("ddl_route");
                    DropDownList ddlStop = (DropDownList)row.FindControl("ddl_stop");

                    if (ddlRoute.SelectedValue == "-1")
                    {
                        ddlStop.SelectedIndex = 0;
                        ddlStop.Enabled = false;
                    }
                    else
                    {
                        ddlStop.Enabled = true;
                        using (SqlConnection con = new SqlConnection(DbString))
                        {
                            String query = "SELECT Name,RouteID FROM Stop where RouteID = @routeId ";
                            SqlDataAdapter sda = new SqlDataAdapter(query, con);
                            sda.SelectCommand.Parameters.AddWithValue("@routeId", ddlRoute.SelectedValue);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            if (dt.Columns.Count != 0)
                            {
                                ddlStop.DataSource = dt;
                                ddlStop.DataTextField = "Name";
                                ddlStop.DataValueField = "RouteID";
                                ddlStop.DataBind();

                                ListItem liStop = new ListItem("Select Stop", "-1");
                                ddlStop.Items.Insert(0, liStop);
                            }
                        }
                    }
                }
            }

        }

        protected void ddl_city_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlMake = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlMake.NamingContainer;
            if (row != null)
            {
                if ((row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlcity = (DropDownList)row.FindControl("ddl_city");
                    DropDownList ddlRoute = (DropDownList)row.FindControl("ddl_route");
                    DropDownList ddlStop = (DropDownList)row.FindControl("ddl_stop");

                    if (ddlcity.SelectedValue == "-1")
                    {
                        ddlRoute.SelectedIndex = 0;
                        ddlStop.SelectedIndex = 0;
                        ddlRoute.Enabled = false;
                        ddlStop.Enabled = false;
                    }
                    else
                    {
                        ddlRoute.Enabled = true;
                        using (SqlConnection con = new SqlConnection(DbString))
                        {
                            String query = "Select Name,RouteID from Route where City = @city";
                            SqlDataAdapter sda = new SqlDataAdapter(query, con);
                            sda.SelectCommand.Parameters.AddWithValue("@city", ddlcity.SelectedItem.Text);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            if (dt.Columns.Count != 0)
                            {
                                ddlRoute.DataSource = dt;
                                ddlRoute.DataTextField = "Name";
                                ddlRoute.DataValueField = "RouteID";
                                ddlRoute.DataBind();

                                ListItem liRoute = new ListItem("Select Route", "-1");
                                ddlRoute.Items.Insert(0, liRoute);

                                ddlStop.SelectedIndex = 0;
                                ddlStop.Enabled = false;
                            }

                        }
                    }
                }
            }
        }

        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView.EditIndex = -1;
            BindData();
        }

        protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string uniID = (GridView.Rows[e.RowIndex].FindControl("lbl_ID") as Label).Text;
            string city = (GridView.Rows[e.RowIndex].FindControl("ddl_City") as DropDownList).SelectedItem.Text;
            string route = (GridView.Rows[e.RowIndex].FindControl("ddl_route") as DropDownList).SelectedItem.Text;
            string stop = (GridView.Rows[e.RowIndex].FindControl("ddl_stop") as DropDownList).SelectedItem.Text;
            using (SqlConnection con = new SqlConnection(DbString))
            {
                string query = "INSERT into ChangeRouteRequest(UniID,City,Route,Stop) values(@id,@city,@route,@stop)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", uniID);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@route", route);
                cmd.Parameters.AddWithValue("@stop", stop);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "confirm('Your information update successfully')");
                Response.Redirect(Request.Url.AbsoluteUri);

            }
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView.EditIndex == e.Row.RowIndex)
            {
                using (SqlConnection con = new SqlConnection(DbString))
                {
                    DropDownList ddlCities = (DropDownList)e.Row.FindControl("ddl_city");
                    DropDownList ddlRoute = (DropDownList)e.Row.FindControl("ddl_route");
                    DropDownList ddlStop = (DropDownList)e.Row.FindControl("ddl_stop");
                    String query = "SELECT City,RouteID From Route";
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.Fill(dt);
                    if (dt.Columns.Count != 0)
                    {
                        ddlCities.DataSource = dt;
                        ddlCities.DataTextField = "City";
                        ddlCities.DataValueField = "RouteID";
                        ddlCities.DataBind();
                    }
                    ListItem liCity = new ListItem("Select City", "-1");
                    ddlCities.Items.Insert(0, liCity);

                    ListItem liRoute = new ListItem("Select Route", "-1");
                    ddlRoute.Items.Insert(0, liRoute);

                    ListItem liStop = new ListItem("Select Stop", "-1");
                    ddlStop.Items.Insert(0, liCity);

                    ddlRoute.Enabled = false;
                    ddlStop.Enabled = false;

                }
            }
        }
    }
}