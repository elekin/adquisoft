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
using System.Data;
using Adquisoft.Modulos.Configuracion.Categorias.Control_Categorias;
using Adquisoft.Modulos.Configuracion.Control_Categorias;

namespace Adquisoft.Modulos.Configuracion
{
    /// <summary>
    /// Lógica de interacción para ConfiguracionCategorias.xaml
    /// </summary>
    public partial class ConfiguracionCategorias : MetroWindow
    {

        


        public ConfiguracionCategorias()
        {
           
            InitializeComponent();
            CargarCategorias();
            



        }

        //carga lista de categorias en el cb
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


                this.cbCategorias.Items.Add(nombre);  //agrega los nombres de las categorias a el cb
            }

            conexionBD.Close();

        }

        
        private bool CargarSubcategorias(string idCategoria)
        {

            DataSet ds = new DataSet();
            DataTable dtMetrica = new DataTable();
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
                conexion.Open();
                String query = "SELECT* FROM subcategoria where id_categoria = " + idCategoria;
                Console.WriteLine(query);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conexion);
                ds.Reset();
                da.Fill(ds);
                dtMetrica = ds.Tables[0];
                this.dg_SubCategorias.ItemsSource = dtMetrica.DefaultView;
                conexion.Close();

                dg_SubCategorias.Columns[2].Visibility = Visibility.Collapsed;
            }
            catch (Exception msg)
            {
                return false;
            }
            return true;

        }
        
        private void btnAplicar_Click(object sender, RoutedEventArgs e)
        {

            //String[] id_categoria_selecionada = cbCategorias.SelectedItem.ToString().Split('-');


            ConsultaCategoriaBD consulta_idcategoria = new ConsultaCategoriaBD();

            string id_categoria_seleccionada = consulta_idcategoria.LeerIdCategoria(cbCategorias.SelectedItem.ToString());


            CargarSubcategorias(id_categoria_seleccionada);
        }

        //Elimina la subcategoría seleccionada
        private void btnEliminarSubcategoria_Click(object sender, RoutedEventArgs e)
        {
            

            
        }
        //edita la subcategoria seleccionada
        private void btnEditarSubcategoria_Click(object sender, RoutedEventArgs e)
        {
            NuevaSubCategoria editar_subcategoria = new NuevaSubCategoria("25");  // parametro:id de la subcategoria a editar
            editar_subcategoria.ShowDialog();
            
        }
        //agrega una nueva subcategoria
        private void btnAgregarSubcategoria_Click(object sender, RoutedEventArgs e)
        {
            

            Control_Categorias.NuevaSubCategoria nuevoRegistroSubcategoria = new Control_Categorias.NuevaSubCategoria();

            nuevoRegistroSubcategoria.ShowDialog();
        }

        
    }
}
