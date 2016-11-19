using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using Npgsql;
using Adquisoft.Conexion_BD;

namespace Adquisoft
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btn_identificarse_Click(object sender, RoutedEventArgs e)
        {

            string usuario = txt_usuario.Text;
            string password = pw_contraseña.Password;

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();


            String buscaUsuario = "select nombre_usuario, password from usuario";
            NpgsqlCommand comandoBuscaUsuario = new NpgsqlCommand(buscaUsuario, conexionBD);
            NpgsqlDataReader drBuscaUsuario = comandoBuscaUsuario.ExecuteReader();

            while (drBuscaUsuario.Read())
            {
                if (usuario.Equals(drBuscaUsuario["nombre_usuario"].ToString()) && password.Equals(drBuscaUsuario["password"].ToString()))
                {
                    conexionBD.Close();
                    
                   // this.ShowMessageAsync("Bienvenido", "login correcto");

                    ModuloPrincipal cargar = new ModuloPrincipal();
                    

                    this.Close();
                    cargar.ShowDialog();
                }
                
            }
            conexionBD.Close();

            this.ShowMessageAsync("Error", "Datos incorrectos");
           
        }
    }
}
