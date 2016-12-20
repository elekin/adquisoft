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
using Adquisoft.Usuario;
using Npgsql;
using Adquisoft.Constantes;

namespace Adquisoft.Modulos.Perfil_usuario
{
    /// <summary>
    /// Lógica de interacción para Perfilusuario.xaml
    /// </summary>
    public partial class Perfilusuario : MetroWindow
    {
        public Perfilusuario(string nombre_usuario)
        {
            InitializeComponent();



            this.textNombre.IsEnabled = false;           
            textApellido1.IsEnabled = false;
            textApellido2.IsEnabled = false;
            textCargo.IsEnabled = false;

            textUser.IsEnabled = false;
            this.passwordBox_user.IsEnabled = false;




            CargaInfoUsuario(nombre_usuario);


        }



        private void CargaInfoUsuario(string nombreusuario)
        {
            InformacionUsuario user = new InformacionUsuario(nombreusuario);

            this.textNombre.Text = user.Nombre;
            this.textApellido1.Text = user.Apellido1;
            this.textApellido2.Text = user.Apellido2;
            this.textCargo.Text = user.Cargo;

            this.textUser.Text = user.Name_user;
            this.passwordBox_user.Password = user.Password;
        }

        private void btnModificarPassword_Click(object sender, RoutedEventArgs e)
        {
            textUser.IsEnabled = true;
            this.passwordBox_user.IsEnabled = true;
           

            btnModificarPassword.Visibility = Visibility.Hidden;
            this.btnModificarPassword_Guardar.Visibility = Visibility.Visible;

            this.passwordBox_user_repite.Visibility = Visibility.Visible;
           
        }

        private void btnModificarPassword_Guardar_Click(object sender, RoutedEventArgs e)
        {
            //conecta BD

            if (this.passwordBox_user.Password == this.passwordBox_user_repite.Password)
            {

                NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
                conexionBD.Open();

                string consulta = "UPDATE usuario  SET password = '" + this.passwordBox_user.Password + "'  WHERE  nombre_usuario = '" + this.textUser.Text + "' ;";


                NpgsqlCommand comandoActualizapass = new NpgsqlCommand(consulta, conexionBD);
                comandoActualizapass.ExecuteNonQuery();

                conexionBD.Close();

                this.btnModificarPassword_Guardar.Visibility = Visibility.Hidden;
                this.btnModificarPassword.Visibility = Visibility.Visible;
                this.passwordBox_user_repite.Visibility = Visibility.Hidden;

                MessageBox.Show("Contraseña modificada exitosamente","cambio contraseña acceso",MessageBoxButton.OK,MessageBoxImage.Information);

            }
            else
            {

                MessageBox.Show("Las contraseñas no coinciden!");
            }

            
        }

        private void btnModificar_guardar_Click(object sender, RoutedEventArgs e)
        {



          





            this.textNombre.IsEnabled = false;
            textApellido1.IsEnabled = false;
            textApellido2.IsEnabled = false;
            textCargo.IsEnabled = false;

            MessageBox.Show("Guardado", "Editar información usuario", MessageBoxButton.OK, MessageBoxImage.Information);

            this.btnModificar_guardar.Visibility = Visibility.Hidden;
            this.btnModificar.Visibility = Visibility.Visible;
        }


        private void Modificar_Click(object sender, RoutedEventArgs e)
        {
            this.textNombre.IsEnabled = true;
            textApellido1.IsEnabled = true;
            textApellido2.IsEnabled = true;
            textCargo.IsEnabled = true;

            this.btnModificar.Visibility = Visibility.Hidden;
            btnModificar_guardar.Visibility = Visibility.Visible;
        }
    }
}
