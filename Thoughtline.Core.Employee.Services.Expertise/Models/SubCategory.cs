namespace Thoughtline.Core.Employee.Services.Expertise.Models
{
    public class SubCategory
    {     

        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public int InsertedUserID { get; set; }
        public int UpdatedUserID { get; set; }
        
    }
}
