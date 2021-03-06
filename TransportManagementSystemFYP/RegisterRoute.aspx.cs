﻿using System;
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
        String DBString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            }
        }

        protected void RouteRegistration_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DBString))
            {
                try
                {
                    String Query = "if not exists(Select * from Route) INSERT into Route(Name,City,Road) values(@name,@city,@road)";
                    SqlCommand sqlCommand = new SqlCommand(Query, conn);
                    sqlCommand.Parameters.AddWithValue("@name", RouteName.Text);
                    sqlCommand.Parameters.AddWithValue("@city", RouteCity.Text);
                    sqlCommand.Parameters.AddWithValue("@road", RouteRoad.Text);
                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "confirm('Route register successfully')");
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                catch (SqlException sqlExce)
                {
                    throw sqlExce;
                }
            }
        }
    }
}