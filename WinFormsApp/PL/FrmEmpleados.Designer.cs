namespace WinFormsApp.PL
{
    partial class FrmEmpleados
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
            Lbl_Id = new Label();
            Txt_Id = new TextBox();
            Txt_Nombre = new TextBox();
            Lbl_Nombre = new Label();
            Txt_PrimerApellido = new TextBox();
            Txt_Correo = new TextBox();
            Txt_SegundoApellido = new TextBox();
            Lbl_PrimerApellido = new Label();
            Lbl_SegundoApellido = new Label();
            Lbl_Correo = new Label();
            Lbl_Departamento = new Label();
            Cbo_Departamento = new ComboBox();
            Pib_Foto = new PictureBox();
            Btn_Examinar = new Button();
            Btn_Agregar = new Button();
            Btn_Modificar = new Button();
            Btn_Borrar = new Button();
            Dgv_Empleados = new DataGridView();
            Btn_Cancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)Pib_Foto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Dgv_Empleados).BeginInit();
            SuspendLayout();
            // 
            // Lbl_Id
            // 
            Lbl_Id.AutoSize = true;
            Lbl_Id.Location = new Point(352, 35);
            Lbl_Id.Name = "Lbl_Id";
            Lbl_Id.Size = new Size(17, 15);
            Lbl_Id.TabIndex = 0;
            Lbl_Id.Text = "Id";
            // 
            // Txt_Id
            // 
            Txt_Id.Location = new Point(352, 53);
            Txt_Id.Name = "Txt_Id";
            Txt_Id.Size = new Size(182, 23);
            Txt_Id.TabIndex = 1;
            // 
            // Txt_Nombre
            // 
            Txt_Nombre.Location = new Point(566, 53);
            Txt_Nombre.Name = "Txt_Nombre";
            Txt_Nombre.Size = new Size(182, 23);
            Txt_Nombre.TabIndex = 2;
            // 
            // Lbl_Nombre
            // 
            Lbl_Nombre.AutoSize = true;
            Lbl_Nombre.Location = new Point(566, 35);
            Lbl_Nombre.Name = "Lbl_Nombre";
            Lbl_Nombre.Size = new Size(51, 15);
            Lbl_Nombre.TabIndex = 3;
            Lbl_Nombre.Text = "Nombre";
            // 
            // Txt_PrimerApellido
            // 
            Txt_PrimerApellido.Location = new Point(352, 96);
            Txt_PrimerApellido.Name = "Txt_PrimerApellido";
            Txt_PrimerApellido.Size = new Size(182, 23);
            Txt_PrimerApellido.TabIndex = 4;
            // 
            // Txt_Correo
            // 
            Txt_Correo.Location = new Point(352, 137);
            Txt_Correo.Name = "Txt_Correo";
            Txt_Correo.Size = new Size(396, 23);
            Txt_Correo.TabIndex = 5;
            // 
            // Txt_SegundoApellido
            // 
            Txt_SegundoApellido.Location = new Point(566, 96);
            Txt_SegundoApellido.Name = "Txt_SegundoApellido";
            Txt_SegundoApellido.Size = new Size(182, 23);
            Txt_SegundoApellido.TabIndex = 6;
            // 
            // Lbl_PrimerApellido
            // 
            Lbl_PrimerApellido.AutoSize = true;
            Lbl_PrimerApellido.Location = new Point(352, 79);
            Lbl_PrimerApellido.Name = "Lbl_PrimerApellido";
            Lbl_PrimerApellido.Size = new Size(89, 15);
            Lbl_PrimerApellido.TabIndex = 8;
            Lbl_PrimerApellido.Text = "Primer Apellido";
            // 
            // Lbl_SegundoApellido
            // 
            Lbl_SegundoApellido.AutoSize = true;
            Lbl_SegundoApellido.Location = new Point(566, 79);
            Lbl_SegundoApellido.Name = "Lbl_SegundoApellido";
            Lbl_SegundoApellido.Size = new Size(101, 15);
            Lbl_SegundoApellido.TabIndex = 9;
            Lbl_SegundoApellido.Text = "Segundo Apellido";
            // 
            // Lbl_Correo
            // 
            Lbl_Correo.AutoSize = true;
            Lbl_Correo.Location = new Point(352, 121);
            Lbl_Correo.Name = "Lbl_Correo";
            Lbl_Correo.Size = new Size(43, 15);
            Lbl_Correo.TabIndex = 10;
            Lbl_Correo.Text = "Correo";
            // 
            // Lbl_Departamento
            // 
            Lbl_Departamento.AutoSize = true;
            Lbl_Departamento.Location = new Point(352, 163);
            Lbl_Departamento.Name = "Lbl_Departamento";
            Lbl_Departamento.Size = new Size(83, 15);
            Lbl_Departamento.TabIndex = 11;
            Lbl_Departamento.Text = "Departamento";
            // 
            // Cbo_Departamento
            // 
            Cbo_Departamento.FormattingEnabled = true;
            Cbo_Departamento.Location = new Point(352, 181);
            Cbo_Departamento.Name = "Cbo_Departamento";
            Cbo_Departamento.Size = new Size(396, 23);
            Cbo_Departamento.TabIndex = 12;
            // 
            // Pib_Foto
            // 
            Pib_Foto.Location = new Point(74, 53);
            Pib_Foto.Name = "Pib_Foto";
            Pib_Foto.Size = new Size(155, 148);
            Pib_Foto.TabIndex = 13;
            Pib_Foto.TabStop = false;
            // 
            // Btn_Examinar
            // 
            Btn_Examinar.Location = new Point(74, 229);
            Btn_Examinar.Name = "Btn_Examinar";
            Btn_Examinar.Size = new Size(155, 35);
            Btn_Examinar.TabIndex = 14;
            Btn_Examinar.Text = "Examinar";
            Btn_Examinar.UseVisualStyleBackColor = true;
            Btn_Examinar.Click += BtnExaminar_Click;
            // 
            // Btn_Agregar
            // 
            Btn_Agregar.Location = new Point(353, 229);
            Btn_Agregar.Name = "Btn_Agregar";
            Btn_Agregar.Size = new Size(88, 35);
            Btn_Agregar.TabIndex = 15;
            Btn_Agregar.Text = "Agregar";
            Btn_Agregar.UseVisualStyleBackColor = true;
            Btn_Agregar.Click += BtnAgregar_Click;
            // 
            // Btn_Modificar
            // 
            Btn_Modificar.Location = new Point(463, 229);
            Btn_Modificar.Name = "Btn_Modificar";
            Btn_Modificar.Size = new Size(88, 35);
            Btn_Modificar.TabIndex = 16;
            Btn_Modificar.Text = "Modificar";
            Btn_Modificar.UseVisualStyleBackColor = true;
            Btn_Modificar.Click += BtnModificar_Click;
            // 
            // Btn_Borrar
            // 
            Btn_Borrar.Location = new Point(566, 229);
            Btn_Borrar.Name = "Btn_Borrar";
            Btn_Borrar.Size = new Size(88, 35);
            Btn_Borrar.TabIndex = 17;
            Btn_Borrar.Text = "Borrar";
            Btn_Borrar.UseVisualStyleBackColor = true;
            Btn_Borrar.Click += BtnBorrar_Click;
            // 
            // Dgv_Empleados
            // 
            Dgv_Empleados.AllowUserToAddRows = false;
            Dgv_Empleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Empleados.Location = new Point(41, 298);
            Dgv_Empleados.Name = "Dgv_Empleados";
            Dgv_Empleados.RowHeadersWidth = 51;
            Dgv_Empleados.Size = new Size(715, 208);
            Dgv_Empleados.TabIndex = 18;
            Dgv_Empleados.CellMouseClick += Seleccionar;
            // 
            // Btn_Cancelar
            // 
            Btn_Cancelar.Location = new Point(666, 229);
            Btn_Cancelar.Name = "Btn_Cancelar";
            Btn_Cancelar.Size = new Size(88, 35);
            Btn_Cancelar.TabIndex = 19;
            Btn_Cancelar.Text = "Cancelar";
            Btn_Cancelar.UseVisualStyleBackColor = true;
            Btn_Cancelar.Click += BtnCancelar_Click;
            // 
            // FrmEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 518);
            Controls.Add(Btn_Cancelar);
            Controls.Add(Dgv_Empleados);
            Controls.Add(Btn_Borrar);
            Controls.Add(Btn_Modificar);
            Controls.Add(Btn_Agregar);
            Controls.Add(Btn_Examinar);
            Controls.Add(Pib_Foto);
            Controls.Add(Cbo_Departamento);
            Controls.Add(Lbl_Departamento);
            Controls.Add(Lbl_Correo);
            Controls.Add(Lbl_SegundoApellido);
            Controls.Add(Lbl_PrimerApellido);
            Controls.Add(Txt_SegundoApellido);
            Controls.Add(Txt_Correo);
            Controls.Add(Txt_PrimerApellido);
            Controls.Add(Lbl_Nombre);
            Controls.Add(Txt_Nombre);
            Controls.Add(Txt_Id);
            Controls.Add(Lbl_Id);
            Name = "FrmEmpleados";
            Text = "FrmEmpleados";
            Load += FrmEmpleados_Load;
            ((System.ComponentModel.ISupportInitialize)Pib_Foto).EndInit();
            ((System.ComponentModel.ISupportInitialize)Dgv_Empleados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lbl_Id;
        private TextBox Txt_Id;
        private TextBox Txt_Nombre;
        private Label Lbl_Nombre;
        private TextBox Txt_PrimerApellido;
        private TextBox Txt_Correo;
        private TextBox Txt_SegundoApellido;
        private Label Lbl_PrimerApellido;
        private Label Lbl_SegundoApellido;
        private Label Lbl_Correo;
        private Label Lbl_Departamento;
        private ComboBox Cbo_Departamento;
        private PictureBox Pib_Foto;
        private Button Btn_Examinar;
        private Button Btn_Agregar;
        private Button Btn_Modificar;
        private Button Btn_Borrar;
        private DataGridView Dgv_Empleados;
        private Button Btn_Cancelar;
    }
}