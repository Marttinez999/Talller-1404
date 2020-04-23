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
      [HttpPost]
      public ActionResult<UsuarioViewModel> Post(UsuarioInputModel usuarioInput) {
          System.Console.WriteLine(usuarioInput.identificacion);
          Usuario usuario = mapearUsuario(usuarioInput);
          var respuesta = _usuarioService.guardar(usuario);
          if (respuesta.Error)
          {
              return BadRequest(respuesta.Mensaje);
          }
          return Ok(respuesta.Usuario);
      }
      
      private Usuario mapearUsuario(UsuarioInputModel usuarioInput){
          Usuario usuario = new Usuario();
        //   System.Console.WriteLine(usuarioInput.identificacion);
          usuario.identificacion = usuarioInput.identificacion;
        //   System.Console.WriteLine(usuario.identificacion);
          usuario.nombre = usuarioInput.nombre;
          usuario.salario = usuarioInput.salario;
          usuario.costo = usuarioInput.costo;
          
          return usuario;
      }
    }
}