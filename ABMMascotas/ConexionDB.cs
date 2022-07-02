using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ABMMascotas
{
    internal class ConexionDB
    {
        private string conexionSQL;
        private SqlConnection cnn;
        private SqlCommand cmd;
        private DataTable table;

        public ConexionDB()
        {
            conexionSQL = @"Data Source=DESKTOP-0OQ6D98\SQLEXPRESS;Initial Catalog=veterinaria;Integrated Security=True";
            cnn = new SqlConnection(conexionSQL);
        }

        public DataTable ConsultarSQL(string query)
        {
            cnn.Open();
            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            table = new DataTable();
            table.Load(cmd.ExecuteReader());
            cnn.Close();
            return table;
        }

        public int EjecutarSQL(string query, List<Parametro> listParam)
        {
            int filasAfectadas;
            cnn.Open();
            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection= cnn;

            foreach (Parametro param in listParam)
            {
                cmd.Parameters.AddWithValue(param.Nombre, param.Valor);
            }
            filasAfectadas = cmd.ExecuteNonQuery();
            cnn.Close();
            return filasAfectadas;
            
        }

        public int EjecutarInsert(string sql, Mascota m)
        {
            int filas;
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@codigo", m.pCodigo);
            cmd.Parameters.AddWithValue("@nombre", m.pNombre);
            cmd.Parameters.AddWithValue("@especie", m.pEspecie);
            cmd.Parameters.AddWithValue("@sexo", m.pSexo);
            cmd.Parameters.AddWithValue("@fechaNacimiento", m.pFechaNacimiento);

            filas = cmd.ExecuteNonQuery();
            cnn.Close();
            return filas;
        }
        
    }
}
