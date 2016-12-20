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
using Adquisoft.Modulos.Configuracion.Categorias.Control_Categorias;
using System.Data;
using Adquisoft.Modulos.Configuracion.Categorias.Control_Caracteristicas;

namespace Adquisoft.Modulos.Configuracion.Control_Categorias
{
    /// <summary>
    /// Lógica de interacción para NuevaSubCategoria.xaml
    /// </summary>
    public partial class NuevaSubCategoria : MetroWindow
    {

        private bool nuevasubcategoria;   // indica si es un nuevo registro

        private string IdSubcategoriaRegistrar; //indica la id de la subcategoria que se registrará o se actualizará

        public NuevaSubCategoria()
        {
            InitializeComponent();

            nuevasubcategoria = true;
            CargarCategorias();
            this.IdSubcategoriaRegistrar = ConsultaSiguienteIdSubcategoriaRegistrar();
            CargaDataGridSeleccionCaracteristicas();
        }


        /// <summary>
        /// Constructor para editar un registro existente
        /// </summary>
        /// <param name="id_subcategoria"></param>
        public NuevaSubCategoria(string  id_subcategoria)
        {
            InitializeComponent();

            nuevasubcategoria = false;
            CargarCategorias();
            CargaDatosSubcategoriaEditar(id_subcategoria);         
            
            this.IdSubcategoriaRegistrar = id_subcategoria;
            CargaDataGridSeleccionCaracteristicas();

        }


        private void CargaDatosSubcategoriaEditar(string id_subcategoria)
        {
            //carga información de la subcategoria a editar
            ConsultaSubcategoriaBD datos_subcategoria = new ConsultaSubcategoriaBD(id_subcategoria);
            this.IdSubcategoriaRegistrar = datos_subcategoria.Id_subcategoria;
            textNombreSubcategoria.Text = datos_subcategoria.Nombre_subcategoria;
            ConsultaCategoriaBD datos_categoria = new ConsultaCategoriaBD(datos_subcategoria.Id_categoria);
            this.cbCategoria.SelectedItem = datos_categoria.Nombre_categoria;
            this.textDescripcionSubcategoria.Text = datos_subcategoria.Descripcion_subcategoria;
            //caracteristicas
            //subcaracteristicas
            //incidencias subcaracteristicas
            //incidencias caracteristica
        }


               
        /// <summary>
        /// carga lista de categorias en el cb
        /// </summary>
        private void CargarCategorias()
        {

            //conecta BD
            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            // carga combox categoria
            string consultaCategorias = "select * from categoria order by id_categoria";
            NpgsqlCommand comandoCategorias = new NpgsqlCommand(consultaCategorias, conexionBD);
            NpgsqlDataReader drCategorias = comandoCategorias.ExecuteReader();


            while (drCategorias.Read())
            {

                //String id = drCategorias["id_categoria"].ToString();
                String nombre = drCategorias["nombre"].ToString();


                this.cbCategoria.Items.Add(nombre);  //agrega los nombres de las categorias a el cb
            }

            conexionBD.Close();

        }


        public bool CargaDataGridSeleccionCaracteristicas()
        {

            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();
            try
            {
                
                DataTable dtColumnas = new DataTable();
                //dtColumnas.Columns.Add("id", typeof(string));
                dtColumnas.Columns.Add("Seleccionar", typeof(bool));
                dtColumnas.Columns.Add("Caracteristica", typeof(string));
                dtColumnas.Columns.Add("id", typeof(string));



                this.dgSeleccionCaracteristicas.ItemsSource = dtColumnas.DefaultView;

                String SQL = "select nombre, id from caracteristica;";
                Console.WriteLine(SQL);
                NpgsqlCommand comandoBuscaCaracteristicas = new NpgsqlCommand(SQL, conexion);
                NpgsqlDataReader drCaracteristicas = comandoBuscaCaracteristicas.ExecuteReader();
                while (drCaracteristicas.Read())
                {
                    String Caracteristica = drCaracteristicas["nombre"].ToString();
                    String id = drCaracteristicas["id"].ToString();

                    dtColumnas.Rows.Add(new object[] { false, Caracteristica, id });
                }
            }
               
        
            catch (Exception msg)
            {
                MessageBox.Show("Mal");
                return false;
            }

            conexion.Close();
            return true;

        }



