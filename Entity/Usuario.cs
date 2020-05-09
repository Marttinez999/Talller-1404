using System;

namespace Entity
{
    public class Usuario
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public double Salario { get; set; }
        public double Costo { get; set; }
        public double Copago { get; set; }
        public void calcularCopago() {
            if (Salario > 2500000)
            {
                Copago = 0.2 * Costo;
            }else
            {
                Copago = 0.1 * Costo;
            }
        }
    }
}
