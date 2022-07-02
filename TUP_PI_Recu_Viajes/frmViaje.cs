using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//CURSO – LEGAJO – APELLIDO – NOMBRE

namespace TUP_PI_Recu_Viajes
{
    public partial class frmViaje : Form
    {
        bool nuevo;
        ConexionDB helper;

        public frmViaje()
        {
            helper = new ConexionDB();
            InitializeComponent();
        }

        public void Habilitar(bool x)
        {
            txtCodigo.Enabled = x;
            txtDestino.Enabled = x;
            cboTransporte.Enabled = x;
            rbtNacional.Enabled = x;
            rbtInternacional.Enabled = x;
            dtpFecha.Enabled = x;
            btnGrabar.Enabled = x;
            btCancelar.Enabled = x;
            btnNuevo.Enabled = !x;
            btEditar.Enabled = !x;
            lstViajes.Enabled = !x;
            btnSalir.Enabled = true;
        }

        public void Limpiar()
        { 
            txtCodigo.Text = String.Empty;
            txtDestino.Text = String.Empty;
            cboTransporte.SelectedValue = -1;
            rbtNacional.Checked = false;
            rbtInternacional.Checked = false;
            dtpFecha.Value = DateTime.Now;
        }

        public void CargarCombo()
        {
            DataTable table = helper.EjecutarQuery("select * from transportes");
            cboTransporte.DataSource = table;
            cboTransporte.ValueMember = "idtransporte";
            cboTransporte.DisplayMember = "nombretransporte";
           
        }

        public void CargarLista()
        {
            DataTable table = helper.EjecutarQuery("select * from viajes");
            lstViajes.Items.Clear();
            foreach (DataRow dr in table.Rows)
            {
                Viaje v = new Viaje();
                v.pCodigo = Convert.ToInt32(dr["codigo"].ToString());
                v.pDestino = dr["destino"].ToString();
                v.pTransporte = Convert.ToInt32(dr["transporte"].ToString());
                v.pTipo = Convert.ToInt32(dr["tipo"].ToString());
                v.pFecha = Convert.ToDateTime(dr["fecha"].ToString());
                lstViajes.Items.Add(v);
            }
        }


        private void frmViaje_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CargarLista();
            Habilitar(false);
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            Limpiar();
            nuevo = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Esta seguro que quiere salir?","Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                this.Dispose();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Viaje v = new Viaje();
            v.pCodigo = Convert.ToInt32(txtCodigo.Text);
            v.pDestino = txtDestino.Text;
            v.pTransporte = Convert.ToInt32(cboTransporte.SelectedValue);
            if (rbtNacional.Checked)
               v.pTipo = 1;
            else
                v.pTipo = 2;
            v.pFecha = Convert.ToDateTime(dtpFecha.Value);

            if(Validar() && nuevo)
            {
                if(MessageBox.Show("Esta seguro que quiere grabar?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string query = "insert into viajes values(@codigo,@destino,@transporte,@tipo,@fecha)";
                    int filas = helper.EjectutarInsert(query, v);
                    if (filas == 1)
                    {
                        MessageBox.Show("El viaje se grabo con exito", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarLista();
                        Habilitar(false);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El viaje no se pudo grabar", "Gabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        Habilitar(false);
                        Limpiar();
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Esta seguro que quiere actualizar este viaje?", "actualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string query = "update viajes set codigo=@codigo,destino = @destino,transporte=@transporte,tipo=@tipo,fecha=@fecha where codigo = @codigo";
                    int filas = helper.EjectutarInsert(query, v);
                    if (filas == 1)
                    {
                        MessageBox.Show("El viaje se actualizo con exito", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarLista();
                        Habilitar(false);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El viaje no se pudo actualizar", "actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Habilitar(false);
                        Limpiar();
                    }
                }
            }










        }

        private bool Validar()
        {
            return true;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void lstViajes_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(lstViajes.SelectedIndex != -1)
            {
                Viaje v = (Viaje)lstViajes.SelectedItem;
                txtCodigo.Text = v.pCodigo.ToString();
                txtDestino.Text = v.pDestino.ToString();
                cboTransporte.SelectedValue = v.pTransporte.ToString();
                if (v.pTipo == 1)
                {
                    rbtNacional.Checked = true;
                }
                else
                {
                    rbtInternacional.Checked = true;
                }
                    
                dtpFecha.Value = v.pFecha;
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            nuevo = false;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Esta seguro que quiere cancelar?","Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Limpiar();
                Habilitar(false);
            }
        }
    }
}
