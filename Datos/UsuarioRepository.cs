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
            comando.Parameters.AddWithValue("@usuario_id",usuario.Identificacion);
            comando.Parameters.AddWithValue("@nombre",usuario.Nombre);
            comando.Parameters.AddWithValue("@salario",usuario.Salario);
            comando.Parameters.AddWithValue("@costo_servicio",usuario.Costo);
            comando.Parameters.AddWithValue("@copago",usuario.Copago);

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
        usuario.Identificacion = (string)datos["usuario_id"];
        usuario.Nombre = (string)datos["nombre"];
        usuario.Salario = (double)datos["salario"];
        usuario.Costo = (double)datos["costo_servicio"];
        usuario.Copago = (double)datos["copago"];

        return usuario;
    }
    }
}
