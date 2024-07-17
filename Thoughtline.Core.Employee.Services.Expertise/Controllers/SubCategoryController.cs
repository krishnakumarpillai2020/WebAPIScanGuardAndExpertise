using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thoughtline.Core.Employee.Services.Expertise.DAL;
using Thoughtline.Core.Employee.Services.Expertise.Models;

namespace Thoughtline.Core.Employee.Services.Expertise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        [HttpPost]
        [Route("AddSubCategory")]
        public MyResponse AddSubCategory(SubCategory subCategory)
        {
            MyResponse response = new MyResponse();
            SubCategoryDAL dal = new SubCategoryDAL();
            response = dal.AddSubCategory(subCategory);
            return response;
        }

        [HttpGet]
        [Route("GetSubCategories")]
        public List<SubCategory> GetSubCategories()
        {
            MyResponse response = new MyResponse();
            SubCategoryDAL dal = new SubCategoryDAL();
            List<SubCategory> listSubCategories = new List<SubCategory>();
            listSubCategories = dal.GetSubCategories();
            return listSubCategories;
        }
    }
}