        public void CargaDataGridIncidenciaSubcaracteristicas(LinkedList<string> listaSubCaracteristicas)
        {

            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            DataTable dtColumnas = new DataTable();

            //dtColumnas.Columns.Add("Seleccionar", typeof(bool));
            dtColumnas.Columns.Add("incidencia", typeof(string));
            dtColumnas.Columns.Add("Sub-Caracteristica", typeof(string));
            dtColumnas.Columns.Add("id", typeof(string));
            this.dgIncidenciasSubcaracteristicas.ItemsSource = dtColumnas.DefaultView;

            for (int i = 0; i < listaSubCaracteristicas.Count; i++)
            {

                try
                {

                    String SQL = "select nombre, id from subcaracteristica where id = " + listaSubCaracteristicas.ElementAt(i) + ";";
                    //MessageBox.Show(SQL);
                    Console.WriteLine(SQL);
                    NpgsqlCommand comandoBuscaCaracteristicas = new NpgsqlCommand(SQL, conexion);
                    NpgsqlDataReader drCaracteristicas = comandoBuscaCaracteristicas.ExecuteReader();
                    while (drCaracteristicas.Read())
                    {
                        String Caracteristica = drCaracteristicas["nombre"].ToString();
                        String id = drCaracteristicas["id"].ToString();

                        dtColumnas.Rows.Add(new object[] { "1", Caracteristica,id });
                    }
                }


                catch (Exception msg)
                {
                    MessageBox.Show("Mal");

                }
            }

            }


        public void CargaDataGridIncidenciaCaracteristicas(LinkedList<string> listaCaracteristicas)
        {

            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            DataTable dtColumnas = new DataTable();

            //dtColumnas.Columns.Add("Seleccionar", typeof(bool));
            dtColumnas.Columns.Add("incidencia", typeof(string));
            dtColumnas.Columns.Add("Caracteristica", typeof(string));
            dtColumnas.Columns.Add("id", typeof(string));
            this.dgIncidenciasCaracteristicas.ItemsSource = dtColumnas.DefaultView;

            for (int i = 0; i < listaCaracteristicas.Count; i++)
            {

                try
                {

                    String SQL = "select nombre, id from caracteristica where id = " + listaCaracteristicas.ElementAt(i) + ";";
                    //MessageBox.Show(SQL);
                    Console.WriteLine(SQL);
                    NpgsqlCommand comandoBuscaCaracteristicas = new NpgsqlCommand(SQL, conexion);
                    NpgsqlDataReader drCaracteristicas = comandoBuscaCaracteristicas.ExecuteReader();
                    while (drCaracteristicas.Read())
                    {
                        String Caracteristica = drCaracteristicas["nombre"].ToString();
                        String id = drCaracteristicas["id"].ToString();

                        dtColumnas.Rows.Add(new object[] { "1", Caracteristica , id});
                    }
                }


                catch (Exception msg)
                {
                    MessageBox.Show("Mal");

                }
            }

            conexion.Close();



        }


