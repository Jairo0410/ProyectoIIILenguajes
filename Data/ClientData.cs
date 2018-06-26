using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ClientData
    {
        private String connString;

        public ClientData(String connString)
        {
            this.connString = connString;
        }

        public String addToCart(String clientName, int itemID)
        {
            String result = "OK";

            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                String procedure = "spAddToCart";

                SqlCommand command = new SqlCommand(procedure, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@code", itemID));
                command.Parameters.Add(new SqlParameter("@c_name", clientName));

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

        public String removeFromCart(String clientName, int itemID)
        {
            String result = "OK";

            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                String procedure = "spRemoveFromCart";

                SqlCommand command = new SqlCommand(procedure, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@code", itemID));
                command.Parameters.Add(new SqlParameter("@c_name", clientName));

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

        public LinkedList<Item> getCart(String c_name, String date)
        {
            LinkedList<Item> items = new LinkedList<Item>();

            DataSet dataSetCategories = new DataSet();

            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                String sqlSelect = "spGetCart";

                SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
                sqlDataAdapterClient.SelectCommand = new SqlCommand();
                sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
                sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@c_name", c_name));
                sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@date", date));
                sqlDataAdapterClient.SelectCommand.Connection = connection;

                sqlDataAdapterClient.Fill(dataSetCategories, "Item");
            }

            DataRowCollection dataRowCollection = dataSetCategories.Tables["Item"].Rows;


            foreach (DataRow currentRow in dataRowCollection)
            {
                Item currentItem = new Item();
                currentItem.Code = int.Parse(currentRow["code"].ToString());
                currentItem.Name = currentRow["i_name"].ToString();
                currentItem.Price = float.Parse(currentRow["final_price"].ToString());
                items.AddLast(currentItem);
            } // foreeach

            return items;
        }
    }
}
