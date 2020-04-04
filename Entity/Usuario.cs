using System;

namespace Entity
{
    public class Usuario
    {
        public string identificacion { get; set; }
        public string nombre { get; set; }
        public double salario { get; set; }
        public double costo { get; set; }
        public double copago { get; set; }
        public void calcularCopago() {
            if (salario > 2500000)
            {
                copago = 0.2 * costo;
            }else
            {
                copago = 0.1 * costo;
            }
        }
    }
}
