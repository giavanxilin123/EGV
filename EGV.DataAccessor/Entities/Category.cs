namespace EGV.DataAccessor.Entities
{
    public class Category
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}