using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Adquisoft.Modulos.Evaluacion_Calidad
{
    /// <summary>
    /// Interaction logic for EvaluacionCalidad.xaml
    /// </summary>
    public partial class EvaluacionCalidad : Window
    {
        public EvaluacionCalidad()
        {
            InitializeComponent();
            actualizarListaCategorias();
        }

        private bool actualizarListaSubCategorias(string id_categoria)
        {

            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            try
            {
                String patentesTercerosSQL = "select * from subcategoria where id_categoria = " + id_categoria +" order by id";
                NpgsqlCommand comandoBuscaPatentesTercerosSQL = new NpgsqlCommand(patentesTercerosSQL, conexion);

                NpgsqlDataReader drCaracteristica = comandoBuscaPatentesTercerosSQL.ExecuteReader();
                while (drCaracteristica.Read())
                {
                    String id = drCaracteristica["id"].ToString();
                    String nombre = drCaracteristica["nombre"].ToString();

                    // String valor = drCaracteristica["valor"].ToString();
                    comboBoxSubCategoria.Items.Add(id + "-" + nombre);
                }
                 conexion.Close();
            }
            catch
            {
                MessageBox.Show("Error en consultar la categoria");
            }
            return true;      
        }



        private bool actualizarListaCategorias()
        {

            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            try
            {
                String patentesTercerosSQL = "select * from categoria order by id_categoria";
                NpgsqlCommand comandoBuscaPatentesTercerosSQL = new NpgsqlCommand(patentesTercerosSQL, conexion);

                NpgsqlDataReader drCaracteristica = comandoBuscaPatentesTercerosSQL.ExecuteReader();
                while (drCaracteristica.Read())
                {
                    String id = drCaracteristica["id_categoria"].ToString();
                    String nombre = drCaracteristica["nombre"].ToString();

                    // String valor = drCaracteristica["valor"].ToString();
                    comboBoxCategoria.Items.Add(id + "-" + nombre);
                }
                conexion.Close();
            }
            catch
            {
                MessageBox.Show("Error en consultar la categoria");
            }
            return true;
        }

        private void buttonCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxCategoria.SelectedIndex > -1)
            { 
            
                String[] id_categoria_selecionada = comboBoxCategoria.SelectedItem.ToString().Split('-');
                // MessageBox.Show(id_categoria_selecionada[0]);
                comboBoxSubCategoria.Items.Clear();
                comboBoxSubCategoria.SelectedIndex = 0;
                actualizarListaSubCategorias(id_categoria_selecionada[0]);
            }
            

        }

        private bool actualizarTablaSoftwaresRegistrados (string id_subcategoria)
        {

            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
                conexion.Open();
                String SQL = "SELECT * FROM software WHERE id_subcategoria = " + id_subcategoria + ";";

                DataTable dtColumnas = new DataTable();
                dtColumnas.Columns.Add("id", typeof(string));
                dtColumnas.Columns.Add("nombre_producto", typeof(string));
                dtColumnas.Columns.Add("version", typeof(string));
                dtColumnas.Columns.Add("desarrollador", typeof(string));
                dtColumnas.Columns.Add("id_licencia", typeof(string));
                dtColumnas.Columns.Add("descripcion", typeof(string));
                dtColumnas.Columns.Add("manual_usuario", typeof(string));
                dtColumnas.Columns.Add("id_subcategoria", typeof(string));

                dataGridSoftwaresRegistrados.ItemsSource = dtColumnas.DefaultView;

              
                Console.WriteLine(SQL);
                NpgsqlCommand comandoBuscaConceptos = new NpgsqlCommand(SQL, conexion);
                NpgsqlDataReader drFletes = comandoBuscaConceptos.ExecuteReader();
                while (drFletes.Read())
                {
                    String id = drFletes["id"].ToString();
                    String nombre_producto = drFletes["nombre_producto"].ToString();
                    String version = drFletes["version"].ToString();
                    String desarrollador = drFletes["desarrollador"].ToString();
                    String id_licencia = drFletes["id_licencia"].ToString();
                    String descripcion = drFletes["descripcion"].ToString();
                    String manual_usuario = drFletes["manual_usuario"].ToString();
                    String id_subcategoria_ = drFletes["id_subcategoria"].ToString();


                    dtColumnas.Rows.Add(new object[] { id, nombre_producto, version, desarrollador, id_licencia, descripcion, manual_usuario, id_subcategoria_ });
                    
                }
                conexion.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show("Mal");
                return false;
            }
            return true;
        }

  
        private void buttonSubCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxCategoria.SelectedIndex > -1)
            {
            
                String[] id_subcategoria_selecionada = comboBoxSubCategoria.SelectedItem.ToString().Split('-');
                actualizarTablaSoftwaresRegistrados(id_subcategoria_selecionada[0]);
            }
        }

        private void dataGridSoftwaresRegistrados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridSoftwaresRegistrados.Items.Count != 0)
            {
                DataRowView filaSeleccionada = dataGridSoftwaresRegistrados.SelectedItem as DataRowView;
                if (filaSeleccionada != null)
                {
                    // sacar id 
                    String id_software = filaSeleccionada.Row[0].ToString(); // indice
                    String id_subcategoria = filaSeleccionada.Row[7].ToString(); // sub categoria
                    //MessageBox.Show(id_sub_categoria);

                    NuevaEvaluacion nuevaEvaluacion = new NuevaEvaluacion(id_software, id_subcategoria);
                    nuevaEvaluacion.ShowDialog();
                    //nuevaEvaluacion.Visibility = Visibility.Visible;


                }
            }
        }
    }
}
