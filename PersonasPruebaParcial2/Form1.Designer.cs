namespace PersonasPruebaParcial2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstPersonas = new System.Windows.Forms.ListBox();
            this.btSalir = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btGrabar = new System.Windows.Forms.Button();
            this.btBorrar = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.cbFallecido = new System.Windows.Forms.CheckBox();
            this.btNuevo = new System.Windows.Forms.Button();
            this.rbMasculino = new System.Windows.Forms.RadioButton();
            this.rbFemenino = new System.Windows.Forms.RadioButton();
            this.cbEstadoCivil = new System.Windows.Forms.ComboBox();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstPersonas
            // 
            this.lstPersonas.FormattingEnabled = true;
            this.lstPersonas.Location = new System.Drawing.Point(356, 12);
            this.lstPersonas.Name = "lstPersonas";
            this.lstPersonas.Size = new System.Drawing.Size(202, 329);
            this.lstPersonas.TabIndex = 64;
            this.lstPersonas.SelectedIndexChanged += new System.EventHandler(this.lstPersonas_SelectedIndexChanged);
            // 
            // btSalir
            // 
            this.btSalir.Location = new System.Drawing.Point(483, 362);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(75, 23);
            this.btSalir.TabIndex = 63;
            this.btSalir.Text = "Salir";
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(391, 362);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 62;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btGrabar
            // 
            this.btGrabar.Location = new System.Drawing.Point(296, 362);
            this.btGrabar.Name = "btGrabar";
            this.btGrabar.Size = new System.Drawing.Size(75, 23);
            this.btGrabar.TabIndex = 61;
            this.btGrabar.Text = "Grabar";
            this.btGrabar.UseVisualStyleBackColor = true;
            this.btGrabar.Click += new System.EventHandler(this.btGrabar_Click);
            // 
            // btBorrar
            // 
            this.btBorrar.Location = new System.Drawing.Point(204, 362);
            this.btBorrar.Name = "btBorrar";
            this.btBorrar.Size = new System.Drawing.Size(75, 23);
            this.btBorrar.TabIndex = 60;
            this.btBorrar.Text = "Borrar";
            this.btBorrar.UseVisualStyleBackColor = true;
            this.btBorrar.Click += new System.EventHandler(this.btBorrar_Click);
            // 
            // btEditar
            // 
            this.btEditar.Location = new System.Drawing.Point(106, 362);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(75, 23);
            this.btEditar.TabIndex = 59;
            this.btEditar.Text = "Editar";
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // cbFallecido
            // 
            this.cbFallecido.AutoSize = true;
            this.cbFallecido.Location = new System.Drawing.Point(137, 310);
            this.cbFallecido.Name = "cbFallecido";
            this.cbFallecido.Size = new System.Drawing.Size(15, 14);
            this.cbFallecido.TabIndex = 58;
            this.cbFallecido.UseVisualStyleBackColor = true;
            // 
            // btNuevo
            // 
            this.btNuevo.Location = new System.Drawing.Point(10, 362);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(75, 23);
            this.btNuevo.TabIndex = 57;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = true;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // rbMasculino
            // 
            this.rbMasculino.AutoSize = true;
            this.rbMasculino.Location = new System.Drawing.Point(137, 253);
            this.rbMasculino.Name = "rbMasculino";
            this.rbMasculino.Size = new System.Drawing.Size(73, 17);
            this.rbMasculino.TabIndex = 56;
            this.rbMasculino.TabStop = true;
            this.rbMasculino.Text = "Masculino";
            this.rbMasculino.UseVisualStyleBackColor = true;
            // 
            // rbFemenino
            // 
            this.rbFemenino.AutoSize = true;
            this.rbFemenino.Location = new System.Drawing.Point(137, 207);
            this.rbFemenino.Name = "rbFemenino";
            this.rbFemenino.Size = new System.Drawing.Size(71, 17);
            this.rbFemenino.TabIndex = 55;
            this.rbFemenino.TabStop = true;
            this.rbFemenino.Text = "Femenino";
            this.rbFemenino.UseVisualStyleBackColor = true;
            // 
            // cbEstadoCivil
            // 
            this.cbEstadoCivil.FormattingEnabled = true;
            this.cbEstadoCivil.Items.AddRange(new object[] {
            "SOLTERO/A",
            "CASADO/A",
            "VIUDO/A"});
            this.cbEstadoCivil.Location = new System.Drawing.Point(137, 168);
            this.cbEstadoCivil.Name = "cbEstadoCivil";
            this.cbEstadoCivil.Size = new System.Drawing.Size(202, 21);
            this.cbEstadoCivil.TabIndex = 54;
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.FormattingEnabled = true;
            this.cbTipoDocumento.Items.AddRange(new object[] {
            "DNI",
            "PASAPORTE",
            "CARNET"});
            this.cbTipoDocumento.Location = new System.Drawing.Point(137, 81);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Size = new System.Drawing.Size(202, 21);
            this.cbTipoDocumento.TabIndex = 53;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(137, 124);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(202, 20);
            this.txtDocumento.TabIndex = 52;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(137, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(202, 20);
            this.txtNombre.TabIndex = 51;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(137, 12);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(202, 20);
            this.txtApellido.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Fallecido";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "Estado Civil";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Sexo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Tipo Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Nombres";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Apellido";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(570, 403);
            this.Controls.Add(this.lstPersonas);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btGrabar);
            this.Controls.Add(this.btBorrar);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.cbFallecido);
            this.Controls.Add(this.btNuevo);
            this.Controls.Add(this.rbMasculino);
            this.Controls.Add(this.rbFemenino);
            this.Controls.Add(this.cbEstadoCivil);
            this.Controls.Add(this.cbTipoDocumento);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPersonas;
        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btGrabar;
        private System.Windows.Forms.Button btBorrar;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.CheckBox cbFallecido;
        private System.Windows.Forms.Button btNuevo;
        private System.Windows.Forms.RadioButton rbMasculino;
        private System.Windows.Forms.RadioButton rbFemenino;
        private System.Windows.Forms.ComboBox cbEstadoCivil;
        private System.Windows.Forms.ComboBox cbTipoDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

