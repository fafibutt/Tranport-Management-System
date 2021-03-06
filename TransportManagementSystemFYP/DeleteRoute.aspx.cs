﻿using System;
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
    public partial class DeleteRoute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSearchRoute_Click(object sender, EventArgs e)
        {

            String BDstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                String query = "SELECT * from Route where (RouteID LIKE '%'+ @search + '%') OR (Name LIKE '%' + @search + '%')";
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

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = GridView.DataKeys[e.RowIndex].Values[0].ToString();
            String BDstring = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(BDstring))
            {
                try
                {
                    String query = "DELETE from Route where RouteID = @routeId ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@routeId", id);
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