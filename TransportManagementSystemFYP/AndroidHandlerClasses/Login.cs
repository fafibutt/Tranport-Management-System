using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TransportManagementSystemFYP.AndroidHandlerClasses
{
    public class Login
    {
        String role = "";
        String DbString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
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