using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Thoughtline.Core.Employee.Services.Expertise.DAL;
using Thoughtline.Core.Employee.Services.Expertise.Models;

namespace Thoughtline.Core.Employee.Services.Expertise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
      
        [HttpPost]
        [Route("AddCategory")]
        public MyResponse AddCategory(Category category)
        {
            MyResponse response = new MyResponse();           
            CategoryDAL dal = new CategoryDAL();
            response = dal.AddCategory(category);
            return response;
        }
        
        [HttpGet]
        [Route("ShowCategories")]
        public List<Category> ShowCategories()
        {
            MyResponse response = new MyResponse();
            CategoryDAL dal = new CategoryDAL();
            List<Category> listCategories = new List<Category>();           
            listCategories = dal.ShowCategories();
            return listCategories;
        }      
        
        
        [HttpGet]
        [Route("ShowTestWithoutDB")]
        public List<Category> ShowTestWithoutDB()
        {

            List<Category> listCategories = new List<Category>();
            Category objCategory = new Category();
            objCategory.CategoryName = "IT";
            objCategory.Description = "TLT Techno";
            listCategories.Add(objCategory);
            Category objCategory1 = new Category();
            objCategory1.CategoryName = "Civil";
            objCategory1.Description = "civilTechno";
            listCategories.Add(objCategory1);
            return listCategories;
        }
    }
}
