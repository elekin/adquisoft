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


namespace Adquisoft.Registro_sw
{
    /// <summary>
    /// Lógica de interacción para MenuRegistro_sw.xaml
    /// </summary>
    public partial class MenuRegistro_sw : MetroWindow
    {
        public MenuRegistro_sw()
        {
            InitializeComponent();
        }

      
        private void btn_nuevo_sw_Click(object sender, RoutedEventArgs e)
        {
            RegistrarNuevoSoftware cargar = new RegistrarNuevoSoftware();
            this.Close();
            cargar.ShowDialog();

        }

        private void btn_registro_Click(object sender, RoutedEventArgs e)
        {
            Registros_sw cargar = new Registros_sw();
            this.Close();
            cargar.ShowDialog();
        }

        private void btn_regresar_menu_principal_Click(object sender, RoutedEventArgs e)
        {
            ModuloPrincipal cargar = new ModuloPrincipal();
            this.Close();
            cargar.ShowDialog();
        }
    }
}
