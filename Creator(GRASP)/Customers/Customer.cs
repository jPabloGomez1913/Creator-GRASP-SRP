using Creator_GRASP_.Orders;

namespace Creator_GRASP_.Customers
{
    public class Customer
    {
        private Customer(int id, string email, string name)
        {
            CustomerId = id;
            Email = email;
            Name = name;

                
        }
        public int CustomerId { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;

        public Order CreateOrder()
        {
            // Customer solo crea el aggregate Order
            // No conoce ni crea LineItems
            return Order.Create(this);
        }
    }
}
