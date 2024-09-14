using Microsoft.Extensions.DependencyInjection;
using WinFormsApp.BLL;
using WinFormsApp.BLL.Contratos;
using WinFormsApp.DAL;
using WinFormsApp.DAL.Contrato;
using WinFormsApp.PL;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
  
        private readonly IServiceProvider _serviceProvider;
        
        public Form1(IServiceProvider serviceProvider)
        {
            
           
            InitializeComponent();
            _serviceProvider = serviceProvider;
            
        }


        private void Btn_Departamentos_Click(object sender, EventArgs e)
        {

            var formDepartamentos = _serviceProvider.GetRequiredService<FrmDepartamentos>();
            formDepartamentos.Show();
        }

        private void Btn_Empleados_Click(object sender, EventArgs e)
        {
            var formEmpleados = _serviceProvider.GetRequiredService<FrmEmpleados>();           
            formEmpleados.Show();
        }
    }
}
