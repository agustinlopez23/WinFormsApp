using System.Configuration;
using WinFormsApp.DAL.Contrato;
using WinFormsApp.DAL;
using WinFormsApp.PL;
using Microsoft.Extensions.DependencyInjection;
using WinFormsApp.BLL;
using WinFormsApp.DAL.Modelos;
using Microsoft.Extensions.Hosting;


namespace WinFormsApp
{
    static class Program

    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {           
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);
            var host = CreateHostBuilder().Build();
            var fromStartService = host.Services.GetRequiredService<Form1>();
            Application.Run(fromStartService);
        }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {

                    // Registrar DbConexionFactory con la cadena de conexión
                    var conecctionstring = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                    services.AddSingleton(new DbConexionFactory(conecctionstring));
                 
                    // Registrar repositorios y servicios
                    services.AddTransient<IGenericRepository<Departamento>, DepartamentoRepository>();
                    services.AddTransient<DepartamentoService>();

                    services.AddTransient<IGenericRepository<Empleado>, EmpleadoRepository>();
                    services.AddTransient<EmpleadoService>();

                    // Registrar formularios
                    services.AddTransient<Form1>();
                    services.AddTransient<FrmDepartamentos>();
                    services.AddTransient<FrmEmpleados>();
                });
        }

    }
}