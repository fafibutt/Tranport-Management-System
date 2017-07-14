using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TransportManagementSystemFYP.AndroidHandlerClasses
{
    /// <summary>
    /// Summary description for AndroidService
    /// </summary>
    [WebService(Namespace = "http://gifttms.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AndroidService : System.Web.Services.WebService
    {
        String DbString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        String role = "";
        String id = "";
        [WebMethod]
        public void CreateNewAccount(string UniversityID, string Name, string Email, string password)
        {
            using (SqlConnection conn = new SqlConnection(DbString))
            {
                String query = "INSERT into UserDetail(UniID,Name,Email,Password,Designation) Values(@uniId,@name,@email,@password,'Student')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@uniId", UniversityID);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        [WebMethod]
        public String UserAuthentication(string userName, string password)
        {
            String auth = "";
            using (SqlConnection conn = new SqlConnection(DbString))
            {

                String Query = "SELECT UniID,Email,Password,Designation from UserDetail where Email =@email and Password = @pass";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@email", userName);
                cmd.Parameters.AddWithValue("@pass", password);
                conn.Open();
                SqlDataReader SDR = cmd.ExecuteReader();
                int count = 0;
                while (SDR.Read())
                {
                    count += 1;
                    role = SDR["Designation"].ToString();
                }
                if (count == 1)
                {
                    if (role.Trim() == "Admin")
                    {
                        auth = "Admin";
                    }
                    else if (role.Trim() == "Student")
                    {
                        auth = "Student";
                    }
                    else
                    {
                        auth = "Parent";
                    }
                }
                else
                {
                    auth = "";
                }
                
            }
            return auth;


        }
    }
}
