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
using Adquisoft.producto_sw;



namespace Adquisoft.Modulos.Registro_sw
{
    /// <summary>
    /// Lógica de interacción para Registros_sw.xaml
    /// </summary>
    public partial class Registros_sw : MetroWindow
    {

        ConsultaRegistroSoftwareBD perfilSw = new ConsultaRegistroSoftwareBD();


        public Registros_sw()
        {
            InitializeComponent();

             
        string primer_registro = perfilSw.PrimerRegistroProductoSw();


            ConsultaPerfilSoftware(primer_registro);
        }


        private void ConsultaPerfilSoftware(string id_registro)
        {

            try
            {
                
                perfilSw.LeerRegistroSwBD(id_registro);

                //información general del producto de sw
                this.text_id.Text = perfilSw.Id;
                this.textNombreProducto.Text = perfilSw.Nombre_producto;
                this.textVersion.Text = perfilSw.Version;
                this.TextDesarrollador.Text = perfilSw.Desarrollador;
                this.TextLicencia.Text = perfilSw.Licencia;
                this.textManualUsuario.Text = perfilSw.Manual_usuario;

                this.textCategoria.Text = perfilSw.Categoria;
                this.textSubcategoria.Text = perfilSw.Subcategoria;
                this.textDescripcion.Text = perfilSw.Descripcion;

                //requerimientos min de sistema
                this.textSistemaOperativo.Text = perfilSw.Sistema_operativo;
                this.textProcesador.Text = perfilSw.Procesador;
                this.textAlmacenamiento.Text = perfilSw.Rom;
                this.textRAM.Text = perfilSw.Ram;
                this.textTarjetaGrafica.Text = perfilSw.Tarjeta_grafica;
                this.textHwSwAdd.Text = perfilSw.Hw_sw_add;

                //costos
                this.text_c_adquisicion.Text = perfilSw.C_adquisicion;
                this.textCostoSuscripcion.Text = perfilSw.C_suscripcion;
                this.textPeriodoPago.Text = perfilSw.Periodo_pago;
                this.text_c_capacitacion.Text = perfilSw.C_capacitacion;
                this.text_c_hwswadd.Text = perfilSw.C_hwSwAdd;

                this.textCostoTotal.Text = perfilSw.CostoTotal().ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar el perfil de software desde la BD", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
            



        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            string siguiente_registro = perfilSw.SiguienteRegistroProductoSw(perfilSw.Id);

            ConsultaPerfilSoftware(siguiente_registro);
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            string anterior_registro = perfilSw.AnteriorRegistroProductoSw(perfilSw.Id);

            ConsultaPerfilSoftware(anterior_registro);
        }

        private void btn_nuevoRegistro_Click(object sender, RoutedEventArgs e)
        {
            RegistrarNuevoSoftware nuevoRegistro = new RegistrarNuevoSoftware();
            nuevoRegistro.ShowDialog();
            
        }

        private void btn_EditarRegistro_Click(object sender, RoutedEventArgs e)
        {
            Software actualizaSw = new Software();

            //información general registro sw
            actualizaSw.Id = this.text_id.Text;
            actualizaSw.Nombre_producto = this.textNombreProducto.Text;
            actualizaSw.Version = this.textVersion.Text;
            actualizaSw.Licencia = this.TextLicencia.Text;
            actualizaSw.Manual_usuario = this.textManualUsuario.Text;
            actualizaSw.Desarrollador = this.TextDesarrollador.Text;
            actualizaSw.Categoria = this.textCategoria.Text;
            actualizaSw.Subcategoria = this.textSubcategoria.Text;
            actualizaSw.Descripcion = this.textDescripcion.Text;
            //requerimientos minimos de sistema
            actualizaSw.Sistema_operativo = this.textSistemaOperativo.Text;
            actualizaSw.Procesador = this.textProcesador.Text;
            actualizaSw.Rom = this.textAlmacenamiento.Text;
            actualizaSw.Ram = this.textRAM.Text;
            actualizaSw.Hw_sw_add = this.textHwSwAdd.Text;
            actualizaSw.Tarjeta_grafica = this.textTarjetaGrafica.Text;
            //costos
            actualizaSw.C_adquisicion = this.text_c_adquisicion.Text;
            actualizaSw.C_suscripcion = this.textCostoSuscripcion.Text;
            actualizaSw.Periodo_pago = this.textPeriodoPago.Text;
            actualizaSw.C_capacitacion = this.text_c_capacitacion.Text;
            actualizaSw.C_hwSwAdd = this.text_c_hwswadd.Text;

            RegistrarNuevoSoftware editarRegistroSw = new RegistrarNuevoSoftware(actualizaSw);
            editarRegistroSw.ShowDialog();
        }
    }
}
