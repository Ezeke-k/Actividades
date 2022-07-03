using PersonasPruebParcial2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonasPruebaParcial2
{
    public partial class Form1 : Form
    {
        bool nuevo;
        ConexionDB helper;

        public Form1()
        {
            helper = new ConexionDB();
            InitializeComponent();
        }

        private void Habilitar(bool x)
        {
            txtApellido.Enabled = x;
            txtDocumento.Enabled = x;
            txtNombre.Enabled = x;
            cbEstadoCivil.Enabled = x;
            cbTipoDocumento.Enabled = x;
            cbFallecido.Enabled = x;
            rbFemenino.Enabled = x;
            rbMasculino.Enabled = x;
            btGrabar.Enabled = x;
            btCancelar.Enabled = x;
            btBorrar.Enabled =! x;
            btEditar.Enabled = !x;
            lstPersonas.Enabled = !x;
        }

        private void Limpiar()
        {
            txtApellido.Text = String.Empty;
            txtDocumento.Text = String.Empty;
            txtNombre.Text = String.Empty;
            cbEstadoCivil.SelectedValue = -1;
            cbTipoDocumento.SelectedValue = -1;
            cbFallecido.Checked = false;
            rbFemenino.Checked = false;
            rbMasculino.Checked = false;
        }
        
        private void CargarCombo(ComboBox cbo, string nombreTabla, string valuemember, string displaymember)
        {
            DataTable table = helper.EjecutarQuery("select * from " + nombreTabla);
            cbo.DataSource = table;
            cbo.ValueMember = valuemember;
            cbo.DisplayMember = displaymember;
        }

        private void CargarLista()
        {
            string query = "select * from personas";
            DataTable table = helper.EjecutarQuery(query);
            lstPersonas.Items.Clear();
            foreach (DataRow dr in table.Rows)
            {
                Personas p = new Personas();
                p.Apellido = dr["apellido"].ToString();
                p.Nombre = dr["nombres"].ToString();
                p.Documento = Convert.ToInt32(dr["documento"].ToString());
                p.TipoDocumento = Convert.ToInt32(dr["tipo_documento"].ToString());
                p.EstadoCivil = Convert.ToInt32(dr["estado_civil"].ToString());
                p.Sexo = Convert.ToInt32(dr["sexo"].ToString());
                p.Fallecido = Convert.ToBoolean(dr["fallecio"].ToString());
                lstPersonas.Items.Add(p);
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            CargarCombo(cbEstadoCivil, "estado_civil", "id_estado_civil", "n_estado_civil");
            CargarCombo(cbTipoDocumento, "tipo_documento", "id_tipo_documento", "n_tipo_documento");
            CargarLista();
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            Limpiar();
            txtApellido.Focus();
            nuevo = true;
        }

        private void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstPersonas.SelectedIndex != -1)
            {
                Personas p = (Personas)lstPersonas.SelectedItem;
                txtApellido.Text = p.Apellido;
                txtNombre.Text = p.Nombre;
                txtDocumento.Text = p.Documento.ToString();
                cbTipoDocumento.SelectedValue = p.TipoDocumento;
                cbEstadoCivil.SelectedValue = p.EstadoCivil;
                cbFallecido.Checked = p.Fallecido;
                if (p.Sexo == 1)
                {
                    rbMasculino.Checked = true;
                }
                else
                    rbFemenino.Checked = true;
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            if(lstPersonas.SelectedIndex !=-1)
            {
                Habilitar(true);
                nuevo = false;
            }
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Esta seguro que quiere salir?","Salir", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar(false);
        }

        private void btBorrar_Click(object sender, EventArgs e) //hice que si tocas el boton borrar puedas eliminar una persona
        {
            Personas p = new Personas();
            p.Nombre = txtNombre.Text;
            p.Apellido = txtApellido.Text;
            p.Documento = Convert.ToInt32(txtDocumento.Text);
            p.TipoDocumento = Convert.ToInt32(cbTipoDocumento.SelectedValue);
            p.EstadoCivil = Convert.ToInt32(cbEstadoCivil.SelectedValue);
            if (rbMasculino.Checked)
                p.Sexo = 1;
            else
                p.Sexo = 2;
            p.Fallecido = Convert.ToBoolean(cbFallecido.Checked);

            if(MessageBox.Show("Esta seguro que quiere eliminar a esta persona?","Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lstPersonas.SelectedIndex != -1)
                {
                    string query = "delete personas where documento = @documento";
                    int filas = helper.EjecutarInsert(query, p);
                    if (filas == 1)
                    {
                        MessageBox.Show("Se ha  eliminado la persona", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Limpiar();
                        CargarLista();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar la persona", "Eliminar", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btGrabar_Click(object sender, EventArgs e)
        {
            Personas p = new Personas();
            p.Nombre = txtNombre.Text;
            p.Apellido = txtApellido.Text;
            p.Documento = Convert.ToInt32(txtDocumento.Text);
            p.TipoDocumento = Convert.ToInt32(cbTipoDocumento.SelectedValue);
            p.EstadoCivil = Convert.ToInt32(cbEstadoCivil.SelectedValue);
            if (rbMasculino.Checked)
                p.Sexo = 1;
            else
                p.Sexo = 2;
            p.Fallecido = Convert.ToBoolean(cbFallecido.Checked);

            if (nuevo)
            {
                if (MessageBox.Show("Esta seguro que quiere agregar a esta persona?", "grabando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = "insert into personas values(@apellido,@nombres,@tipo_documento,@documento,@estado_civil,@sexo,@fallecio)";
                    int filas = helper.EjecutarInsert(query, p);
                    if (filas == 1)
                    {
                        MessageBox.Show("La persona se ha registrado con exito!", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarLista();
                        Habilitar(false);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("La persona no se ha registrado", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Habilitar(false);
                    }
                }
               
            }
            else
            {
                if (MessageBox.Show("Esta seguro que quiere actualizar a esta persona?", "actualizando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = "update personas set apellido = @apellido,nombres = @nombres,tipo_documento=@tipo_documento,documento=@documento,estado_civil=@estado_civil,sexo=@sexo,fallecio=@fallecio where documento = @documento";
                    int filas = helper.EjecutarInsert(query, p);
                    if (filas == 1)
                    {
                        MessageBox.Show("La persona se ha actualizado con exito!", "actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarLista();
                        Habilitar(false);
                    }
                    else
                    {
                        MessageBox.Show("La persona no se ha actualizado", "actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Habilitar(false);
                    }
                }
            }
        }
    }
}
