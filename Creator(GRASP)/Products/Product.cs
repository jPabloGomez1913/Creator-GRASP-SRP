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

        //solo pueden crearse a través de sus métodos Register(). Esto previene el "caos del new" en cualquier parte de la aplicación.
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
