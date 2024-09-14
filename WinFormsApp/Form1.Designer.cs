namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Btn_Departamentos = new Button();
            Btn_Empleados = new Button();
            SuspendLayout();
            // 
            // Btn_Departamentos
            // 
            Btn_Departamentos.Location = new Point(146, 174);
            Btn_Departamentos.Name = "Btn_Departamentos";
            Btn_Departamentos.Size = new Size(245, 84);
            Btn_Departamentos.TabIndex = 0;
            Btn_Departamentos.Text = "Departamentos";
            Btn_Departamentos.UseVisualStyleBackColor = true;
            Btn_Departamentos.Click += Btn_Departamentos_Click;
            // 
            // Btn_Empleados
            // 
            Btn_Empleados.Location = new Point(476, 174);
            Btn_Empleados.Name = "Btn_Empleados";
            Btn_Empleados.Size = new Size(235, 84);
            Btn_Empleados.TabIndex = 1;
            Btn_Empleados.Text = "Empleados";
            Btn_Empleados.UseVisualStyleBackColor = true;
            Btn_Empleados.Click += Btn_Empleados_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Btn_Empleados);
            Controls.Add(Btn_Departamentos);
            Name = "Form1";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button Btn_Departamentos;
        private Button Btn_Empleados;
    }
}
