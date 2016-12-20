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
using Npgsql;
using Adquisoft.Constantes;
using Adquisoft.producto_sw;

namespace Adquisoft.Modulos.Registro_sw
{
    /// <summary>
    /// Lógica de interacción para RegistroSoftware.xaml
    /// </summary>
    public partial class RegistrarNuevoSoftware : MetroWindow
    {
        

        private string id_sw_aregistrar;
        private bool nuevoRegistro;  //indica si es un nuevo registro o una actualización de un registro existente
       


        /// <summary>
        /// Constructor para un nuevo registro de sw
        /// </summary>
        public RegistrarNuevoSoftware()
        {
            InitializeComponent();
            nuevoRegistro = true;
            CargaConfiguracion();

        }

        /// <summary>
        /// Constructor para la actualización de un registro existente
        /// </summary>
        /// <param name="registro_actualizar"></param>
        public RegistrarNuevoSoftware(Software registro_actualizar)
        {
            InitializeComponent();


            this.id_sw_aregistrar = registro_actualizar.Id;
            this.nuevoRegistro = false;

            CargaConfiguracion();


            //carga información del registro en el formulario
            this.text_nombreProducto.Text = registro_actualizar.Nombre_producto;
            this.text_version.Text = registro_actualizar.Version;
            this.text_desarrollador.Text = registro_actualizar.Desarrollador;
            this.cb_licencia.SelectedItem = registro_actualizar.Licencia;
            this.cb_manual_usuario.SelectedItem = registro_actualizar.Manual_usuario;
            this.cb_categoria.SelectedItem = registro_actualizar.Categoria;
            this.cb_subcategoria.SelectedItem = registro_actualizar.Subcategoria;
            this.text_descripcion.Text = registro_actualizar.Descripcion;
            //requerimientos min
            this.cb_sistema_operativo.SelectedItem = registro_actualizar.Sistema_operativo;
            this.text_precesasor.Text = registro_actualizar.Procesador;
            this.text_rom_min.Text = registro_actualizar.Rom;
            this.text_ram_min.Text = registro_actualizar.Ram;
            this.text_tarjeta_grafica.Text = registro_actualizar.Tarjeta_grafica;
            this.cb_hw_sw_adicional.SelectedItem = registro_actualizar.Hw_sw_add;
            //costos
            this.text_adquisicion.Text = registro_actualizar.C_adquisicion;
            this.text_suscripcion.Text = registro_actualizar.C_suscripcion;
            this.cb_periodo_pago.SelectedItem = registro_actualizar.Periodo_pago;
            this.text_capacitacion.Text = registro_actualizar.C_capacitacion;
            this.text_costo_hw_sw_add.Text = registro_actualizar.C_hwSwAdd;

        }


        /// <summary>
        /// Carga la configuraciones iniciales y conexión a la BD de los campos necesarios
        /// </summary>
        private void  CargaConfiguracion()
        {
            ConsultasInicialesBD();


            //cb hw sw adicional

            this.cb_hw_sw_adicional.Items.Add("Requiere");
            this.cb_hw_sw_adicional.Items.Add("No Requiere");


            //cb manual usuario
            this.cb_manual_usuario.Items.Add("Si");
            this.cb_manual_usuario.Items.Add("No");

        }
        
