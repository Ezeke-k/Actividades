using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TUP_PI_Recu_Viajes
{
    internal class ConexionDB
    {

        SqlConnection cnn;

        public ConexionDB()
        {
            cnn = new SqlConnection(@"Data Source=DESKTOP-0OQ6D98\SQLEXPRESS;Initial Catalog=AgenciaViaje;Integrated Security=True");
        }

        public DataTable EjecutarQuery(string query)
        {
            DataTable table = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query, cnn);
            table.Load(cmd.ExecuteReader());
            cnn.Close();
            return table;
        }

        public int EjectutarInsert(string query, Viaje v)
        {
            int fila;
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@codigo", v.pCodigo);
            cmd.Parameters.AddWithValue("@destino", v.pDestino);
            cmd.Parameters.AddWithValue("@transporte", v.pTransporte);
            cmd.Parameters.AddWithValue("@tipo", v.pTipo);
            cmd.Parameters.AddWithValue("@fecha", v.pFecha);
            fila = cmd.ExecuteNonQuery();
            cnn.Close();
            return fila;
        }

    }
}
