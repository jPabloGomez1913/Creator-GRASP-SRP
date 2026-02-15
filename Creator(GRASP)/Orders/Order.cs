using Creator_GRASP_.Customers;
using Creator_GRASP_.Producto;

namespace Creator_GRASP_.Orders
{
    public class Order
    {
        // No se puede hacer: new Order()
        //Los constructores privados evitan la creación descontrolada de objetos

        private Order(){}

        private readonly HashSet<LineItem> _lineItems = new();


        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public OrderStatus Status { get; private set; }

        //Se puede crear un orden mas no una instancia
        public static Order Create(Customer customer)
        {
            var order = new Order
            {
                Id = 1,
                CustomerId = customer.CustomerId,
                Status = OrderStatus.Sent,
            };

            return order;
         
        }
        
        //Order crea LineItem porque Order CONTIENE LineItems
        public void Add(Product product)
        {
            //El line item nos permite tener un tracking claro del producto
            var lineItem = new LineItem(1, Id, product.Id, product.Price, "COP");

            _lineItems.Add(lineItem);

        }

    }
}
