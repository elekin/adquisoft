using Adquisoft.Constantes;
using Adquisoft.Evaluacion_Difusa;
using Adquisoft.producto_sw;
using Evaluate;
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

namespace Adquisoft.Modulos.Evaluacion_Adquisicion
{
    /// <summary>
    /// Interaction logic for EvaluacionComparativa.xaml
    /// </summary>
    public partial class EvaluacionComparativa : Window
    {
        public EvaluacionComparativa()
        {
            InitializeComponent();
            actualizarListaCategorias();
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

        private void buttonSubCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxCategoria.SelectedIndex > -1)
            {

                String[] id_subcategoria_selecionada = comboBoxSubCategoria.SelectedItem.ToString().Split('-');
                actualizarTablaSoftwaresRegistrados(id_subcategoria_selecionada[0]);
            }
        }

        private bool actualizarTablaSoftwaresRegistrados(string id_subcategoria)
        {

            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
                conexion.Open();
                String SQL = "SELECT s.id, s.nombre_producto, s.version, c.costo_total, rc.valor_nivel_calidad, rc.nivel_calidad  FROM COSTO as c INNER JOIN software as s ON c.id_software = s.id INNER JOIN evaluacion_calidad as ec ON ec.id_software = s.id INNER JOIN resultado_evaluacion_calidad as rc ON rc.id_evaluacion_calidad = ec.id  where s.id_subcategoria = "+id_subcategoria+";";

                DataTable dtColumnas = new DataTable();
                
                dtColumnas.Columns.Add("bool", typeof(bool));
                dtColumnas.Columns.Add("id", typeof(string));
                dtColumnas.Columns.Add("nombre_producto", typeof(string));
                dtColumnas.Columns.Add("version", typeof(string));
                dtColumnas.Columns.Add("costo total", typeof(string));
                dtColumnas.Columns.Add("valor calidad", typeof(string));
                dtColumnas.Columns.Add("valor linguistico", typeof(string));

                //dtColumnas.Columns.Add("id", typeof(string));
                //dtColumnas.Columns.Add("nombre_producto", typeof(string));
                //dtColumnas.Columns.Add("version", typeof(string));
                //dtColumnas.Columns.Add("desarrollador", typeof(string));
                //dtColumnas.Columns.Add("id_licencia", typeof(string));
                //dtColumnas.Columns.Add("descripcion", typeof(string));
                //dtColumnas.Columns.Add("manual_usuario", typeof(string));
                //dtColumnas.Columns.Add("id_subcategoria", typeof(string));
                //dtColumnas.Columns.Add("id_subcategoria", typeof(string));

                dataGridSoftwaresRegistrados.ItemsSource = dtColumnas.DefaultView;


                Console.WriteLine(SQL);
                NpgsqlCommand comandoBuscaConceptos = new NpgsqlCommand(SQL, conexion);
                NpgsqlDataReader drFletes = comandoBuscaConceptos.ExecuteReader();
                while (drFletes.Read())
                {
                    String id = drFletes[0].ToString();
                    String nombre_producto = drFletes[1].ToString();
                    String version = drFletes[2].ToString();
                    String costo_total = drFletes[3].ToString();
                    String valor_calidad = drFletes[4].ToString();
                    String valor_lenguistico = drFletes[5].ToString();

                    //String desarrollador = drFletes["desarrollador"].ToString();
                    //String id_licencia = drFletes["id_licencia"].ToString();
                    //String descripcion = drFletes["descripcion"].ToString();
                    //String manual_usuario = drFletes["manual_usuario"].ToString();
                    //String id_subcategoria_ = drFletes["id_subcategoria"].ToString();


                    dtColumnas.Rows.Add(new object[] { false, id, nombre_producto, version, costo_total, valor_calidad, valor_lenguistico });

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


        private bool actualizarListaSubCategorias(string id_categoria)
        {

            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            try
            {
                String patentesTercerosSQL = "select * from subcategoria where id_categoria = " + id_categoria + " order by id";
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

        private void dataGridSoftwaresRegistrados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void buttonComparar_Click(object sender, RoutedEventArgs e)
        {
            List<producto_sw.Software> listaRanking = new List<Software>();

            if (dataGridSoftwaresRegistrados.Items.Count == 0)
            {
                MessageBox.Show("Tabla vacia");
                // await this.ShowMessageAsync(DiccionarioDatos.ADVERTENCIA, DiccionarioDatos.TABLA_VACIA);
            }

            if (dataGridSoftwaresRegistrados.Items.Count > 0)
            {
                DataTable dtColumnas = new DataTable();

                dtColumnas.Columns.Add("Nombre", typeof(string));
                dtColumnas.Columns.Add("Version", typeof(string));
                dtColumnas.Columns.Add("Costo Total", typeof(string));
                dtColumnas.Columns.Add("Costo Normalizado", typeof(string));
                dtColumnas.Columns.Add("Valor linguistico Costo", typeof(string));
                dtColumnas.Columns.Add("Valor Calidad Producto", typeof(string));
                dtColumnas.Columns.Add("Valor linguistico Calidad Producto", typeof(string));
                dtColumnas.Columns.Add("Puntaje Final", typeof(string));

                dataGridCostoCalidad.ItemsSource = dtColumnas.DefaultView;


                foreach (System.Data.DataRowView dr in dataGridSoftwaresRegistrados.ItemsSource)
                {
                    if (dr[0].Equals(true) == true)
                    {
                        if (!String.IsNullOrEmpty(textPresupuesto.Text))
                        {

                            double presupuesto = Double.Parse(textPresupuesto.Text);
                            double costo_total = Double.Parse(dr[4].ToString());
                            if (presupuesto < costo_total)
                            {
                                MessageBox.Show("El presupuesto debe ser mayor al costo total");
                            }
                            else
                            {
                                double valorNormalizado = costo_total / presupuesto;
                                //MessageBox.Show(Double.Parse(dr[5].ToString()) + "");

                                CostoCalidad costo_calidad = new CostoCalidad(Double.Parse(dr[5].ToString()), valorNormalizado);
                                double puntajeFinal = costo_calidad.obtenerCostoCalidad();

                                Software unSoftware = new Software();
                                unSoftware.Nombre_producto = dr[2].ToString();
                                unSoftware.Version = dr[3].ToString();
                                unSoftware.C_total = dr[4].ToString();
                                unSoftware.Costo_normalizado = valorNormalizado;
                                unSoftware.Nivel_calidad_costo = Etiquetas.obtenerEtiquetaLenguisticaCosto(valorNormalizado);

                                unSoftware.Valor_nivel_calidad = dr[5].ToString(); // del producto
                                unSoftware.Nivel_calidad = dr[6].ToString();  // del producto
                                unSoftware.Puntaje_final = Math.Round((puntajeFinal * 100), 3);

                                listaRanking.Add(unSoftware);
                                // MessageBox.Show(puntajeFinal + "");
                                // insertar en bd y luego consultar
                                
                               
                                
                            }
                        } else
                        {
                            MessageBox.Show("Debe Colocar un presupuesto antes");
                        }
                    }
                }

               // x.puntaje_final.CompareTo(y.puntaje_final);

                listaRanking.Sort((x, y) => y.Puntaje_final.CompareTo(x.Puntaje_final));//string.Compare(x.Puntaje_final, y.Puntaje_final));

                for (int i = 0; i < listaRanking.Count; i++)
                {
                    Software unSoftware = listaRanking.ElementAt(i);

                    dtColumnas.Rows.Add(new object[] { unSoftware.Nombre_producto, unSoftware.Version, unSoftware.C_total, unSoftware.Costo_normalizado, unSoftware.Nivel_calidad_costo, unSoftware.Valor_nivel_calidad, unSoftware.Nivel_calidad, unSoftware.Puntaje_final });
                    
                }
                tabControl.SelectedIndex = 1;
            }
        }
    }
}