        private void CargaDataGridSeleccionMetricas(LinkedList<string> listaSubcaracteristicas)
        {

            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            DataTable dtColumnas = new DataTable();

            dtColumnas.Columns.Add("Seleccione metrica", typeof(bool));
            dtColumnas.Columns.Add("id", typeof(string));
            dtColumnas.Columns.Add("nombre", typeof(string));
            dtColumnas.Columns.Add("subcaracteristica", typeof(string));
                        
            this.dgSeleccionMetricas.ItemsSource = dtColumnas.DefaultView;

            for (int i = 0; i < listaSubcaracteristicas.Count; i++)
            {

                try
                {

                    String SQL = "select id, nombre  from metrica where  id_subcaracteristica =  '" + listaSubcaracteristicas.ElementAt(i) + "';";
                    //MessageBox.Show(SQL);
                    Console.WriteLine(SQL);
                    NpgsqlCommand comandoBuscaMetricas = new NpgsqlCommand(SQL, conexion);
                    NpgsqlDataReader drMetricas = comandoBuscaMetricas.ExecuteReader();
                    while (drMetricas.Read())
                    {
                        String id = drMetricas["id"].ToString();
                        String nombre = drMetricas["nombre"].ToString();


                       

                        ConsultaSubcaracteristicaBD c = new ConsultaSubcaracteristicaBD(listaSubcaracteristicas.ElementAt(i));

                       

                        dtColumnas.Rows.Add(new object[] {false,id, nombre,c.Nombre_subcaracteristica });
                    }
                }


               catch (Exception msg)
                {
                    MessageBox.Show("Mal");

                }
            }

            conexion.Close();

        }








        private string ConsultaSiguienteIdSubcategoriaRegistrar()
        {
            string proximoIdSubcategoria = string.Empty;
            try
            {
               
                //conecta BD
                NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
                conexionBD.Open();

                if (nuevasubcategoria)
                {

                    //carga id para el nuevo registro
                    string ConsultaIDproductoRegistrar = "select last_value + 1 from s_subcategoria";

                    NpgsqlCommand comandoIdSw = new NpgsqlCommand(ConsultaIDproductoRegistrar, conexionBD);
                    NpgsqlDataReader drIdSw = comandoIdSw.ExecuteReader();

                    while (drIdSw.Read())
                    {
                        proximoIdSubcategoria = drIdSw[0].ToString();

                    }

                }

                conexionBD.Close();

                
            }
            catch (Exception)
            {

                throw;
            }


            return proximoIdSubcategoria;
        }




        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            //muestra formulario siguiente
            if (ValidarInformacionSubcategoria())
            {
                this.tabControlRegistroSubcategoria.SelectedIndex++;
            }
           
        }

        private void btnsiguiente_s_c_Click(object sender, RoutedEventArgs e)
        {
            

            LinkedList<string> listaClickeadosCaracteristica = obtenerListaClickeadosCaracteristicas();
            if(listaClickeadosCaracteristica.Count > 0)
            {
                obtenerSubCaracteristicas(listaClickeadosCaracteristica);
            }



            //muestra formulario siguiente
            this.tabControlRegistroSubcategoria.SelectedIndex++;
        }

        private void obtenerSubCaracteristicas (LinkedList <string> listaCaracteristicas)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();            

            DataTable dtColumnas = new DataTable();
            //dtColumnas.Columns.Add("id", typeof(string));
            dtColumnas.Columns.Add("Seleccionar", typeof(bool));
            dtColumnas.Columns.Add("Sub-Caracteristica", typeof(string));
            dtColumnas.Columns.Add("id", typeof(string));
            this.dgSeleccionSubcaracteristicas.ItemsSource = dtColumnas.DefaultView;

            for (int i = 0; i < listaCaracteristicas.Count; i++)
            {

                try
                {                 
                    
                     String SQL = "select nombre, id from subcaracteristica where id_caracteristica = "+listaCaracteristicas.ElementAt(i) +";";
                    //MessageBox.Show(SQL);
                    Console.WriteLine(SQL);
                    NpgsqlCommand comandoBuscaCaracteristicas = new NpgsqlCommand(SQL, conexion);
                    NpgsqlDataReader drCaracteristicas = comandoBuscaCaracteristicas.ExecuteReader();
                    while (drCaracteristicas.Read())
                    {
                        String SubCaracteristica = drCaracteristicas["nombre"].ToString();
                        String id = drCaracteristicas["id"].ToString();

                        dtColumnas.Rows.Add(new object[] { false, SubCaracteristica , id});
                    }
                }


                catch (Exception msg)
                {
                    MessageBox.Show("Mal");

                }
            }

