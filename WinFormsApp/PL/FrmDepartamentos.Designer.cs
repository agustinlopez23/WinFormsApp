namespace WinFormsApp.PL
{
    partial class FrmDepartamentos
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
            Lbl_IdDepartamento = new Label();
            Txt_IdDepartamento = new TextBox();
            Txt_NombreDepartamento = new TextBox();
            Lbl_NombreDepartamento = new Label();
            Btn_Agregar = new Button();
            Btn_Modificar = new Button();
            Btn_Borrar = new Button();
            Btn_Cancelar = new Button();
            Dgv_Departamentos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Dgv_Departamentos).BeginInit();
            SuspendLayout();
            // 
            // Lbl_IdDepartamento
            // 
            Lbl_IdDepartamento.AutoSize = true;
            Lbl_IdDepartamento.Location = new Point(65, 33);
            Lbl_IdDepartamento.Name = "Lbl_IdDepartamento";
            Lbl_IdDepartamento.Size = new Size(18, 15);
            Lbl_IdDepartamento.TabIndex = 0;
            Lbl_IdDepartamento.Text = "ID";
            // 
            // Txt_IdDepartamento
            // 
            Txt_IdDepartamento.Location = new Point(66, 55);
            Txt_IdDepartamento.Name = "Txt_IdDepartamento";
            Txt_IdDepartamento.Size = new Size(309, 23);
            Txt_IdDepartamento.TabIndex = 1;
            // 
            // Txt_NombreDepartamento
            // 
            Txt_NombreDepartamento.Location = new Point(418, 55);
            Txt_NombreDepartamento.Name = "Txt_NombreDepartamento";
            Txt_NombreDepartamento.Size = new Size(316, 23);
            Txt_NombreDepartamento.TabIndex = 2;
            // 
            // Lbl_NombreDepartamento
            // 
            Lbl_NombreDepartamento.AutoSize = true;
            Lbl_NombreDepartamento.Location = new Point(418, 33);
            Lbl_NombreDepartamento.Name = "Lbl_NombreDepartamento";
            Lbl_NombreDepartamento.Size = new Size(130, 15);
            Lbl_NombreDepartamento.TabIndex = 3;
            Lbl_NombreDepartamento.Text = "Nombre Departamento";
            // 
            // Btn_Agregar
            // 
            Btn_Agregar.Location = new Point(65, 108);
            Btn_Agregar.Name = "Btn_Agregar";
            Btn_Agregar.Size = new Size(134, 23);
            Btn_Agregar.TabIndex = 4;
            Btn_Agregar.Text = "Agregar";
            Btn_Agregar.UseVisualStyleBackColor = true;
            Btn_Agregar.Click += BtnAgregar_Click;
            // 
            // Btn_Modificar
            // 
            Btn_Modificar.Enabled = false;
            Btn_Modificar.Location = new Point(241, 108);
            Btn_Modificar.Name = "Btn_Modificar";
            Btn_Modificar.Size = new Size(134, 23);
            Btn_Modificar.TabIndex = 5;
            Btn_Modificar.Text = "Modificar";
            Btn_Modificar.UseVisualStyleBackColor = true;
            Btn_Modificar.Click += BtnModificar_Click;
            // 
            // Btn_Borrar
            // 
            Btn_Borrar.Enabled = false;
            Btn_Borrar.Location = new Point(418, 108);
            Btn_Borrar.Name = "Btn_Borrar";
            Btn_Borrar.Size = new Size(134, 23);
            Btn_Borrar.TabIndex = 6;
            Btn_Borrar.Text = "Borrar";
            Btn_Borrar.UseVisualStyleBackColor = true;
            Btn_Borrar.Click += BtnBorrar_Click;
            // 
            // Btn_Cancelar
            // 
            Btn_Cancelar.Enabled = false;
            Btn_Cancelar.Location = new Point(600, 108);
            Btn_Cancelar.Name = "Btn_Cancelar";
            Btn_Cancelar.Size = new Size(134, 23);
            Btn_Cancelar.TabIndex = 7;
            Btn_Cancelar.Text = "Cancelar";
            Btn_Cancelar.UseVisualStyleBackColor = true;
            Btn_Cancelar.Click += BtnCancelar_Click;
            // 
            // Dgv_Departamentos
            // 
            Dgv_Departamentos.AllowUserToAddRows = false;
            Dgv_Departamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Departamentos.Location = new Point(29, 150);
            Dgv_Departamentos.Name = "Dgv_Departamentos";
            Dgv_Departamentos.Size = new Size(746, 271);
            Dgv_Departamentos.TabIndex = 8;
            Dgv_Departamentos.CellMouseClick += SeleccionarDepartamento;
            // 
            // FrmDepartamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Dgv_Departamentos);
            Controls.Add(Btn_Cancelar);
            Controls.Add(Btn_Borrar);
            Controls.Add(Btn_Modificar);
            Controls.Add(Btn_Agregar);
            Controls.Add(Lbl_NombreDepartamento);
            Controls.Add(Txt_NombreDepartamento);
            Controls.Add(Txt_IdDepartamento);
            Controls.Add(Lbl_IdDepartamento);
            Name = "FrmDepartamentos";
            Text = "FrmDepartamentos";
            ((System.ComponentModel.ISupportInitialize)Dgv_Departamentos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lbl_IdDepartamento;
        private TextBox Txt_IdDepartamento;
        private TextBox Txt_NombreDepartamento;
        private Label Lbl_NombreDepartamento;
        private Button Btn_Agregar;
        private Button Btn_Modificar;
        private Button Btn_Borrar;
        private Button Btn_Cancelar;
        private DataGridView Dgv_Departamentos;
    }
}