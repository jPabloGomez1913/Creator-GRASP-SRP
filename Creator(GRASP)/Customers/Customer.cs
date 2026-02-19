using Creator_GRASP_.Orders;
using Creator_GRASP_.Producto;

namespace Creator_GRASP_.Customers
{
    //Esta se usa para explicar la solucion a la violacion del patron creator
    public class Customer
    {
        //Los constructores privados evitan la creación descontrolada de objetos
        private Customer()
        {
        }

        public int CustomerId { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;

        // Se usa un Factory Method para que  solo pueden crearse a través de sus métodos Register()   y evitar la aparicion de new() por todas partes
        public static Customer Register(string email, string name)
        {

            return new Customer
            {
                CustomerId = 1,
                Email = email,
                Name = name,
            };
        }
        //Por que customer es quien crea a Order ? R// Poseedor de Datos: El cliente inicia el proceso de compra.
        public Order CreateOrder()
        {
         

            // Customer solo crea el aggregate Order
            // No conoce ni crea LineItems
            return Order.Create(this);
        }
    }
}
