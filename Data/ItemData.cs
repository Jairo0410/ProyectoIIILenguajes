using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Domain;

namespace Business
{
    public class ItemData
    {
        private String connString;
        public ItemData(String connString)
        {
            this.connString = connString;
        }

        public String addCategory(String categoryName)
        {
            String result = "OK";

            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                String procedure = "spAddCategory";

                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@name", categoryName));

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

        public LinkedList<String> getCategories()
        {
            LinkedList<String> categories = new LinkedList<String>();

            DataSet dataSetCategories = new DataSet();

            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                String sqlSelect = "spGetCategories";

                SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
                sqlDataAdapterClient.SelectCommand = new SqlCommand();
                sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
                sqlDataAdapterClient.SelectCommand.Connection = connection;

                sqlDataAdapterClient.Fill(dataSetCategories, "Category");
            }

            DataRowCollection dataRowCollection = dataSetCategories.Tables["Category"].Rows;
                

            foreach (DataRow currentRow in dataRowCollection)
            {
                String currentCategory = currentRow["cat_name"].ToString();
                categories.AddLast(currentCategory);
            } // foreeach
            

            return categories;
        }

        public String addItem(String name, float price, String description, String imageRoute, String category)
        {
            String result = "OK";

            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                String procedure = "spAddItem";

                SqlCommand command = new SqlCommand(procedure, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@name", name));
                command.Parameters.Add(new SqlParameter("@price", price));
                command.Parameters.Add(new SqlParameter("@description", description));
                command.Parameters.Add(new SqlParameter("@image_route", imageRoute));
                command.Parameters.Add(new SqlParameter("@category", category));

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

        public LinkedList<Item> getItems(String date)
        {
            LinkedList<Item> items = new LinkedList<Item>();

            DataSet dataSetCategories = new DataSet();

            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                String sqlSelect = "spGetItems";

                SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
                sqlDataAdapterClient.SelectCommand = new SqlCommand();
                sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
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
                currentItem.Price= float.Parse(currentRow["price"].ToString());
                currentItem.Description = currentRow["description"].ToString();
                currentItem.Image_route = currentRow["image_route"].ToString();
                currentItem.Category = currentRow["category"].ToString();
                currentItem.Discount = float.Parse(currentRow["percentage"].ToString());
                items.AddLast(currentItem);
            } // foreeach

            return items;
        }
    }
}
