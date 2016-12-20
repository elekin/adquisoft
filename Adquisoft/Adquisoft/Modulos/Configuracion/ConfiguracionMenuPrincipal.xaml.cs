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
using AdquisicionSoftware.Modulos;
using Adquisoft.Modulos.Metricas;

namespace Adquisoft.Modulos.Configuracion
{
    /// <summary>
    /// Lógica de interacción para ConfiguracionMenuPrincipal.xaml
    /// </summary>
    public partial class ConfiguracionMenuPrincipal : MetroWindow
    {
        public ConfiguracionMenuPrincipal()
        {
            InitializeComponent();
        }

      

        private void btnCategorias_Click(object sender, RoutedEventArgs e)
        {
            ConfiguracionCategorias cargar = new ConfiguracionCategorias();
            cargar.ShowDialog();
        }

        private void btn_menu_principal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMetricas_Click(object sender, RoutedEventArgs e)
        {
            AgregarMetrica m = new AgregarMetrica();
            m.ShowDialog();
        }
    }
}
