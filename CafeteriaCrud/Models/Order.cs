namespace CafeteriaCrud.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
