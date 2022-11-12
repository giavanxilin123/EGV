namespace EGV.DataAccessor.Entities 
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryID { get; set; }
        public int Stock { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Category Category { get; set; }
    }
}