        /// <summary>
        /// Carga datos iniciales de la BD para mostrarlos en el formulario
        /// </summary>
        private void ConsultasInicialesBD()
        {

            try
            {

                //conecta BD
                NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
                conexionBD.Open();

                if (nuevoRegistro)
                {

                    //carga id para el nuevo registro
                    string ConsultaIDproductoRegistrar = "select last_value + 1 from s_software";

                    NpgsqlCommand comandoIdSw = new NpgsqlCommand(ConsultaIDproductoRegistrar, conexionBD);
                    NpgsqlDataReader drIdSw = comandoIdSw.ExecuteReader();

                    while (drIdSw.Read())
                    {
                        this.id_sw_aregistrar = drIdSw[0].ToString();

                        this.text_id.Text = id_sw_aregistrar;
                        this.text_id.IsEnabled = false;

                    }

                }
                else // es una actualizacion de un registro existente
                {                   

                    this.text_id.Text = id_sw_aregistrar;
                    this.text_id.IsEnabled = false;
                }


                



                // carga combox licencia
                string tipoLicencia = "select tipo from licencia";
                NpgsqlCommand comandoLicencia = new NpgsqlCommand(tipoLicencia, conexionBD);
                NpgsqlDataReader drLicencia = comandoLicencia.ExecuteReader();


                while (drLicencia.Read())
                {
                    
                    String licencia = drLicencia["tipo"].ToString();
                    //string descripcion = drLicencia["descripcion"].ToString();

                    this.cb_licencia.Items.Add(licencia);                                  

                   

                }


                // carga combox categoria

                string tipocategoria = "select nombre from categoria";
                NpgsqlCommand comandotipocategoria = new NpgsqlCommand(tipocategoria, conexionBD);
                NpgsqlDataReader drTipocategoria = comandotipocategoria.ExecuteReader();

                while (drTipocategoria.Read())
                {
                    
                    String categoria = drTipocategoria["nombre"].ToString();                   

                    this.cb_categoria.Items.Add(categoria);

                }

                //carga cb subcategoria

                string tiposubcategoria = "select nombre from subcategoria";
                NpgsqlCommand comandotiposubcategoria = new NpgsqlCommand(tiposubcategoria, conexionBD);
                NpgsqlDataReader drTiposubcategoria = comandotiposubcategoria.ExecuteReader();

                while (drTiposubcategoria.Read())
                {
                    
                    String subcategoria = drTiposubcategoria["nombre"].ToString();

                    this.cb_subcategoria.Items.Add(subcategoria);
                }


                //carga cb sistema operativo

                string sistemaOperativo = "select nombre from sistema_operativo";
                NpgsqlCommand comandosistemaOperativo = new NpgsqlCommand(sistemaOperativo, conexionBD);
                NpgsqlDataReader drsistemaOperativo = comandosistemaOperativo.ExecuteReader();

                while (drsistemaOperativo.Read())
                {
                    this.cb_sistema_operativo.Items.Add(drsistemaOperativo["nombre"]);
                }


                //carga cb periodo pago suscripción

                string periodopago = "select periodo from periodo_pago";
                NpgsqlCommand comandoperiodopago = new NpgsqlCommand(periodopago, conexionBD);
                NpgsqlDataReader drperiodopago = comandoperiodopago.ExecuteReader();

                while (drperiodopago.Read())
                {
                    this.cb_periodo_pago.Items.Add(drperiodopago["periodo"]);
                }

                conexionBD.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar variables iniciales de la BD", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
                throw;
            }
            
        }


         
        /// <summary>
        /// Suma el total de costos que involucran la adquisicion de un producto de sw.
        /// El costo de suscripción se toma en base al gasto que tendra en 1 año.
        /// </summary>
        /// <returns>Costo total</returns>
        private uint SumaCostos()
        {
            uint costototal;
            Software costos = new Software();

            costos.C_adquisicion = text_adquisicion.Text;
            costos.C_suscripcion = text_suscripcion.Text;
            costos.Periodo_pago = cb_periodo_pago.SelectedItem.ToString();
            costos.C_hwSwAdd = text_costo_hw_sw_add.Text;
            costos.C_capacitacion = text_capacitacion.Text;
            

            costototal = costos.CostoTotal();                                  
                    
            
            
            return costototal;
        }

        
        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {            
            this.Close();
        }




        private bool EsTextoVacio(string texto)
        {
            bool estexto_vacio = false;

            if (string.IsNullOrWhiteSpace(texto))
            {
                estexto_vacio = true;
            }

            return estexto_vacio;
        }


        
              
