using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ABMPersonas
{
    public partial class frmPersona : Form
    {
        bool nuevo = false;
        private Persona[] personas;
        private int ultimo;
        private const int TAMANIO = 100;

        public frmPersona()
        {
            InitializeComponent();
            //aca también estaría OK!
            personas = new Persona[TAMANIO];
            ultimo = 0;
        }

        private void frmPersona_Load(object sender, EventArgs e)
        {
            habilitar(false);
            //cargar combos:
            CargarCombo("tipo_documento", "id_tipo_documento", "n_tipo_documento", cboTipoDocumento);
            CargarCombo("estado_civil", "id_estado_civil", "n_estado_civil", cboEstadoCivil);
            CargarLista();
            rbtFemenino.Checked = true;
        }

        private void CargarLista()
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TUPPI;Integrated Security=True");
            //Abrir conexión a la BD
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from personas";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //Ejecutar el comando:
            SqlDataReader reader = cmd.ExecuteReader();

            //Representación de alto nivel del resultado de un SELECT
           // DataTable tabla = new DataTable();
            //tabla.Load(reader);

            lstPersonas.Items.Clear();
            personas = new Persona[TAMANIO];
            ultimo = 0;


            //Recorrer fila por fila de la tabla:
            /* foreach(DataRow fila in tabla.Rows)
             {
                 Persona oPersona = new Persona();
                 oPersona.pApellido = fila[0].ToString();
                 oPersona.pNombres = fila["nombres"].ToString();
                 oPersona.pDocumento = Convert.ToInt32(fila["documento"].ToString());
                 oPersona.pTipoDocumento = int.Parse(fila["tipo_documento"].ToString());
                 oPersona.pEstadoCivil = int.Parse(fila["estado_civil"].ToString());
                 oPersona.pSexo = int.Parse(fila["sexo"].ToString());
                 oPersona.pFallecio = bool.Parse(fila["fallecio"].ToString());
                 //agregar objeto Persona a la lista:
                 lstPersonas.Items.Add(oPersona);
                 personas[ultimo] = oPersona;
                 ultimo++;
             }*/
            //Leer toda la tabla con un DataReader
            while (reader.Read())//mientras tenga más resultados:
            {
                //fila actual
                Persona oPersona = new Persona();
                oPersona.pApellido = reader[0].ToString();
                oPersona.pNombres = reader["nombres"].ToString();
                oPersona.pDocumento = Convert.ToInt32(reader["documento"].ToString());
                oPersona.pTipoDocumento = int.Parse(reader["tipo_documento"].ToString());
                oPersona.pEstadoCivil = int.Parse(reader["estado_civil"].ToString());
                oPersona.pSexo = int.Parse(reader["sexo"].ToString());
                oPersona.pFallecio = bool.Parse(reader["fallecio"].ToString());
                //agregar objeto Persona a la lista:
                lstPersonas.Items.Add(oPersona);
                personas[ultimo] = oPersona;
                ultimo++;
            }



            //cerrar la conexión a la BD
            cnn.Close();

        }

        private void CargarCombo(string nombreTabla, string valueMember, string displayMember, ComboBox cbo)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TUPPI;Integrated Security=True");
            //Abrir conexión a la BD
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from " + nombreTabla;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //cmd.ExecuteReader() devuelve una representación de un conjunto de datos obtenidos mediante
            //SELECT...
            SqlDataReader reader = cmd.ExecuteReader();

            //Representación de alto nivel del resultado de un SELECT
            DataTable tabla = new DataTable();
            tabla.Load(reader);

            cbo.DataSource = tabla;
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;

            //cerrar la conexión a la BD
            cnn.Close();

            habilitar(false);
            limpiar();
            CargarLista();
        }



        private void habilitar(bool x)
        {
            txtApellido.Enabled = x;
            txtNombres.Enabled = x;
            cboTipoDocumento.Enabled = x;
            txtDocumento.Enabled = x;
            cboEstadoCivil.Enabled = x;
            rbtFemenino.Enabled = x;
            rbtMasculino.Enabled = x;
            chkFallecio.Enabled = x;
            btnGrabar.Enabled = x;
            btnCancelar.Enabled = x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnBorrar.Enabled = !x;
            btnSalir.Enabled = !x;
            lstPersonas.Enabled = !x;
        }

        private void limpiar()
        {
            txtApellido.Text = "";
            txtNombres.Text = "";
            cboTipoDocumento.SelectedIndex = -1;
            txtDocumento.Text = "";
            cboEstadoCivil.SelectedIndex = -1;
            rbtFemenino.Checked = false;
            rbtMasculino.Checked = false;
            chkFallecio.Checked = false;
        }
      
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;//Aviso que vamos a insertar un registro
            habilitar(true);
            limpiar();
            txtApellido.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitar(true);
            txtDocumento.Enabled = false;
            txtApellido.Focus();
            nuevo = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Persona oPersona = (Persona)lstPersonas.SelectedItem;
            Persona oPersona = personas[lstPersonas.SelectedIndex];
            if (MessageBox.Show("Seguro que desea eliminar la persona: " + oPersona + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TUPPI;Integrated Security=True");
                //Abrir conexión a la BD
                cnn.Open();
                SqlCommand cmd = new SqlCommand("DELETE Personas Where documento=" + oPersona.pDocumento);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                int result = cmd.ExecuteNonQuery();
                //if (result == 1) podemos usar esta cantidad para validar éxito del comando


                //cerrar la conexión a la BD
                cnn.Close();
                habilitar(false);
                limpiar();
                CargarLista();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {   
            limpiar();
            habilitar(false);
            nuevo = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //Crear un objeto Persona
            int tipoDocumento = int.Parse(cboTipoDocumento.SelectedValue.ToString());
            int estadoCivil = int.Parse(cboEstadoCivil.SelectedValue.ToString());
            int nroDocumento = int.Parse(txtDocumento.Text);
            int sexo = 1;
            if (rbtMasculino.Checked)
                sexo = 2;
            Persona oPersona = new Persona(txtApellido.Text, txtNombres.Text, tipoDocumento, nroDocumento, estadoCivil, sexo, chkFallecio.Checked);
            /** Otra forma: (constructor sin parámetros)
             * Persona p = new Persona();
            p.pApellido = txtApellido.Text;
            p.pNombres = txtNombres.Text;
            p.pTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
            p.pDocumento = int.Parse(txtDocumento.Text);
            p.pEstadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue);
            if (rbtFemenino.Checked)
                p.pSexo = 1;
            else
                p.pSexo = 2;
            p.pFallecio = chkFallecio.Checked;

            */
            SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TUPPI;Integrated Security=True");
            //Abrir conexión a la BD
            cnn.Open();
            SqlCommand cmd = new SqlCommand();

            if (nuevo) //(nuevo==true) es equivalente
            {
                // VALIDAR QUE NO EXISTA LA PK !!!!!! (SI NO ES AUTOINCREMENTAL / IDENTITY)
                if (!existe(nroDocumento)) {
                    cmd.CommandText = "INSERT [dbo].[personas] ([apellido], [nombres], [tipo_documento], [documento], [estado_civil], [sexo], [fallecio]) VALUES('" +
                 oPersona.pApellido + "','" + oPersona.pNombres + "'," + oPersona.pTipoDocumento + "," + oPersona.pDocumento + "," + oPersona.pEstadoCivil +
                 "," + oPersona.pSexo + ",'" + oPersona.pFallecio + "')";

                    nuevo = false;
                }
                else
                {
                    MessageBox.Show("La persona ya está cargada para ese Nº de documento!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cnn.Close();
                    return;
                }
            }
            else {
                /*cmd.CommandText = "UPDATE [dbo].[personas] SET apellido = '" +
                    oPersona.pApellido + "',nombres = '" + oPersona.pNombres + "',tipo_documento=" + oPersona.pTipoDocumento +  ",estado_civil=" + oPersona.pEstadoCivil +
                    ",sexo=" + oPersona.pSexo + ",fallecio = '" + oPersona.pFallecio + "' WHERE documento = " + oPersona.pDocumento;
                */
                //Refactorizamos con un comando con parámetros:
                //2 ventajas:
                //1) Fácil de escribir
                //2) Evita el SQL Inyección
                cmd.CommandText = "UPDATE [dbo].[personas] SET apellido=@apellido, " +
                    "nombres=@nombres, tipo_documento=@tipo_documento, estado_civil=@estado_civil, " +
                    "sexo=@sexo, fallecio=@fallecio WHERE documento = @documento";

                cmd.Parameters.AddWithValue("@apellido", txtApellido.Text);
                cmd.Parameters.AddWithValue("@nombres", oPersona.pNombres);
                cmd.Parameters.AddWithValue("@tipo_documento", oPersona.pTipoDocumento);
                cmd.Parameters.AddWithValue("@estado_civil", oPersona.pEstadoCivil);
                cmd.Parameters.AddWithValue("@sexo", oPersona.pSexo);
                cmd.Parameters.AddWithValue("@fallecio", oPersona.pFallecio);
                cmd.Parameters.AddWithValue("@documento", oPersona.pDocumento);

            }

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cmd.ExecuteNonQuery();

            //cerrar la conexión a la BD
            cnn.Close();

            habilitar(false);
            limpiar();
            CargarLista();
        }

        private bool existe(int nroDocumento)
        {
            bool encontrado = false;
            for (int i = 0; i < ultimo; i++)
                if (personas[i].pDocumento == nroDocumento)
                {
                    encontrado = true;
                    break;
                }
                    
            return encontrado ;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de abandonar la aplicación ?",
                "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Close();
        }

        private void lstPersonas_SelectedValueChanged(object sender, EventArgs e)
        {
            //validar que el índice seleccionado es correcto:
            if (lstPersonas.SelectedIndex != -1)
            {
                //Tomar el objeto persona ligado con el ítem seleccionado y actualizar componentes:
                //Persona oPersona = (Persona)lstPersonas.SelectedItem;
                Persona oPersona = personas[lstPersonas.SelectedIndex];
                txtApellido.Text = oPersona.pApellido;
                txtNombres.Text = oPersona.pNombres;
                txtDocumento.Text = oPersona.pDocumento.ToString();
                cboTipoDocumento.SelectedValue = oPersona.pTipoDocumento;
                cboEstadoCivil.SelectedValue = oPersona.pEstadoCivil; //"SelectValue->ValueMember"
                if (oPersona.pSexo == 1)
                    rbtFemenino.Checked = true;
                else
                    rbtMasculino.Checked = true;

                chkFallecio.Checked = oPersona.pFallecio;
                
            }
        }
    }
}
