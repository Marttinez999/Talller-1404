using Entity;
using Logica;
namespace GUI.Models
{
    public class UsuarioInputModel{
        public string identificacion { get; set; }
        public string nombre { get; set; }
        public double salario { get; set; }
        public double costo { get; set; }
    }
    public class UsuarioViewModel: UsuarioInputModel
    {
        public UsuarioViewModel()
        {}
        public UsuarioViewModel(Usuario usuario)
        {
            identificacion = usuario.identificacion;
            System.Console.WriteLine(identificacion);
            nombre = usuario.nombre;
            salario = usuario.salario;
            costo = usuario.costo;
            copago = usuario.copago;
        }
        public double copago { get; set; }
    }
}
