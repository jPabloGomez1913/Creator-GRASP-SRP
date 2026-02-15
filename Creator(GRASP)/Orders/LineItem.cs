namespace Creator_GRASP_.Orders
{
    public class LineItem
    {
        //internal constructor: LineItem solo puede ser creado dentro del ensamblado
        internal LineItem(int id, int orderId, int productId, decimal price, string currency)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Price = price;
            Currency = currency;

        }

        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public decimal Price { get; private set; }
        public string Currency { get; private set; }



    }
}
