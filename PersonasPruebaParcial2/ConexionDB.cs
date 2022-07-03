using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PersonasPruebParcial2;
using PersonasPruebaParcial2;

namespace PersonasPruebaParcial2
{
    internal class ConexionDB
    {
        
        private SqlConnection cnn;

        public ConexionDB()
        {
            cnn = new SqlConnection(@"Data Source=DESKTOP-0OQ6D98\SQLEXPRESS;Initial Catalog=TUPPI;Integrated Security=True");
        }

        public DataTable EjecutarQuery(string query)
        {
            DataTable table = new DataTable(); //creo una nueva datatable
            cnn.Open();//abro conexion
            SqlCommand cmd = new SqlCommand(query, cnn); //llamo al comando
            table.Load(cmd.ExecuteReader());//mando la query al sql
            cnn.Close();//cierro conexion
            return table;//retorno la tabla que cree
        }

        public int EjecutarInsert(string query, Personas p)
        {
            int fila; //para ir calculando la cantidad de veces que pasa por aqui
            SqlCommand cmd = new SqlCommand(query, cnn); //creo el comando para abrir la conexion
            cnn.Open();//abro la conexion
            cmd.Parameters.AddWithValue("@apellido", p.Apellido);//hago la relacion entre el apellido del sql y el del c# con cada uno de los datos
            cmd.Parameters.AddWithValue("@nombres", p.Nombre);
            cmd.Parameters.AddWithValue("@tipo_documento", p.TipoDocumento);
            cmd.Parameters.AddWithValue("@documento", p.Documento);
            cmd.Parameters.AddWithValue("@estado_civil", p.EstadoCivil);
            cmd.Parameters.AddWithValue("@sexo", p.Sexo);
            cmd.Parameters.AddWithValue("@fallecio", p.Fallecido);
            fila = cmd.ExecuteNonQuery();//cuento la cantidad de veces
            cnn.Close();//cierro la conexion
            return fila;//retorno la cantidad de veces
        }
    }
}
