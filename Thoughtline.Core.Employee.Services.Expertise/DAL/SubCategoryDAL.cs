using System.Data.SqlClient;
using System.Data;
using Thoughtline.Core.Employee.Services.Expertise.Models;

namespace Thoughtline.Core.Employee.Services.Expertise.DAL
{
    public class SubCategoryDAL
    {
        public MyResponse AddSubCategory(SubCategory subCategory)
        {
            MyResponse response = new MyResponse();
            int i = 0;            
            string strCon = "server = 192.168.5.11; Database = TLTSMEDB; User Id = sa; Password = Apple123!";
           
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand("DBO.InsertSubCategories", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SubCategoryName", subCategory.SubCategoryName);
                        cmd.Parameters.AddWithValue("@Description", subCategory.Description);
                        cmd.Parameters.AddWithValue("@IsActive", subCategory.IsActive);
                        cmd.Parameters.AddWithValue("@IsDeleted", subCategory.IsDeleted);
                        cmd.Parameters.AddWithValue("@InsertedUserID", subCategory.InsertedUserID);
                        cmd.Parameters.AddWithValue("@UpdatedUserID", subCategory.UpdatedUserID);
                        con.Open();
                        i = cmd.ExecuteNonQuery();
                    }
                }
            response.StatusCode = true;
            return response;            
        }
        public List<SubCategory> GetSubCategories()
        {
            MyResponse response = new MyResponse();
            List<SubCategory> listSubCategories = new List<SubCategory>();
           
            string strCon = "server = 192.168.5.11; Database = TLTSMEDB; User Id = sa; Password = Apple123!";
            //Create the SqlConnection object
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand("GetSubCategories", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                    
                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                    
                while (sdr.Read())
                {
                    listSubCategories.Add(new SubCategory
                    {
                        SubCategoryName = sdr["SubCategoryName"].ToString(),
                        Description = sdr["Description"].ToString()
                    });
                }
            }         
            
            return listSubCategories;
        }
    }
}
