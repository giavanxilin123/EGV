namespace EGV.DataAccessor.Entities 
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryID { get; set; }
        public int Stock { get; set; }
        public Boolean IsDeleted { get; set; }
        public virtual Category Category { get; set; }
    }
}