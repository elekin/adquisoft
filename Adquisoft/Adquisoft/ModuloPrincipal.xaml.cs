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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

using Adquisoft.Modulos.Evaluacion_Calidad;
using Adquisoft.Modulos.Registro_sw;
using Adquisoft.Modulos.Perfil_usuario;
using Adquisoft.Modulos.administracion;

namespace Adquisoft
{
    /// <summary>
    /// Interaction logic for ModuloEstudiante.xaml
    /// </summary>
    public partial class ModuloPrincipal : MetroWindow
    {
        public ModuloPrincipal(Usuario.Permisos_usuario usuario)
        {
            InitializeComponent();
            this.lbl_nombre_usuario.Content = usuario.Nombre_usuario;
        }

        private async void btn_cerrar_sesion_Click(object sender, RoutedEventArgs e)
        {                 


            /*const string mensaje =
            "¿realmente quiere cerrar su sesión?";
            const string caption = "Cerrar sesión";
            var  result = MessageBox.Show(mensaje, caption,
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);*/


           var r =  await this.ShowMessageAsync("Cerrar sesión",
               "¿realmente quiere cerrar su sesión?", MessageDialogStyle.AffirmativeAndNegative, null);                    



            if (r.ToString() == "Affirmative")
            {
                //cierra sesion e inicia login
                MainWindow login = new MainWindow();
                this.Close();
                login.ShowDialog();

            }


        }

        private void btnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            //carga modulo configuración
            Modulos.Configuracion.ConfiguracionMenuPrincipal cargar = new Modulos.Configuracion.ConfiguracionMenuPrincipal();
            cargar.ShowDialog();
        }

        private void btnRegistroSoftware_Click(object sender, RoutedEventArgs e)
        {
            MenuRegistro_sw cargar = new MenuRegistro_sw(this);
            //this.Visibility = Visibility.Hidden;
            cargar.ShowDialog();
        }

        private void btnAdministracion_Click(object sender, RoutedEventArgs e)
        {
            AdministrarUsuarios administraPermisos = new AdministrarUsuarios();
            administraPermisos.ShowDialog();
        }

        private void btnPerfil_usuario_Click(object sender, RoutedEventArgs e)
        {
            Perfilusuario perfil_user = new Perfilusuario(this.lbl_nombre_usuario.Content.ToString());
            perfil_user.ShowDialog();
        }

        private void btnEvaluacionAdquisicion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEvaluacionCalidad_Click(object sender, RoutedEventArgs e)
        {
            EvaluacionCalidad evaluacion = new EvaluacionCalidad();
            evaluacion.Visibility = Visibility.Visible;
        }

        private void btnInformesEvaluacion_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
