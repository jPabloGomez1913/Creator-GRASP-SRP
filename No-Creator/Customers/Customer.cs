using No_Creator.Orders;
using No_Creator.Productos;

namespace No_Creator.Customers
{

    //En esta clase se usa para explicar por que se violla el CREATOR
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime LastPurchase { get; set; }

        public void CreateOrder(int customerId)
        {
            //El cliente no tiene por que crear productos
            var product = new Product {
                Id = 1,
                Name = "PS5",
                Price = 200000,
                Currency = "COP"

            };
            //La relación entre el cliente y la orden es de composición, por eso no se viola el Creator 
            var order = new Order
            {
                Id = 1,
                CustomerId = CustomerId,
            };

            //El que contiene es el que crea, como Order contiene LineItems, debería ser Order quien los cree.
            //El patrón Creator es violado acá, ya que el cliente no tiene relación con LineItems
            var lineItem = new LineItem
            {
                Id = 1,
                OrderId = order,
                ProductId = product,
                Price = 10050,
                Currency = "COP"

            };

            order.LineItems.Add(lineItem);

        }
    }

}
