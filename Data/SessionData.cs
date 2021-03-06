﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data
{
    public class SessionData
    {
        private String connString;

        public SessionData(String connString)
        {
            this.connString = connString;
        }

        public String register(String username, String password, int age, char gender)
        {
            
            String result = "OK";

            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                String procedure = "spRegisterClient";

                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@name", username));
                command.Parameters.Add(new SqlParameter("@password", password));
                command.Parameters.Add(new SqlParameter("@age", age));
                command.Parameters.Add(new SqlParameter("@gender", gender));

                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }

            return result;
        }

        public String login (String username, String password)
        {
            String procedure = "spLogin";
            String type = "No Answer";

            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@username", username));
                command.Parameters.Add(new SqlParameter("@password", password));

                try
                {
                    connection.Open();
                    type = (String) command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return type;
        }

    }

}