            conexion.Close();
        }

        private LinkedList<string> obtenerListaClickeadosCaracteristicas()
        {
            LinkedList<string> listaClickeadosCaracteristica = new LinkedList<string>();

            if (dgSeleccionCaracteristicas.Items.Count == 0)
            {
                MessageBox.Show("Tabla vacia");
            }

            if (dgSeleccionCaracteristicas.Items.Count > 0)
            {
                foreach (System.Data.DataRowView dr in dgSeleccionCaracteristicas.ItemsSource)
                {
                    if (dr[0].Equals(true) == true)
                    {
                        listaClickeadosCaracteristica.AddLast(dr[2].ToString());
                    }
                }
            }
            return listaClickeadosCaracteristica;
        }


        private LinkedList<string> ObtenerListaClickeadosSubcaracteristicas()
        {
            LinkedList<string> listaClickeadosSubcaracteristicas = new LinkedList<string>();


            if (dgSeleccionSubcaracteristicas.Items.Count == 0)
            {
                MessageBox.Show("Tabla Vacia");
            }

            if (dgSeleccionSubcaracteristicas.Items.Count > 0)
            {
                foreach (System.Data.DataRowView dr in dgSeleccionSubcaracteristicas.ItemsSource)
                {
                    if (dr[0].Equals(true) == true)
                    {
                        listaClickeadosSubcaracteristicas.AddLast(dr[2].ToString());
                    }
                }

            }

            return listaClickeadosSubcaracteristicas;
        }


        private LinkedList<IncidenciaCaracteristica> ObtenerListaValoresIncidenciaCaracteristicas()
        {

            LinkedList<IncidenciaCaracteristica> listaIncidenciasCaracteristica = new LinkedList<IncidenciaCaracteristica>();


            if (dgIncidenciasCaracteristicas.Items.Count == 0)
            {
                MessageBox.Show("Tabla Vacia");
            }

            if (dgIncidenciasCaracteristicas.Items.Count > 0)
            {
                foreach (System.Data.DataRowView dr in dgIncidenciasCaracteristicas.ItemsSource)
                {

                    IncidenciaCaracteristica incidencias_c = new IncidenciaCaracteristica();

                    incidencias_c.Id_caracteristica = dr[2].ToString();
                    incidencias_c.Valor_incidencia = dr[0].ToString();


                    listaIncidenciasCaracteristica.AddLast(incidencias_c);                      
                    
                }

            }

            return listaIncidenciasCaracteristica;

        }



        private LinkedList<IncidenciaSubcaracteristica> ObtenerListaValoresIncidenciaSubCaracteristicas()
        {

            LinkedList<IncidenciaSubcaracteristica> listaIncidenciasSubCaracteristica = new LinkedList<IncidenciaSubcaracteristica>();


            if (dgIncidenciasSubcaracteristicas.Items.Count == 0)
            {
                MessageBox.Show("Tabla Vacia");
            }

            if (dgIncidenciasSubcaracteristicas.Items.Count > 0)
            {
                foreach (System.Data.DataRowView dr in dgIncidenciasSubcaracteristicas.ItemsSource)
                {

                    IncidenciaSubcaracteristica incidencias_sc = new IncidenciaSubcaracteristica();

                    incidencias_sc.Id_subcaracteristica = dr[2].ToString();
                    incidencias_sc.Valor_incidencia = dr[0].ToString();                   
                    listaIncidenciasSubCaracteristica.AddLast(incidencias_sc);                    

                }

            }

            return listaIncidenciasSubCaracteristica;

        }




        private  LinkedList<string> ObtnerListaMetricasSeleccionadas()
        {

            LinkedList<string> listaClickeadosMetricas = new LinkedList<string>();


            if (dgSeleccionMetricas.Items.Count == 0)
            {
                MessageBox.Show("Tabla Vacia");
            }

            if (dgSeleccionMetricas.Items.Count > 0)
            {
                foreach (System.Data.DataRowView dr in dgSeleccionMetricas.ItemsSource)
                {
                    if (dr[0].Equals(true) == true)
                    {
                        listaClickeadosMetricas.AddLast(dr[1].ToString());
                    }
                }

            }

            return listaClickeadosMetricas;

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

        private bool ValidarInformacionSubcategoria()
        {
            bool valida = false;
            int indiceNoSeleccionado = -1;

            if ((cbCategoria.SelectedIndex != indiceNoSeleccionado) && (!EsTextoVacio(textNombreSubcategoria.Text))
                && (!EsTextoVacio(textDescripcionSubcategoria.Text)))
            {
                valida = true;

            }
            else
            {
                valida = false;
                MessageBox.Show("Complete el formulario", "Completar...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }


            return valida;
        }
        



        private void btnsiguiente_s_sc_Click(object sender, RoutedEventArgs e)
        {

            LinkedList<string> listaClickeadosSubCaracteristica = ObtenerListaClickeadosSubcaracteristicas();
            if (listaClickeadosSubCaracteristica.Count > 0)
            {
                CargaDataGridIncidenciaSubcaracteristicas(listaClickeadosSubCaracteristica);
            }

            

            //muestra formulario siguiente
            this.tabControlRegistroSubcategoria.SelectedIndex++;
        }

        private void btnsiguiente_incidenciaSubC_Click(object sender, RoutedEventArgs e)
        {
            LinkedList<string> listaClickeadosCaracteristica = obtenerListaClickeadosCaracteristicas();
            if (listaClickeadosCaracteristica.Count > 0)
            {
                CargaDataGridIncidenciaCaracteristicas(listaClickeadosCaracteristica);
            }       


            //muestra formulario siguiente
            this.tabControlRegistroSubcategoria.SelectedIndex++;
        }

        private void btnVolver_sc_Click(object sender, RoutedEventArgs e)
        {
            this.tabControlRegistroSubcategoria.SelectedIndex--;
        }

        private void btnVolver_ssc_Click(object sender, RoutedEventArgs e)
        {
            this.tabControlRegistroSubcategoria.SelectedIndex--;
        }

        private void btnVolver_incidenciaSubcaracteristica_Click(object sender, RoutedEventArgs e)
        {
            this.tabControlRegistroSubcategoria.SelectedIndex--;
        }

        private void btnVolver_incidenciaCaracteristica_Click(object sender, RoutedEventArgs e)
        {
            this.tabControlRegistroSubcategoria.SelectedIndex--;
        }


        /// <summary>
        /// Registra la nueva subcategoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {

            ConsultaCategoriaBD consultaNombreCat = new ConsultaCategoriaBD();

            string idcategoriaseleccionada = consultaNombreCat.LeerIdCategoria(cbCategoria.SelectedItem.ToString());


            
            //Registra Subcategoria 
            RegistraSubcategoria r_Subcategoria = new RegistraSubcategoria(this.IdSubcategoriaRegistrar, textNombreSubcategoria.Text, idcategoriaseleccionada, textDescripcionSubcategoria.Text, this.nuevasubcategoria);

            if (r_Subcategoria.RegistraSubcategoriaBD() && RegistrarIncidenciasBD() && RegistrarMetricasUtilizar())
            {
               

              await this.ShowMessageAsync("Registro", "Registro completado con exito", MessageDialogStyle.Affirmative, null);

                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo registrar!");
            }       

            
        }


        private bool RegistrarMetricasUtilizar()
        {
            try
            {
                LinkedList<string> listaMetricasSeleccionadas = ObtnerListaMetricasSeleccionadas();


                //conecta BD
                NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
                conexionBD.Open();

                for (int i = 0; i < listaMetricasSeleccionadas.Count; i++)
                {

                    string id_metrica = listaMetricasSeleccionadas.ElementAt(i);
                    string Consulta = "INSERT INTO metricas_utilizar (id, id_subcategoria, id_metrica) VALUES ((select nextval('s_metrica_utilizar')),'" + this.IdSubcategoriaRegistrar + "','" + id_metrica + "'); ";


                    NpgsqlCommand comandoMetricasUtilizar = new NpgsqlCommand(Consulta, conexionBD);
                    comandoMetricasUtilizar.ExecuteNonQuery();



                }
                conexionBD.Close();
                return true;
               
            }
           
            catch (Exception)
            {
                return false;
                throw;
            }
        }


        private bool RegistrarIncidenciasBD()
        {

            bool incidenciasCaracteristicasRegistrado = false;
            bool incidenciasSubcaracteristicasRegistrado = false;
            //registra los valores de incidencia subcaracteristicas:



            LinkedList<IncidenciaSubcaracteristica> listaIncidenciasingresadasSubCaracteristicas = ObtenerListaValoresIncidenciaSubCaracteristicas();


            for (int i = 0; i < listaIncidenciasingresadasSubCaracteristicas.Count; i++)
            {

                

                    IncidenciaSubcaracteristica r = listaIncidenciasingresadasSubCaracteristicas.ElementAt(i);

                    string r_id_subcaracteristica = listaIncidenciasingresadasSubCaracteristicas.ElementAt(i).Id_subcaracteristica;
                    string r_valor_incidencia = listaIncidenciasingresadasSubCaracteristicas.ElementAt(i).Valor_incidencia;

               
                    RegistraIncidenciaSubCaracteristica r_incidenciaSubCaracteristica = new RegistraIncidenciaSubCaracteristica(this.IdSubcategoriaRegistrar, r.Id_subcaracteristica, r.Valor_incidencia, this.nuevasubcategoria);

                    if (r_incidenciaSubCaracteristica.RegistrarIncidenciaSubcaracteristicaBD())
                    {
                        incidenciasSubcaracteristicasRegistrado = true;
                    }
               
                    
               
            }


            // RegistraIncidenciaSubCaracteristica r_incidenciaSubCaracteristica = new RegistraIncidenciaSubCaracteristica();

            LinkedList<IncidenciaCaracteristica> listaIncidenciasingresadasCaracteristicas = ObtenerListaValoresIncidenciaCaracteristicas();


            for (int i = 0; i < listaIncidenciasingresadasCaracteristicas.Count; i++)
            {


                    IncidenciaCaracteristica rc = listaIncidenciasingresadasCaracteristicas.ElementAt(i);

                    RegistraIncidenciaCaracteristica r_incidenciaCaracteristica = new RegistraIncidenciaCaracteristica(this.IdSubcategoriaRegistrar, rc.Id_caracteristica, rc.Valor_incidencia, this.nuevasubcategoria);

                    if (r_incidenciaCaracteristica.RegistraIncidenciaCaracteristicaBD())
                    {
                        incidenciasCaracteristicasRegistrado = true;                       
                    }
                
            }


            if (incidenciasCaracteristicasRegistrado && incidenciasSubcaracteristicasRegistrado)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void btnSiguienteIncidenciaCaracteristicas_Click(object sender, RoutedEventArgs e)
        {

            //carga siguiente formulario:  selección de metricas

            LinkedList<string> listaClickeadosSubCaracteristica = ObtenerListaClickeadosSubcaracteristicas();  // lista de subcaracteristicas seleccionadas

            if (listaClickeadosSubCaracteristica.Count > 0)
            {
                CargaDataGridSeleccionMetricas(listaClickeadosSubCaracteristica);
            }


            

          


            //muestra formulario siguiente
            this.tabControlRegistroSubcategoria.SelectedIndex++;

        }

       
    } 


}
