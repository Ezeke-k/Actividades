using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ABMMascotas
{
    class accesoDatos
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        string cadenaConexion;

        public accesoDatos()
        {
            cadenaConexion = @"Data Source=localhost;Initial Catalog=Veterinaria;Integrated Security=True";
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
        }

        private void conectar()
        {
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        public void desconectar()
        {
            conexion.Close();
        }

        public DataTable consultarBD(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            conectar();
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }

        public int actualizarBD(string consultaSQl)
        {
            int filasAfectadas;
            conectar();
            comando.CommandText = consultaSQl;
            filasAfectadas = comando.ExecuteNonQuery();
            desconectar();
            return filasAfectadas;
        }
        //Sobrecarga del método utilizando una lista de parámetros
        public int actualizarBD(string consultaSQl, List<Parametro> lParametros)
        {
            int filasAfectadas;
            conectar();
            comando.CommandText = consultaSQl;

            //asignamos los parametros del comando:
            comando.Parameters.Clear();
            foreach (Parametro p in lParametros)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }

            filasAfectadas = comando.ExecuteNonQuery();
            desconectar();
            return filasAfectadas;
        }
    }
}
