using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GUI.Models;

namespace GUI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class UsuarioController: ControllerBase
   {
       private readonly UsuarioService _usuarioService;
       public IConfiguration Configuration {get;}

       public UsuarioController(IConfiguration configuration){
           Configuration = configuration;
           string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
           _usuarioService = new UsuarioService(connectionString);
       }

      [HttpGet]
      public IEnumerable<UsuarioViewModel> Get() {
          var usuarios = _usuarioService.consultarTodos().Select(u => new UsuarioViewModel(u));
          return usuarios;
      }
      
      [HttpPost("usuarioImput")]
      public ActionResult<UsuarioViewModel> Post(UsuarioInputModel usuarioInput) {
          Usuario usuario = mapearUsuario(usuarioInput);
          var respuesta = _usuarioService.guardar(usuario);
          if (respuesta.Error)
          {
              return BadRequest(respuesta.Mensaje);
          }
          return Ok(respuesta.Usuario);
      }
      
      [HttpDelete("id")]
      public ActionResult<string> Delete(string id) {
          string mensaje = _usuarioService.eliminar(id);
          return Ok(mensaje);
      }
      
      [HttpPut("id")]
        public ActionResult<string> Put(string id) {
          throw new NotImplementedException();
      }
      private Usuario mapearUsuario(UsuarioInputModel usuarioInput){
          Usuario usuario = new Usuario();
          usuario.identificacion = usuarioInput.identificacion;
          usuario.nombre = usuarioInput.nombre;
          usuario.salario = usuarioInput.salario;
          usuario.costo = usuarioInput.costo;

          return usuario;
      }
    }
}