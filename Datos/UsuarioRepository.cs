using System.Collections.Generic;
using Entity;
using System.Data.SqlClient;
using System;

namespace Datos
{
    public class UsuarioRepository
    {
    private readonly SqlConnection _conexion;
    private readonly List<Usuario> usuarios;

    public UsuarioRepository(ConnectionManager cadena)
    {
        usuarios = new List<Usuario>();
        _conexion = cadena._conexion;
    }
    public void Guardar(Usuario usuario) {
        using (var comando = _conexion.CreateCommand())
        {
            comando.CommandText = @"insert into usuarios (usuario_id, nombre, salario, costo_servicio, copago)
                                    values (@usuario_id, @nombre, @salario, @costo_servicio, @copago)";
            comando.Parameters.AddWithValue("@usuario_id",usuario.identificacion);
            comando.Parameters.AddWithValue("@nombre",usuario.nombre);
            comando.Parameters.AddWithValue("@salario",usuario.salario);
            comando.Parameters.AddWithValue("@costo_servicio",usuario.costo);
            comando.Parameters.AddWithValue("@copago",usuario.copago);

            var filas = comando.ExecuteNonQuery();
        }
    }

    public List<Usuario> ConsultarTodos() {
        SqlDataReader lector;
        List<Usuario> usuarios = new List<Usuario>();
        using (var comando = _conexion.CreateCommand())
        {
            comando.CommandText = "select * from usuarios";
            lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Usuario usuario = mapearUsuario(lector);
                    usuarios.Add(usuario);
                }
            }
        }
        return usuarios;
    }
    public Usuario mapearUsuario(SqlDataReader datos) {
        if (!datos.HasRows) return null;
        Usuario usuario = new Usuario();
        usuario.identificacion = (string)datos["usuario_id"];
        usuario.nombre = (string)datos["nombre"];
        usuario.salario = (double)datos["salario"];
        usuario.costo = (double)datos["costo_servicio"];
        usuario.copago = (double)datos["copago"];

        return usuario;
    }
    }
}
