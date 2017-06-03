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
    public partial class RegisterStop : System.Web.UI.Page
    {
        String DbString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        DataTable DT = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ViewState["Stop"] == null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("name");
                    dt.Columns.Add("location");
                    dt.Columns.Add("routeId");
                    ViewState["Stop"] = dt;

                    using (SqlConnection conn = new SqlConnection(DbString))
                    {
                        try
                        {
                            DataTable DTs = new DataTable();
                            String query = "SELECT * from Route";
                            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
                            SDA.Fill(DTs);
                            RouteDropDown.DataSource = DTs;
                            RouteDropDown.DataTextField = "Name";
                            RouteDropDown.DataValueField = "RouteID";
                            RouteDropDown.DataBind();
                        }
                        catch (SqlException exe)
                        {
                            throw exe;
                        }
                    }
                }
            }
        }
        protected void AddStopToList_Click(object sender, EventArgs e)
        {
            DT = (DataTable)ViewState["Stop"];
            String name = StopName.Text;
            String location = StopLocation.Text;
            String Rid = RouteDropDown.SelectedItem.Value.ToString().Trim();

            DataRow row = DT.NewRow();
            row["name"] = name;
            row["location"] = location;
            row["routeId"] = Rid;

            DT.Rows.Add(row);
            GridView.DataSource = DT;
            GridView.DataBind();

            ViewState["Stop"] = DT;
            StopName.Text = "";
            StopLocation.Text = "";
        }

        protected void StopRegistration_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DbString))
            {
                try
                {
                    foreach (GridViewRow item in GridView.Rows)
                    {
                        using (SqlConnection con = new SqlConnection(DbString))
                        {
                            String Query = "if not exists(select * from Stop S where S.RouteID = @routeId and S.Name = @name)insert into Stop(Name,Location,RouteID) values(@name,@location,@routeId)";
                            SqlCommand cmd = new SqlCommand(Query, con);
                            cmd.Parameters.AddWithValue("@name", item.Cells[0].Text);
                            cmd.Parameters.AddWithValue("@location", item.Cells[1].Text);
                            cmd.Parameters.AddWithValue("@routeId", item.Cells[2].Text);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Data insert successfully')");
                        }
                    }
                }
                catch (SqlException exe)
                {
                    throw exe;
                }
            }
        }
    }
}