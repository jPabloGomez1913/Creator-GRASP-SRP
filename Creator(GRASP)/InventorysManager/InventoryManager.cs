

using Creator_GRASP_.Producto;

//Esta se usa para explicar la solucion a la violacion del patron SRP
namespace Creator_GRASP_.InventorysManager
{
    public class InventoryManager
    {
        private const int UMBRAL_REORDEN = 10;

       

        public void ActualizarStock(Product producto, int cantidad)
        {
            producto.Inventory -= cantidad;

            if (RequiereReorden(producto))
            {
                //Envia solicitud al provedor
                _notificationService.SolicitarReabastecimiento(producto);
            }
        }

        private bool RequiereReorden(Product producto)
        {
            return producto.Inventory <= UMBRAL_REORDEN;
        }
    }
}
