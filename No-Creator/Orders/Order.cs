using No_Creator.Customers;

namespace No_Creator.Orders
{
    //Esta se usa para explicar por que se viola el SRP
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<LineItem> LineItems { get; set; } = new();


        //Esto metodo viola el SRP por que Order debería solo preocuparse por representar y gestionar la información del pedido



        //Metodo que solicita actualizar los datos del comprador si ha pasado cierto tiempo desde su ultima compra
        public void ActualizarDatosCustomer(Customer customer)
        {
            if (customer.LastPurchase <= new DateTime()) {
            }
        }
    }

}
