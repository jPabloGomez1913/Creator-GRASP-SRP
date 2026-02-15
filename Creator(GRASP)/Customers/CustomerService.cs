namespace Creator_GRASP_.Customers
{
    //Esta se usa para explicar la solucion a la violacion del patron SRP

    public class CustomerService
    {
        private const int DIAS_PARA_ACTUALIZACION = 180; // 6 meses

        public void VerificarYActualizarDatos(Customer customer)
        {
            if (RequiereActualizacion(customer))
            {
                SolicitarActualizacionDatos(customer);
            }
        }

        private bool RequiereActualizacion(Customer customer)
        {
            var diasDesdeUltimaCompra = (DateTime.Now - customer.LastPurchase).Days;
            return diasDesdeUltimaCompra >= DIAS_PARA_ACTUALIZACION;
        }

        private void SolicitarActualizacionDatos(Customer customer)
        {
            // Lógica para solicitar actualización
            // Puede enviar email, notificación, etc.
        }
    }
}
