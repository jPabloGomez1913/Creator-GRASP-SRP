namespace No_Creator.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<LineItem> LineItems { get; set; } = new();

    }
}
