namespace Creator_GRASP_.Producto
{
    public class Product
    {
        private Product()
        {
                
        }
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public string Currency { get; private set; } = string.Empty;
        public int Inventory { get; set; }

        public static Product Register(string name,decimal price,string currency,int inventory) {

            return new Product {
                Name = name,
                Price = price,
                Currency = currency,
                Inventory = inventory
            };

        }
    }
}
