using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//CURSO – LEGAJO – APELLIDO – NOMBRE

namespace ABMMascotas
{
    public partial class frmMascota : Form
    {
        private accesoDatos oBD;
        private List<Mascota> lMascotas;

        public frmMascota()
        {
            InitializeComponent();
            oBD = new accesoDatos();
            lMascotas = new List<Mascota>();
        }

        private void frmMascota_Load(object sender, EventArgs e)
        {
            cargarCombo();
            cargarLista();
            habilitar(false);
        }
        private void cargarLista()
        {
            lMascotas.Clear();
            lstMascotas.Items.Clear();
            DataTable tabla = oBD.consultarBD("SELECT * FROM Mascotas");
            //con un for...
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Mascota m = new Mascota();
                m.pCodigo = Convert.ToInt32(tabla.Rows[i][0]); //Columna [0] = ["codigo"]
                m.pNombre = tabla.Rows[i]["nombre"].ToString();
                m.pEspecie = (int)tabla.Rows[i]["especie"];
                m.pSexo = int.Parse(tabla.Rows[i]["sexo"].ToString());
                m.pFechaNacimiento = Convert.ToDateTime(tabla.Rows[i]["fechaNacimiento"]);
                lMascotas.Add(m);
                lstMascotas.Items.Add(m.ToString());
            }
            //o con foreach...
            //foreach (DataRow fila in tabla.Rows)
            //{
            //    Mascota m = new Mascota();
            //    m.pCodigo = int.Parse(fila["codigo"].ToString());
            //    m.pNombre = Convert.ToString(fila["nombre"]);
            //    m.pEspecie = (int)(fila["especie"]);
            //    m.pSexo = Convert.ToInt32(fila["sexo"]);
            //    m.pFechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"]);
            //    lMascotas.Add(m);
            //    lstMascotas.Items.Add(m.ToString());
            //}
        }
        private void cargarCombo()
        {
            DataTable tabla = oBD.consultarBD("SELECT * FROM Especies ORDER BY 2");
            cboEspecie.DataSource = tabla;
            cboEspecie.DisplayMember = "nombreEspecie";
            cboEspecie.ValueMember = "idEspecie";
            cboEspecie.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de salir del formulario?"
                , "SALIENDO"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question
                , MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
                Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitar(true);
            limpiar();
            txtCodigo.Focus();
        }

