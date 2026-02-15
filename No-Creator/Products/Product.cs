namespace No_Creator.Productos
{
    //Esta se usa para explicar por que se viola el SRP

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Currency { get; set; } = string.Empty;
        public int Inventory { get; set; }


        //Se viola el srp por que la unica responsabilidad del la clase producto es la de representar los datos del producto (propiedades)
        //Y en este caso esta teniendo multiples razones para cambiar

        //Actualiza la cantidad del producto en el inventario
        public void ActualizarStock(int cantidadProducto, decimal price) { 

            this.Inventory -= cantidadProducto;

        }

        //Metodo que cuando el invenrio esta en cierto numero de unidades hace un pedido al provedor
        public void SolicitarUnidades() {
            if (this.Inventory <= 10) {
                //Envia un correo al prpovedor solicitando mas unidades
                this.EnviarEmailProvedor("loqjdndsmfdsfds",this.Name);

            }
        }

        public void EnviarEmailProvedor(string emailProvedor, string producto) { 
            //Envia un email solcitando mas unidades al provedor
        }

    }
}
