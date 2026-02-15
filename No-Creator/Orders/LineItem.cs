using No_Creator.Productos;

namespace No_Creator.Orders
{
    public class LineItem
    {
       
        public int Id { get; set; }
        public Order OrderId { get; set; }
        public Product ProductId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