        private void limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = string.Empty;
            cboEspecie.SelectedIndex = -1;
            rbtHembra.Checked = false;
            rbtMacho.Checked = false;
            dtpFechaNacimiento.Value = DateTime.Today;
        }

        private void habilitar(bool v)
        {
            txtCodigo.Enabled = v;
            txtNombre.Enabled = v;
            cboEspecie.Enabled = v;
            rbtHembra.Enabled = v;
            rbtMacho.Enabled = v;
            dtpFechaNacimiento.Enabled = v;
            btnGrabar.Enabled = v;
            btnNuevo.Enabled = !v;
            btnSalir.Enabled = !v;
            lstMascotas.Enabled = !v;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //valida datos...
            if (validarDatos())
            {
                //crear objeto
                Mascota m = new Mascota();
                m.pCodigo = int.Parse(txtCodigo.Text);
                m.pNombre = txtNombre.Text;
                m.pEspecie = Convert.ToInt32(cboEspecie.SelectedValue);
                if (rbtHembra.Checked)
                    m.pSexo = 2;
                else
                    m.pSexo = 1;
                m.pFechaNacimiento = dtpFechaNacimiento.Value;

                if (!existe(m))
                {
                    //insert con SQL tradicional
                    //string insertSQL = "INSERT INTO Mascotas VALUES (" +
                    //m.pCodigo + ", '" +
                    //m.pNombre + "', " +
                    //m.pEspecie + "," +
                    //m.pSexo + ",'" +
                    //m.pFechaNacimiento.ToString("yyyy/MM/dd") + "')";

                    //if (oBD.actualizarBD(insertSQL) > 0)
                    //{
                    //    MessageBox.Show("Se insertó con éxito una nueva mascota!!!");
                    //    cargarLista();
                    //}

                    //insert usando parámetros
                    string insertSQL = "INSERT INTO Mascotas VALUES (@codigo,@nombre,@especie,@sexo,@fechaNacimiento)";

                    List<Parametro> lParametros = new List<Parametro>();
                    lParametros.Add(new Parametro("@codigo", m.pCodigo));
                    lParametros.Add(new Parametro("@nombre", m.pNombre));
                    lParametros.Add(new Parametro("@especie", m.pEspecie));
                    lParametros.Add(new Parametro("@sexo", m.pSexo));
                    lParametros.Add(new Parametro("@fechaNacimiento", m.pFechaNacimiento));

                    if (oBD.actualizarBD(insertSQL, lParametros) > 0)
                    {
                        MessageBox.Show("Se insertó con éxito una nueva mascota!!!");
                        cargarLista();
                    }
                }
                else
                {
                    MessageBox.Show("La mascota ya existe!!!");

                    /* No lo pide la consigna, 
                     * pero aprovechamos acá, cuando existe la mascota, para hacer update y
                     * demostramos que solo cambiando la consulta SQL, 
                     * funciona con la misma programación del insert.
                     */

                    string upDateSQL = "UPDATE Mascotas SET nombre=@nombre, especie=@especie, sexo=@sexo, fechaNacimiento=@fechaNacimiento WHERE codigo=@codigo";

                    List<Parametro> lParametros = new List<Parametro>();
                    lParametros.Add(new Parametro("@codigo", m.pCodigo));
                    lParametros.Add(new Parametro("@nombre", m.pNombre));
                    lParametros.Add(new Parametro("@especie", m.pEspecie));
                    lParametros.Add(new Parametro("@sexo", m.pSexo));
                    lParametros.Add(new Parametro("@fechaNacimiento", m.pFechaNacimiento));

                    if (oBD.actualizarBD(upDateSQL, lParametros) > 0)
                    {
                        MessageBox.Show("Se modificó con éxito la mascota!!!");
                        cargarLista();
                    }
                }
                habilitar(false);
            }
        }

        private bool existe(Mascota nueva)
        {
            for (int i = 0; i < lMascotas.Count; i++)
            {
                if (lMascotas[i].pCodigo == nueva.pCodigo)
                    return true;
            }
            return false;
        }

        private bool validarDatos()
        {
            //bool valido = true;     Eliminé la variable y retornamos en cada if para que sea mas amigable al usuario...
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Debe ingresar un codigo...");
                txtCodigo.Focus();
                return false;
            }
            else
            {
                try
                {
                    int.Parse(txtCodigo.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe ingresar valores numéricos...");
                    txtCodigo.Focus();
                    return false;
                }
            }
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre...");
                txtNombre.Focus();
                return false;
            }

            if (cboEspecie.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una especie...");
                cboEspecie.Focus();
                return false;
            }

            if (!rbtMacho.Checked && !rbtHembra.Checked)
            {
                MessageBox.Show("Debe seleccionar un sexo...");
                rbtMacho.Focus();
                return false;
            }

            if (DateTime.Today.Year - dtpFechaNacimiento.Value.Year > 10)
            {
                MessageBox.Show("No puede registrar una mascota mayor a 10 años...");
                dtpFechaNacimiento.Focus();
                return false;
            }
            return true;
        }

        private void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCampos(lstMascotas.SelectedIndex);
        }

        private void cargarCampos(int posicion)
        {
            txtCodigo.Text = lMascotas[posicion].pCodigo.ToString();
            txtNombre.Text = lMascotas[posicion].pNombre;
            cboEspecie.SelectedValue = lMascotas[posicion].pEspecie;
            if (lMascotas[posicion].pSexo == 1)
                rbtMacho.Checked = true;
            else
                rbtHembra.Checked = true;
            dtpFechaNacimiento.Value = lMascotas[posicion].pFechaNacimiento;
        }
    }
}
