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

using Adquisoft.Registro_sw;

namespace Adquisoft
{
    /// <summary>
    /// Interaction logic for ModuloEstudiante.xaml
    /// </summary>
    public partial class ModuloPrincipal : MetroWindow
    {
        public ModuloPrincipal()
        {
            InitializeComponent();
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            MenuRegistro_sw cargar = new MenuRegistro_sw();
            this.Close();
            cargar.ShowDialog();

        }
    }
}