        /// <summary>
        /// Valida formulario de registro (información general) de un nuevo producto
        /// </summary>
        /// <returns>true si ha sido validado con exito</returns>
        private bool ValidarFormularioInformacionGral()
        {
            bool validacion = false;
            int indiceNoSeleccionado = -1;

            if ((cb_categoria.SelectedIndex != indiceNoSeleccionado) && (cb_subcategoria.SelectedIndex != -1) && (cb_licencia.SelectedIndex != indiceNoSeleccionado) && (cb_manual_usuario.SelectedIndex != indiceNoSeleccionado)
                && (!EsTextoVacio(text_nombreProducto.Text)) && (!EsTextoVacio(text_version.Text)) && (!EsTextoVacio(text_desarrollador.Text)) && (!EsTextoVacio(text_descripcion.Text)))
            {
                validacion = true;
            }

            return validacion;
        }

        private void btn_siguiente_Click(object sender, RoutedEventArgs e)
        {

                       


            if (ValidarFormularioInformacionGral())
            {

                switch (cb_licencia.SelectedValue.ToString())
                {
                    case "gratuita":

                        text_adquisicion.Text = "0";
                        text_suscripcion.Text = "0";
                        text_adquisicion.IsEnabled = false;
                        text_suscripcion.IsEnabled = false;


                        break;
                    case "suscripción":
                        text_adquisicion.Text = "0";
                        text_adquisicion.IsEnabled = false;

                        text_suscripcion.IsEnabled = true;

                        break;
                    case "único pago":
                        text_suscripcion.Text = "0";
                        text_suscripcion.IsEnabled = false;


                        text_adquisicion.IsEnabled = true;
                        break;

                }
                


                //muestra formulario siguiente
                this.Tab_registro_nuevo_sw.SelectedIndex++;

            }
            else
            {
                MessageBox.Show("Complete el formulario de registro antes de continuar","Información General incompleta",MessageBoxButton.OK,MessageBoxImage.Error);
            }


           
        }

        private void btn_volver_requerimientos_Click(object sender, RoutedEventArgs e)
        {
            


            this.Tab_registro_nuevo_sw.SelectedIndex--;
        }


        private bool ValidarFormularioRequerimientosMin()
        {
            bool valida = false;
            int indiceNoSeleccionado = -1;


            if ((cb_hw_sw_adicional.SelectedIndex != indiceNoSeleccionado) && (cb_sistema_operativo.SelectedIndex != indiceNoSeleccionado)
                && (!EsTextoVacio(text_precesasor.Text)) && (!EsTextoVacio(text_rom_min.Text)) && (!EsTextoVacio(text_ram_min.Text) && (!EsTextoVacio(text_tarjeta_grafica.Text))))
            {
                valida = true;
            }


            return valida;
        }

