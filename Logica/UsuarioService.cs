using System;
using Entity;
using System.Collections.Generic;
namespace Logica
{
    public class UsuarioService
    {
       public UsuarioService()
       {}
        public List<Usuario> consultarTodos() {
            return null;
        }
        public GuardarPersonaResponse guardar(Usuario usuario) {
            return null;
        }
        public string eliminar(string id) {
            return "";
        }
    }
    public class GuardarPersonaResponse{
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Usuario Usuario { get; set; }

        public GuardarPersonaResponse(Usuario usuario){
            Error = false;
            Usuario = usuario;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

    }
}
