using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Thoughtline.Core.Employee.Services.Expertise.Models;

namespace Thoughtline.Core.Employee.Services.Expertise.DAL
{
    public class CategoryDAL
    {
        public MyResponse AddCategory(Category category)
        {
            MyResponse response = new MyResponse();
            int i = 0;           
            string strCon = "server = 192.168.5.11; Database = TLTSMEDB; User Id = sa; Password = Apple123!";
            
            using (SqlConnection con = new SqlConnection(strCon))
            {
                using (SqlCommand cmd = new SqlCommand("DBO.InsertCategories", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    cmd.Parameters.AddWithValue("@Description", category.Description);
                    cmd.Parameters.AddWithValue("@IsActive", category.IsActive);
                    cmd.Parameters.AddWithValue("@IsDeleted", category.IsDeleted);
                    cmd.Parameters.AddWithValue("@InsertedUserID", category.InsertedUserID);
                    cmd.Parameters.AddWithValue("@UpdatedUserID", category.UpdatedUserID);
                    con.Open();
                    i= cmd.ExecuteNonQuery();
                }
            }
            response.StatusCode = true;
            return response;
        }
        public List<Category> GetCategories()
        {
            MyResponse response = new MyResponse();          
            List<Category> listCategories = new List<Category>();           
            string strCon = "server = 192.168.5.11; Database = TLTSMEDB; User Id = sa; Password = Apple123!";
            //Create the SqlConnection object
            using (SqlConnection connection = new SqlConnection(strCon))
            {                    
                SqlCommand cmd = new SqlCommand("GetCategories", connection)
                {                        
                    CommandType = CommandType.StoredProcedure
                };
                //Open the Connection
                connection.Open();                    
                SqlDataReader sdr = cmd.ExecuteReader();
                //Read the data from the SqlDataReader 
                //Read() method will returns true as long as data is there in the SqlDataReader
                while (sdr.Read())
                {
                    listCategories.Add(new Category
                    {
                        CategoryName =sdr["CategoryName"].ToString(),
                        Description = sdr["Description"].ToString()
                    });
                }
            }            
            return listCategories;
        }
    }   
}
