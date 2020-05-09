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
            identificacion = usuario.Identificacion;
            nombre = usuario.Nombre;
            salario = usuario.Salario;
            costo = usuario.Costo;
            copago = usuario.Copago;
        }
        public double copago { get; set; }
    }
}
