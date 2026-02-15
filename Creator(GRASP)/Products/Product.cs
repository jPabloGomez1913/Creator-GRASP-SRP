namespace Creator_GRASP_.Producto
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public string Currency { get; private set; } = string.Empty;
        public int Inventory { get; set; }
    }
}
