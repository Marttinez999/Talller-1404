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
            usuario.identificacion = identificacion;
            usuario.nombre = nombre;
            usuario.salario = salario;
            usuario.costo = costo;
        }
        public double copago { get; set; }
    }
}