        private void btn_siguiente_requerimientos_Click(object sender, RoutedEventArgs e)
        {


            if (ValidarFormularioRequerimientosMin())
            {
                if (cb_hw_sw_adicional.SelectedItem.ToString() == "No Requiere")
                {
                    this.text_costo_hw_sw_add.IsEnabled = false;
                    this.text_costo_hw_sw_add.Text = "0";
                }
                else if (cb_hw_sw_adicional.SelectedItem.ToString() == "Requiere")
                {
                    this.text_costo_hw_sw_add.IsEnabled = true;
                }

                //selecciona el siguiente formulario del tab
                this.Tab_registro_nuevo_sw.SelectedIndex++;
            }

            else
            {
                MessageBox.Show("Complete el formulario de registro antes de continuar", "Información Requerimientos Minimos incompleta", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
            
        }

        private void btn_volver_costos_Click(object sender, RoutedEventArgs e)
        {
            

            //selecciona el anterior formulario del tab
            this.Tab_registro_nuevo_sw.SelectedIndex--;
        }


        /// <summary>
        /// Valida formulario de costos del registro de un nuevo producto de sw
        /// </summary>
        /// <returns>retorna true si se valida</returns>
        bool ValidarFormularioCostos()
        {
            bool valida = false;
            int indiceNoSeleccionado = -1;

            if ( (cb_periodo_pago.SelectedIndex != indiceNoSeleccionado) && (!EsTextoVacio(text_adquisicion.Text))
                && (!EsTextoVacio(text_suscripcion.Text)) && (!EsTextoVacio(text_capacitacion.Text)) && (!EsTextoVacio(text_costo_hw_sw_add.Text)) )
            {

                if ((EsNumeroEntero(text_adquisicion.Text)) && (EsNumeroEntero(text_suscripcion.Text)) && (EsNumeroEntero(text_capacitacion.Text)) && (EsNumeroEntero(text_costo_hw_sw_add.Text)))
                {
                    this.lbl_costoTotal.Content = SumaCostos();
                    valida = true;
                }
                else
                {
                    MessageBox.Show("Ingrese solo numeros en los campos costos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

                
            }
            else
            {
                MessageBox.Show("Complete el formulario", "Completar...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }


            return valida;
        }


        /// <summary>
        /// registra el producto en la bd
        /// </summary>
        /// <returns>retorna true si se completa el registro</returns>
        private bool RegistrarProductoBD()
        {
            bool registrado = false;

            try
            {
                Software nuevoSw = new Software();               


                //información general:
                nuevoSw.Id = this.id_sw_aregistrar;
                nuevoSw.Nombre_producto = text_nombreProducto.Text;
                nuevoSw.Version= text_version.Text;
                nuevoSw.Desarrollador = text_desarrollador.Text;
                nuevoSw.Licencia = cb_licencia.SelectedItem.ToString();
                nuevoSw.Manual_usuario = cb_manual_usuario.SelectedItem.ToString();
                nuevoSw.Categoria = cb_categoria.SelectedItem.ToString();
                nuevoSw.Subcategoria = cb_subcategoria.SelectedItem.ToString();                            
                nuevoSw.Descripcion = text_descripcion.Text;

                //información requerimientos mínimos de sistema:
                nuevoSw.Sistema_operativo = cb_sistema_operativo.SelectedItem.ToString();
                nuevoSw.Procesador = text_precesasor.Text;
                nuevoSw.Rom = text_rom_min.Text;
                nuevoSw.Ram = text_ram_min.Text;
                nuevoSw.Tarjeta_grafica = text_tarjeta_grafica.Text;
                nuevoSw.Hw_sw_add = cb_hw_sw_adicional.SelectedItem.ToString();

                //información costos
                nuevoSw.C_adquisicion = text_adquisicion.Text;
                nuevoSw.C_suscripcion = text_suscripcion.Text;
                nuevoSw.Periodo_pago = cb_periodo_pago.SelectedItem.ToString();
                nuevoSw.C_capacitacion = text_capacitacion.Text;
                nuevoSw.C_hwSwAdd = text_costo_hw_sw_add.Text;

                //consulta sql

                

                RegistraSoftwareBD registrarNuevoSw = new RegistraSoftwareBD(nuevoSw, nuevoRegistro);



                registrado = true;                    

            }
            catch (Exception)
            {

                MessageBox.Show("Error al registrar el nuevo producto en la base de datos", "Error", MessageBoxButton.OK,MessageBoxImage.Error);

                throw;
            }

            return registrado;
        }

        private async void btn_registrar_sw_Click(object sender, RoutedEventArgs e)
        {
            //registra el nuevo producto de Software


            if (!ValidarFormularioCostos())
            {
                MessageBox.Show("Complete el formulario de registro antes de continuar", "Información Costos incompleta", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (RegistrarProductoBD())
            {
                await this.ShowMessageAsync("Registro", "Registro completado con exito", MessageDialogStyle.Affirmative, null);

                this.Close();

            }
            else
            {
                MessageBox.Show("Error al completar el registro en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }





        }

        private void text_suscripcion_TextChanged(object sender, TextChangedEventArgs e)
        {
            //configuracion periodo de pago

            if (text_suscripcion.Text == "0")
            {
                cb_periodo_pago.IsEnabled = false;
                cb_periodo_pago.SelectedValue = "no tiene";
            }
            else
            {
                cb_periodo_pago.IsEnabled = true;
            }
        }      


        /// <summary>
        /// Comprueba si un texto es un numero entero
        /// </summary>
        /// <param name="Text">texto a evaluar</param>
        /// <returns>true si es un numero</returns>
        private bool EsNumeroEntero(string Text)
        {
            uint output;
            return UInt32.TryParse(Text, out output);
        }

       

        private void btnCalculaCostos_Click(object sender, RoutedEventArgs e)
        {

            ValidarFormularioCostos();

        }
    }
}
