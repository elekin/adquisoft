using Adquisoft.Constantes;
using AdquisicionSoftware.Modulos.Metricas;
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
using System.Globalization;
using System.ComponentModel;
using Evaluate.SubCaracteristicas;
using Evaluate;
using Adquisoft.Evaluacion_Difusa;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Adquisoft.Modulos.Evaluacion_Calidad
{
    /// <summary>
    /// Interaction logic for NuevaEvaluacion.xaml
    /// </summary>
    public partial class NuevaEvaluacion : MetroWindow
    {
        private string id_software;
        private string id_subcategoria;
        private string id_evaluacion;



        LinkedList<Metrica> cuestionarioMetricas = null;
        int indice = 0;

        public NuevaEvaluacion(string id_software, string id_subcategoria)
        {
            this.id_software = id_software;
            this.id_subcategoria = id_subcategoria;

            cuestionarioMetricas = obtenerCuestionarioMetricas();

            InitializeComponent();


            verificaEvaluacionesAnteriores();
            tabInciarEvaluacion.IsEnabled = false;
        }

        private bool verificaEvaluacionesAnteriores()
        {
            // 
            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);

            // seleccionar metricas a utilizar
            try
            {
                conexion.Open();

                DataTable dtColumnas = new DataTable();
                dtColumnas.Columns.Add("id_evaluacion", typeof(string));
                dtColumnas.Columns.Add("id_subcategoria", typeof(string));
                dtColumnas.Columns.Add("id_software", typeof(string));
                dtColumnas.Columns.Add("fecha_evaluacion", typeof(string));
                dtColumnas.Columns.Add("finalizado", typeof(string));


                dataGridHistorialEvaluacionCalidad.ItemsSource = dtColumnas.DefaultView;

                String querySelecionarEvaluacion = "select id, id_subcategoria, id_software, fecha_evaluacion, finalizado from evaluacion_calidad where id_software = " + id_software + " and id_subcategoria = " + id_subcategoria + "  order by id desc limit 5";
                Console.WriteLine(querySelecionarEvaluacion);

                NpgsqlCommand comandoBuscarMetricasUtilizar = new NpgsqlCommand(querySelecionarEvaluacion, conexion);

                NpgsqlDataReader drSelecionarEvaluacion = comandoBuscarMetricasUtilizar.ExecuteReader();
                while (drSelecionarEvaluacion.Read())
                {
                    String id_evaluacion = drSelecionarEvaluacion["id"].ToString();
                    String id_subcategoria = drSelecionarEvaluacion["id_subcategoria"].ToString();
                    String id_software = drSelecionarEvaluacion["id_software"].ToString();
                    String fecha_evaluacion = drSelecionarEvaluacion["fecha_evaluacion"].ToString();
                    String finalizado = drSelecionarEvaluacion["finalizado"].ToString();
                    //MessageBox.Show(drMetricasUtilizar[14].ToString());


                    dtColumnas.Rows.Add(new object[] { id_evaluacion, id_subcategoria, id_software, fecha_evaluacion, finalizado });
                }
            }
            catch
            {

                //MessageBox.Show("Error ");
                return false;
            }
            finally
            {
                conexion.Close();
            }


            return true;
        }


     

        private LinkedList<Metrica> obtenerCuestionarioMetricasGuardado()
        {
            LinkedList<Metrica> cuestionarioMetrica = new LinkedList<Metrica>();
            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            // seleccionar metricas a utilizar
            try
            {
                String queryMetricasUtilizar = "select * from metricas_utilizar mu INNER JOIN metrica m ON mu.id_metrica = m.id INNER JOIN subcaracteristica s ON s.id = m.id_subcaracteristica INNER JOIN caracteristica c ON c.id = s.id_caracteristica INNER JOIN resultado_metrica as rm ON rm.id_metrica = m.id where rm.id_evaluacion_calidad = " + id_evaluacion + " and mu.id_subcategoria = " + id_subcategoria + " order by m.id";
                Console.WriteLine("Aw:  " + queryMetricasUtilizar);
                NpgsqlCommand comandoBuscarMetricasUtilizar = new NpgsqlCommand(queryMetricasUtilizar, conexion);


                NpgsqlDataReader drMetricasUtilizar = comandoBuscarMetricasUtilizar.ExecuteReader();
                while (drMetricasUtilizar.Read())
                {
                    Metrica unaMetrica = new Metrica();
                    unaMetrica.Id = drMetricasUtilizar[2].ToString();
                    unaMetrica.Nombre = drMetricasUtilizar[4].ToString();
                    unaMetrica.Metodo = drMetricasUtilizar[6].ToString();
                    unaMetrica.Formula = drMetricasUtilizar[7].ToString();
                    unaMetrica.Caracteristica = drMetricasUtilizar[20].ToString();
                    unaMetrica.MejorValor = drMetricasUtilizar[8].ToString();
                    unaMetrica.PeorValor = drMetricasUtilizar[9].ToString();
                    unaMetrica.Perspectiva = drMetricasUtilizar[10].ToString();
                    unaMetrica.Proposito = drMetricasUtilizar[5].ToString();
                    unaMetrica.SubCaracteristica = drMetricasUtilizar[16].ToString();
                    unaMetrica.Variables = drMetricasUtilizar[12].ToString();
                    unaMetrica.DescripcionA = drMetricasUtilizar[13].ToString();
                    unaMetrica.DescripcionB = drMetricasUtilizar[14].ToString();

                    unaMetrica.A1 = drMetricasUtilizar[26].ToString();
                    unaMetrica.B1 = drMetricasUtilizar[27].ToString();

                    //MessageBox.Show ()

                    cuestionarioMetrica.AddLast(unaMetrica);
                }
            }
            catch
            {
                MessageBox.Show("Error en consultar las metricas guardadas");
            }
            conexion.Close();

            return cuestionarioMetrica;
        }


        private LinkedList<Metrica> obtenerCuestionarioMetricas()
        {
            LinkedList<Metrica> cuestionarioMetrica = new LinkedList<Metrica>();
            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            // seleccionar metricas a utilizar
            try
            {
                String queryMetricasUtilizar = "select * from metricas_utilizar mu INNER JOIN metrica m ON mu.id_metrica = m.id INNER JOIN subcaracteristica s ON s.id = m.id_subcaracteristica INNER JOIN caracteristica c ON c.id = s.id_caracteristica where mu.id_subcategoria = " + id_subcategoria + " order by m.id;";
                NpgsqlCommand comandoBuscarMetricasUtilizar = new NpgsqlCommand(queryMetricasUtilizar, conexion);


                NpgsqlDataReader drMetricasUtilizar = comandoBuscarMetricasUtilizar.ExecuteReader();
                while (drMetricasUtilizar.Read())
                {
                    Metrica unaMetrica = new Metrica();
                    unaMetrica.Id = drMetricasUtilizar[2].ToString();
                    unaMetrica.Nombre = drMetricasUtilizar[4].ToString();
                    unaMetrica.Metodo = drMetricasUtilizar[6].ToString();
                    unaMetrica.Formula = drMetricasUtilizar[7].ToString();
                    unaMetrica.Caracteristica = drMetricasUtilizar[20].ToString();
                    unaMetrica.MejorValor = drMetricasUtilizar[8].ToString();
                    unaMetrica.PeorValor = drMetricasUtilizar[9].ToString();
                    unaMetrica.Perspectiva = drMetricasUtilizar[10].ToString();
                    unaMetrica.Proposito = drMetricasUtilizar[5].ToString();
                    unaMetrica.SubCaracteristica = drMetricasUtilizar[16].ToString();
                    unaMetrica.Variables = drMetricasUtilizar[12].ToString();
                    unaMetrica.DescripcionA = drMetricasUtilizar[13].ToString();
                    unaMetrica.DescripcionB = drMetricasUtilizar[14].ToString();

                    //MessageBox.Show ()

                    cuestionarioMetrica.AddLast(unaMetrica);
                }
            }
            catch
            {
                MessageBox.Show("Error en consultar las metricas");
            }
            conexion.Close();

            return cuestionarioMetrica;
        }

        private void buttonInciarCuestionario_Click_1(object sender, RoutedEventArgs e)
        {
            prepararCuestionarioNuevaEvaluacion();
        }

        private void prepararCuestionarioModificarEvaluacion ()
        {

          
            cuestionarioMetricas = obtenerCuestionarioMetricasGuardado();

            if (cuestionarioMetricas.Count == 0)
            {
                cuestionarioMetricas = obtenerCuestionarioMetricas();
            }
            else
            {

                tabControl.SelectedIndex = 1;
                tabInciarEvaluacion.IsEnabled = true;
                tabEvaluaciones.IsEnabled = false;



                // actualizar lista antes de cambiar
                labelNombre.Content = cuestionarioMetricas.ElementAt(indice).Nombre;
                label_caracteristica.Content = cuestionarioMetricas.ElementAt(indice).Caracteristica;
                label1_formula.Content = cuestionarioMetricas.ElementAt(indice).Formula;
                labelID.Content = cuestionarioMetricas.ElementAt(indice).Id;
                label1_mejor_valor.Content = cuestionarioMetricas.ElementAt(indice).MejorValor;
                labelMetodo.Text = cuestionarioMetricas.ElementAt(indice).Metodo;
                label1_Peor_Valor.Content = cuestionarioMetricas.ElementAt(indice).PeorValor;
                labelProposito.Text = cuestionarioMetricas.ElementAt(indice).Proposito;
                label_subcaracteristica.Content = cuestionarioMetricas.ElementAt(indice).SubCaracteristica;
                label1_formula.Content = cuestionarioMetricas.ElementAt(indice).Formula;
                labelDescripcionA.Text = cuestionarioMetricas.ElementAt(indice).DescripcionA;
                labelDescripcionB.Text = cuestionarioMetricas.ElementAt(indice).DescripcionB;

                textBoxA.Text = cuestionarioMetricas.ElementAt(indice).A1;
                textBoxB.Text = cuestionarioMetricas.ElementAt(indice).B1;
            }

        }

        private void prepararCuestionarioNuevaEvaluacion ()
        {
            tabControl.SelectedIndex = 1;
            tabInciarEvaluacion.IsEnabled = true;
            tabEvaluaciones.IsEnabled = false;


            // actualizar lista antes de cambiar
            labelNombre.Content = cuestionarioMetricas.ElementAt(indice).Nombre;
            label_caracteristica.Content = cuestionarioMetricas.ElementAt(indice).Caracteristica;
            label1_formula.Content = cuestionarioMetricas.ElementAt(indice).Formula;
            labelID.Content = cuestionarioMetricas.ElementAt(indice).Id;
            label1_mejor_valor.Content = cuestionarioMetricas.ElementAt(indice).MejorValor;
            labelMetodo.Text = cuestionarioMetricas.ElementAt(indice).Metodo;
            label1_Peor_Valor.Content = cuestionarioMetricas.ElementAt(indice).PeorValor;
            labelProposito.Text = cuestionarioMetricas.ElementAt(indice).Proposito;
            label_subcaracteristica.Content = cuestionarioMetricas.ElementAt(indice).SubCaracteristica;
            label1_formula.Content = cuestionarioMetricas.ElementAt(indice).Formula;
            labelDescripcionA.Text = cuestionarioMetricas.ElementAt(indice).DescripcionA;
            labelDescripcionB.Text = cuestionarioMetricas.ElementAt(indice).DescripcionB;

            textBoxA.Text = cuestionarioMetricas.ElementAt(indice).A1;
            textBoxB.Text = cuestionarioMetricas.ElementAt(indice).B1;
        }

        private Metrica obtenerInformacionMetrica(LinkedList<Metrica> cuestionarioMetricas, int i)
        {
            return cuestionarioMetricas.ElementAt(i);
        }


        bool esNuevaEvaluacion = true;

        private async void buttonModificarEvaluacion_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridHistorialEvaluacionCalidad.Items.Count == 0)
            {
                await this.ShowMessageAsync("Error", "Tabla Vacia");
            }

            if (dataGridHistorialEvaluacionCalidad.Items.Count > 0)
            {
                DataRowView fileSalecionada = dataGridHistorialEvaluacionCalidad.SelectedItem as DataRowView;
                if (fileSalecionada != null)
                {

                        id_evaluacion = fileSalecionada.Row[0].ToString();  // evaluacion para modificar
                        esNuevaEvaluacion = false; // es para modifcar
                        prepararCuestionarioModificarEvaluacion();
                    buttonFinalizarCuestionario.Visibility = Visibility.Collapsed;

                }

            }
        }

        private void prepararVariablesCuestionario ()
        {
           
        }


        private void buttonSig_Click(object sender, RoutedEventArgs e)
        {
            // actualizar lista antes de cambiar
            cuestionarioMetricas.ElementAt(indice).Nombre = labelNombre.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).Caracteristica = label_caracteristica.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).Formula = label1_formula.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).Id = labelID.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).MejorValor = label1_mejor_valor.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).Metodo = labelMetodo.Text.ToString();
            cuestionarioMetricas.ElementAt(indice).PeorValor = label1_Peor_Valor.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).Proposito = labelProposito.Text.ToString();
            cuestionarioMetricas.ElementAt(indice).SubCaracteristica = label_subcaracteristica.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).Variables = label1_formula.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).DescripcionA = labelDescripcionA.Text.ToString();
            cuestionarioMetricas.ElementAt(indice).DescripcionB = labelDescripcionB.Text.ToString();

            cuestionarioMetricas.ElementAt(indice).A1 = textBoxA.Text;
            cuestionarioMetricas.ElementAt(indice).B1 = textBoxB.Text;



            int max = cuestionarioMetricas.Count;
            if ((indice + 1) < max)
            {
                indice = indice + 1;
                buttonSig.IsEnabled = true;

                labelNombre.Content = cuestionarioMetricas.ElementAt(indice).Nombre;
                label_caracteristica.Content = cuestionarioMetricas.ElementAt(indice).Caracteristica;
                label1_formula.Content = cuestionarioMetricas.ElementAt(indice).Formula;
                labelID.Content = cuestionarioMetricas.ElementAt(indice).Id;
                label1_mejor_valor.Content = cuestionarioMetricas.ElementAt(indice).MejorValor;
                labelMetodo.Text = cuestionarioMetricas.ElementAt(indice).Metodo;
                label1_Peor_Valor.Content = cuestionarioMetricas.ElementAt(indice).PeorValor;
                labelProposito.Text = cuestionarioMetricas.ElementAt(indice).Proposito;
                label_subcaracteristica.Content = cuestionarioMetricas.ElementAt(indice).SubCaracteristica;
                label1_formula.Content = cuestionarioMetricas.ElementAt(indice).Formula;
                labelDescripcionA.Text = cuestionarioMetricas.ElementAt(indice).DescripcionA;
                labelDescripcionB.Text = cuestionarioMetricas.ElementAt(indice).DescripcionB;

                textBoxA.Text = cuestionarioMetricas.ElementAt(indice).A1;
                textBoxB.Text = cuestionarioMetricas.ElementAt(indice).B1;

                if (String.IsNullOrEmpty(textBoxA.Text))
                {
                    textBoxA.Text = "0";
                    slider.Value = Double.Parse(textBoxA.Text);
                }

                if (String.IsNullOrEmpty(textBoxB.Text))
                {
                    textBoxB.Text = "0";
                    slider_Copy.Value = Double.Parse(textBoxB.Text);
                }


                slider.Value = Double.Parse(textBoxA.Text);
                slider_Copy.Value = Double.Parse(textBoxB.Text);


                if (indice + 1 == max) {
                    buttonSig.IsEnabled = false;
                    //buttonAnt.IsEnabled = false;

                    // fin cadena
                    buttonFinalizarCuestionario.IsEnabled = true;
                }

            }

            if (indice == max - 1)
            {
                buttonAnt.IsEnabled = true;
            }
        }

        private void buttonAnt_Click(object sender, RoutedEventArgs e)
        {


            // actualizar lista antes de cambiar
            cuestionarioMetricas.ElementAt(indice).Nombre = labelNombre.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).Caracteristica = label_caracteristica.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).Formula = label1_formula.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).Id = labelID.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).MejorValor = label1_mejor_valor.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).Metodo = labelMetodo.Text.ToString();
            cuestionarioMetricas.ElementAt(indice).PeorValor = label1_Peor_Valor.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).Proposito = labelProposito.Text.ToString();
            cuestionarioMetricas.ElementAt(indice).SubCaracteristica = label_subcaracteristica.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).Variables = label1_formula.Content.ToString();
            cuestionarioMetricas.ElementAt(indice).DescripcionA = labelDescripcionA.Text.ToString();
            cuestionarioMetricas.ElementAt(indice).DescripcionB = labelDescripcionB.Text.ToString();


            cuestionarioMetricas.ElementAt(indice).A1 = textBoxA.Text;
            cuestionarioMetricas.ElementAt(indice).B1 = textBoxB.Text;



            int min = -1;
            if ((indice - 1) > min)
            {
                indice = indice - 1;
                buttonAnt.IsEnabled = true;
                buttonSig.IsEnabled = true;


                labelNombre.Content = cuestionarioMetricas.ElementAt(indice).Nombre;
                label_caracteristica.Content = cuestionarioMetricas.ElementAt(indice).Caracteristica;
                label1_formula.Content = cuestionarioMetricas.ElementAt(indice).Formula;
                labelID.Content = cuestionarioMetricas.ElementAt(indice).Id;
                label1_mejor_valor.Content = cuestionarioMetricas.ElementAt(indice).MejorValor;
                labelMetodo.Text = cuestionarioMetricas.ElementAt(indice).Metodo;
                label1_Peor_Valor.Content = cuestionarioMetricas.ElementAt(indice).PeorValor;
                labelProposito.Text = cuestionarioMetricas.ElementAt(indice).Proposito;
                label_subcaracteristica.Content = cuestionarioMetricas.ElementAt(indice).SubCaracteristica;
                label1_formula.Content = cuestionarioMetricas.ElementAt(indice).Variables;
                labelDescripcionA.Text = cuestionarioMetricas.ElementAt(indice).DescripcionA;
                labelDescripcionB.Text = cuestionarioMetricas.ElementAt(indice).DescripcionB;


                textBoxA.Text = cuestionarioMetricas.ElementAt(indice).A1;
                textBoxB.Text = cuestionarioMetricas.ElementAt(indice).B1;

                if (String.IsNullOrEmpty(textBoxA.Text))
                {
                    textBoxA.Text = "0";
                    slider.Value = Double.Parse(textBoxA.Text);
                }

                if (String.IsNullOrEmpty(textBoxB.Text))
                {
                    textBoxB.Text = "0";
                    slider_Copy.Value = Double.Parse(textBoxB.Text);
                }

                slider.Value = Double.Parse(textBoxA.Text);
                slider_Copy.Value = Double.Parse(textBoxB.Text);


                if (indice - 1 == min)
                {
                    buttonAnt.IsEnabled = false;

                    buttonSig.IsEnabled = true;
                }
            }


            if (indice == min + 1)
            {
                buttonSig.IsEnabled = true;
                buttonAnt.IsEnabled = true;
            }

        }

        private async void buttonFinalizarCuestionario_Click(object sender, RoutedEventArgs e)
        {
            // recorrer lista verificar
            if (await encuentraError() == false)
            {
                if (esNuevaEvaluacion == true) // si es nueva evaluacion
                {
                    id_evaluacion = insertaNuevaEvaluacion();
                    insertarValoresMetricas(id_evaluacion);


                    var TrabajoPrueba = new BackgroundWorker()
                    {
                        WorkerReportsProgress = true,
                        WorkerSupportsCancellation = true
                    };

                    TrabajoPrueba.DoWork += RealizarTrabajoNuevaEvaluacion;
                    TrabajoPrueba.RunWorkerCompleted += TrabajoCompletadoNuevaEvaluacion;
                    TrabajoPrueba.RunWorkerAsync();

                }
            }
        }



        public void RealizarTrabajoNuevaEvaluacion(object sender, DoWorkEventArgs e)
        {
            // valores de incidencia caracteristica
            double inEficiencia = 0;
            double inFiabilidad = 0;
            double inFuncionalidad = 0;
            double inUsabilidad = 0;


            // valores de incidencia sub-caracteristicas
            double inAtractividad = 0;
            double inFacilidadAprendizaje = 0;
            double inComprensibilidad = 0;
            double inOperabilidad = 0;
            double inCumplimientoUsabilidad = 0;

            double inComportamientoTemporal = 0;
            double inUtilizacionRecursos = 0;
            double inCumplimientoEficiencia = 0;

            double inMadurez = 0;
            double inToleranciaFallos = 0;
            double inRecuperabilidad = 0;
            double inCumplimientoFiabilidad = 0;

            double inAdecuacion = 0;
            double inExactitud = 0;
            double inInteroperabilidad = 0;
            double inSeguridad = 0;
            double inCumplimientoFuncional = 0;


            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            try
            {
                String queryIncidenciasCaracteristicas = "select s.nombre, isb.valor from incidencia_caracteristica as isb INNER JOIN caracteristica as s ON isb.id_caracteristica = s.id where id_subcategoria = " + id_subcategoria + ";";

                NpgsqlCommand comandoBuscarIncidenciasCaracteristicas = new NpgsqlCommand(queryIncidenciasCaracteristicas, conexion);

                NpgsqlDataReader drIncidenciasCaracteristicas = comandoBuscarIncidenciasCaracteristicas.ExecuteReader();
                while (drIncidenciasCaracteristicas.Read())
                {
                    if (drIncidenciasCaracteristicas[0].Equals("Eficiencia"))
                    {
                        inEficiencia = Double.Parse(drIncidenciasCaracteristicas[1].ToString());
                        //MessageBox.Show(inEficiencia + "inEficiencia");
                    }
                    if (drIncidenciasCaracteristicas[0].Equals("Fiabilidad"))
                    {
                        inFiabilidad = Double.Parse(drIncidenciasCaracteristicas[1].ToString());
                        //MessageBox.Show(inFiabilidad + "Fiabilidad");
                    }
                    if (drIncidenciasCaracteristicas[0].Equals("Funcionalidad"))
                    {
                        inFuncionalidad = Double.Parse(drIncidenciasCaracteristicas[1].ToString());
                        //MessageBox.Show(inFuncionalidad + "inFuncionalidad");
                    }
                    if (drIncidenciasCaracteristicas[0].Equals("Usabilidad"))
                    {
                        inUsabilidad = Double.Parse(drIncidenciasCaracteristicas[1].ToString());
                        //MessageBox.Show(inUsabilidad + "usabilidad");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error las incidencias de las caracteristicas");
            }

            // incidencias caracteristicas
            Console.WriteLine("Incidencias caracteristicas.............");
            Console.WriteLine("usabilidad: " + inUsabilidad);
            Console.WriteLine("fiabilidad: " + inFiabilidad);
            Console.WriteLine("funcionalidad: " + inFuncionalidad);
            Console.WriteLine("eficiencia: " + inEficiencia);
            Console.WriteLine(".........................");

            // seleccionar valor incidencias sub.caracteristicas
            try
            {
                String queryIncidenciasSubCaracteristicas = "select s.nombre, isb.valor from incidencia_subcaracteristica as isb INNER JOIN subcaracteristica as s ON isb.id_subcaracteristica = s.id where id_subcategoria = " + id_subcategoria + ";";
                NpgsqlCommand comandoBuscarIncidenciasSubCaracteristicas = new NpgsqlCommand(queryIncidenciasSubCaracteristicas, conexion);
                NpgsqlDataReader drIncidenciasSubcaracteristicas = comandoBuscarIncidenciasSubCaracteristicas.ExecuteReader();

                while (drIncidenciasSubcaracteristicas.Read())
                {

                    // Funcionalidad

                    if (drIncidenciasSubcaracteristicas[0].Equals("Exactitud"))
                    {
                        inExactitud = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }
                    if (drIncidenciasSubcaracteristicas[0].Equals("Adecuación"))
                    {
                        inAdecuacion = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());
                    }
                    if (drIncidenciasSubcaracteristicas[0].Equals("Interoperabilidad"))
                    {
                        inInteroperabilidad = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }
                    if (drIncidenciasSubcaracteristicas[0].Equals("Seguridad"))
                    {
                        inSeguridad = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }
                    if (drIncidenciasSubcaracteristicas[0].Equals("Cumplimiento Funcional"))
                    {
                        inCumplimientoFuncional = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }

                    // Eficiencia
                    if (drIncidenciasSubcaracteristicas[0].Equals("Comportamiento Temporal"))
                    {
                        inComportamientoTemporal = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }
                    if (drIncidenciasSubcaracteristicas[0].Equals("Utilización Recursos"))
                    {
                        inUtilizacionRecursos = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }
                    if (drIncidenciasSubcaracteristicas[0].Equals("Cumplimiento Eficiencia"))
                    {
                        inCumplimientoEficiencia = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }

                    // Fiabilidad
                    if (drIncidenciasSubcaracteristicas[0].Equals("Madurez"))
                    {
                        inMadurez = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }

                    if (drIncidenciasSubcaracteristicas[0].Equals("Tolerancia a Fallos"))
                    {
                        inToleranciaFallos = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }


                    if (drIncidenciasSubcaracteristicas[0].Equals("Recuperabilidad"))
                    {
                        inRecuperabilidad = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }

                    if (drIncidenciasSubcaracteristicas[0].Equals("Cumplimiento Fiabilidad"))
                    {
                        inCumplimientoFiabilidad = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }

                    // Usabilidad
                    if (drIncidenciasSubcaracteristicas[0].Equals("Facilidad Aprendizaje"))
                    {
                        inFacilidadAprendizaje = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());


                    }
                    if (drIncidenciasSubcaracteristicas[0].Equals("Operabilidad"))
                    {
                        inOperabilidad = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());


                    }

                    if (drIncidenciasSubcaracteristicas[0].Equals("Comprensibilidad"))
                    {
                        inComprensibilidad = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());


                    }

                    if (drIncidenciasSubcaracteristicas[0].Equals("Atractividad"))
                    {
                        inAtractividad = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }

                    if (drIncidenciasSubcaracteristicas[0].Equals("Cumplimiento Usabilidad"))
                    {
                        inCumplimientoUsabilidad = Double.Parse(drIncidenciasSubcaracteristicas[1].ToString());

                    }

                }
            }
            catch
            {
                MessageBox.Show("Error las incidencias de las sub-caracteristicas");
            }

            // seteo los grados de incidencia
            Funcionalidad funcionalidad = new Funcionalidad(inAdecuacion, inExactitud, inInteroperabilidad, inSeguridad, inCumplimientoFuncional); //
            Fiabilidad fiabilidad = new Fiabilidad(inMadurez, inToleranciaFallos, inRecuperabilidad, inCumplimientoFiabilidad);
            Eficiencia eficiencia = new Eficiencia(inComportamientoTemporal, inUtilizacionRecursos, inCumplimientoEficiencia); //
            Usabilidad usabilidad = new Usabilidad(inFacilidadAprendizaje, inComprensibilidad, inOperabilidad, inAtractividad, inCumplimientoUsabilidad); //


            // seleccionar metricas a utilizar con su ponderacion
            try
            {
                String queryPromedioMetricas = "select sc.nombre, AVG(CAST(rm.resultado as REAL)), sc.id from resultado_metrica as rm, metrica as m, metricas_utilizar as mu, subcaracteristica as sc, caracteristica as c where mu.id_subcategoria = " + id_subcategoria + " and rm.id_evaluacion_calidad = " + id_evaluacion + " and rm.id_metrica = m.id and mu.id_metrica = m.id and sc.id = m.id_subcaracteristica and c.id = sc.id_caracteristica group by sc.nombre,rm.resultado, sc.id";

                NpgsqlCommand comandoBuscarPromedioMetricas = new NpgsqlCommand(queryPromedioMetricas, conexion);
                Console.WriteLine(queryPromedioMetricas + " AVG");

                NpgsqlDataReader drPromedioMetricas = comandoBuscarPromedioMetricas.ExecuteReader();
                while (drPromedioMetricas.Read())
                {

                    // Funcionalidad
                 

                    if (drPromedioMetricas[0].Equals("Exactitud"))
                    {
                        funcionalidad.Exactitud = Double.Parse(drPromedioMetricas[1].ToString());
                        funcionalidad.Id_exactitud = (int)drPromedioMetricas[2];

                    }
                    if (drPromedioMetricas[0].Equals("Adecuación"))
                    {
                        funcionalidad.Adecuacion = Double.Parse(drPromedioMetricas[1].ToString());
                        funcionalidad.Id_adecuacion = (int)drPromedioMetricas[2];
                        //MessageBox.Show(funcionalidad.Adecuacion + " Adecuacion");
                    }
                    if (drPromedioMetricas[0].Equals("Interoperabilidad"))
                    {
                        funcionalidad.Interoperabilidad = Double.Parse(drPromedioMetricas[1].ToString());
                        funcionalidad.Id_interoperabilidad = (int)drPromedioMetricas[2];
                        //MessageBox.Show(funcionalidad.Interoperabilidad + " in");
                    }
                    if (drPromedioMetricas[0].Equals("Seguridad"))
                    {
                        funcionalidad.Seguridad = Double.Parse(drPromedioMetricas[1].ToString());
                        funcionalidad.Id_seguridad = (int)drPromedioMetricas[2];
                    }
                    if (drPromedioMetricas[0].Equals("Cumplimiento Funcional"))
                    {
                        funcionalidad.CumplimientoFuncional = Double.Parse(drPromedioMetricas[1].ToString());
                        funcionalidad.Id_cumplimientoFuncional = (int)drPromedioMetricas[2];
                    }

                    // Eficiencia
                    if (drPromedioMetricas[0].Equals("Comportamiento Temporal"))
                    {
                        eficiencia.ComportamientoTemporal = Double.Parse(drPromedioMetricas[1].ToString());
                        eficiencia.Id_comportamientoTemporal = (int)drPromedioMetricas[2];
                    }
                    if (drPromedioMetricas[0].Equals("Utilización Recursos"))
                    {
                        eficiencia.UtilizacionRecursos = Double.Parse(drPromedioMetricas[1].ToString());
                        eficiencia.Id_utilizacionRecursos = (int)drPromedioMetricas[2];
                    }
                    if (drPromedioMetricas[0].Equals("Cumplimiento Eficiencia"))
                    {
                        eficiencia.CumplimientoEficiencia = Double.Parse(drPromedioMetricas[1].ToString());
                        eficiencia.Id_cumplimientoEficiencia = (int)drPromedioMetricas[2];
                    }

                    // Fiabilidad
                    if (drPromedioMetricas[0].Equals("Madurez"))
                    {
                        fiabilidad.Madurez = Double.Parse(drPromedioMetricas[1].ToString());
                        fiabilidad.Id_madurez = (int)drPromedioMetricas[2];
                     
                    }

                    if (drPromedioMetricas[0].Equals("Tolerancia a Fallos"))
                    {
                        fiabilidad.ToleranciaFallos = Double.Parse(drPromedioMetricas[1].ToString());
                        fiabilidad.Id_toleranciaFallos = (int)drPromedioMetricas[2];
                       
                    }


                    if (drPromedioMetricas[0].Equals("Recuperabilidad"))
                    {
                        fiabilidad.Recuperabilidad = Double.Parse(drPromedioMetricas[1].ToString());
                        fiabilidad.Id_recuperabilidad = (int)drPromedioMetricas[2];
                    }

                    if (drPromedioMetricas[0].Equals("Cumplimiento Fiabilidad"))
                    {
                        fiabilidad.CumplimientoFiabilidad = Double.Parse(drPromedioMetricas[1].ToString());
                        fiabilidad.Id_cumplimientoFiabilidad = (int)drPromedioMetricas[2];
                    }

                    // Usabilidad
                    if (drPromedioMetricas[0].Equals("Facilidad Aprendizaje"))
                    {
                        usabilidad.FacilidadAprendizaje = Double.Parse(drPromedioMetricas[1].ToString());
                        usabilidad.Id_facilidadAprendizaje = (int)drPromedioMetricas[2];
                    }
                    if (drPromedioMetricas[0].Equals("Operabilidad"))
                    {
                        usabilidad.Operabilidad = Double.Parse(drPromedioMetricas[1].ToString());
                        usabilidad.Id_operabilidad = (int)drPromedioMetricas[2];

                        //MessageBox.Show("DR: " + drPromedioMetricas[0].ToString());
                      ;
                    }

                    if (drPromedioMetricas[0].Equals("Comprensibilidad"))
                    {
                        usabilidad.Comprensibilidad = Double.Parse(drPromedioMetricas[1].ToString());
                        usabilidad.Id_comprensibilidad = (int)drPromedioMetricas[2];

                    }

                    if (drPromedioMetricas[0].Equals("Atractividad"))
                    {
                        usabilidad.Atractividad = Double.Parse(drPromedioMetricas[1].ToString());
                        usabilidad.Id_atractividad = (int)drPromedioMetricas[2];
                    }

                    if (drPromedioMetricas[0].Equals("Cumplimiento Usabilidad"))
                    {
                        usabilidad.CumplimientoUsabilidad = Double.Parse(drPromedioMetricas[1].ToString());
                        usabilidad.Id_cumplimientoUsabilidad = (int)drPromedioMetricas[2];
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error en consultar las metricas AVG");
            }
            conexion.Close();



            // calcula valores antes de la logica difusa
            usabilidad.calcularValoresNormalizado();
            fiabilidad.calcularValoresNormalizado();
            funcionalidad.calcularValoresNormalizado();
            eficiencia.calcularValoresNormalizado();

            // IMPRIMIENDO POR FUERA A FIABILIDAD
            Console.WriteLine("POR FUERA.............");
            Console.WriteLine("madurez: " + fiabilidad.Madurez);
            Console.WriteLine("toleranciaFallos: " + fiabilidad.ToleranciaFallos);
            Console.WriteLine("recuperabilidad: " + fiabilidad.Recuperabilidad);
            Console.WriteLine("cumplimientoFiabilidad: " + fiabilidad.CumplimientoFiabilidad);

            SegundoNivelCaracteristica calcularCaracteristica = new SegundoNivelCaracteristica(fiabilidad, funcionalidad, eficiencia, usabilidad);

            usabilidad.CalidadUsabilidad = calcularCaracteristica.obtenerUsabilidad(); // usabilidad
            funcionalidad.Calidadfuncionalidad = calcularCaracteristica.obtenerFuncionalidad(); // funcionalidad
            fiabilidad.CalidadFiabilidad = calcularCaracteristica.obtenerFiablidad(); // fiabilidad
            eficiencia.CalidadEficiencia = calcularCaracteristica.obtenerEficiencia(); // eficiencia

            Console.WriteLine("Valor Calidad Caracteristicas .............");
            Console.WriteLine("usabilidad: " + usabilidad.CalidadUsabilidad);
            Console.WriteLine("funcionalidad: " + funcionalidad.Calidadfuncionalidad);
            Console.WriteLine("fiabilidad: " + fiabilidad.CalidadFiabilidad);
            Console.WriteLine("eficiencia: " + eficiencia.CalidadEficiencia);

            
            // inserta valores en tabla resultado sub caracteristicas
            insertaResultadoSubCaracteristica(usabilidad, funcionalidad, eficiencia, fiabilidad); // revisar

            // obtener por consulta SQL A LA TABLA CATEGORIA

            double[] valoresIncidencias = { inUsabilidad, inFuncionalidad, inFiabilidad, inEficiencia };

            // valores antes de entrar a la logica difusa
            double usabilidadPonderado = Ponderacion.obtenerPonderacion(usabilidad.CalidadUsabilidad, inUsabilidad, valoresIncidencias);
            double funcionalidadPonderado = Ponderacion.obtenerPonderacion(funcionalidad.Calidadfuncionalidad, inFuncionalidad, valoresIncidencias);
            double fiabilidadPonderado = Ponderacion.obtenerPonderacion(fiabilidad.CalidadFiabilidad, inFiabilidad, valoresIncidencias);
            double eficienciaPonderado = Ponderacion.obtenerPonderacion(eficiencia.CalidadEficiencia, inEficiencia, valoresIncidencias);

            // inserta valores en tabla resultado caracteristicas
            insertaResultadoCaracteristica(usabilidadPonderado, funcionalidadPonderado, fiabilidadPonderado, eficienciaPonderado);

            PrimerNivelCalidadProducto calcularNivelCalidadProducto = new PrimerNivelCalidadProducto(fiabilidadPonderado, funcionalidadPonderado, eficienciaPonderado, usabilidadPonderado);

            double valorCalidadProducto = calcularNivelCalidadProducto.obtenerCalidadProducto();
            Console.WriteLine("Calidad del Producto: " + valorCalidadProducto);

            insertarCalidadProducto(valorCalidadProducto);

            // modifica evaluacion finalizado 1 (update)
            modificaEvaluacionFinalizada(1);
        }

        private void insertaResultadoCaracteristica(double usabilidadPonderado, double funcionalidadPonderado, double fiabilidadPonderado, double eficienciaPonderado)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            try
            {

                string queryInsertaUsabilidad = "INSERT INTO resultado_caracteristica(id, nivel_calidad, valor_nivel_calidad, id_evaluacion_calidad, id_caracteristica) VALUES ((select nextval('s_resultado_caracteristica')), '" + Etiquetas.obtenerEtiquetaLenguistica(usabilidadPonderado) + "' ,'" + Math.Round(usabilidadPonderado, 2) + "' ,'" + id_evaluacion + "' , 3);";
                string queryInsertaFiabilidad = "INSERT INTO resultado_caracteristica(id, nivel_calidad, valor_nivel_calidad, id_evaluacion_calidad, id_caracteristica) VALUES ((select nextval('s_resultado_caracteristica')), '" + Etiquetas.obtenerEtiquetaLenguistica(fiabilidadPonderado) + "' ,'" + Math.Round(fiabilidadPonderado, 2) + "' ,'" + id_evaluacion + "' , 2);";
                string queryInsertaEficiencia = "INSERT INTO resultado_caracteristica(id, nivel_calidad, valor_nivel_calidad, id_evaluacion_calidad, id_caracteristica) VALUES ((select nextval('s_resultado_caracteristica')), '" + Etiquetas.obtenerEtiquetaLenguistica(eficienciaPonderado) + "' ,'" + Math.Round(eficienciaPonderado, 2) + "' ,'" + id_evaluacion + "' , 4);";
                string queryInsertaFuncionalidad = "INSERT INTO resultado_caracteristica(id, nivel_calidad, valor_nivel_calidad, id_evaluacion_calidad, id_caracteristica) VALUES ((select nextval('s_resultado_caracteristica')), '" + Etiquetas.obtenerEtiquetaLenguistica(funcionalidadPonderado) + "' ,'" + Math.Round(funcionalidadPonderado, 2) + "' ,'" + id_evaluacion + "' , 1);";


                NpgsqlCommand cmd1 = new NpgsqlCommand(queryInsertaUsabilidad, conexion);
                NpgsqlCommand cmd2 = new NpgsqlCommand(queryInsertaFiabilidad, conexion);
                NpgsqlCommand cmd3 = new NpgsqlCommand(queryInsertaEficiencia, conexion);
                NpgsqlCommand cmd4 = new NpgsqlCommand(queryInsertaFuncionalidad, conexion);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();

            }
            catch
            {
                Console.WriteLine("Error! no se puede inserta el resultado de la caracteristica");
            }

            conexion.Close();
        }

        private void modificaEvaluacionFinalizada (int estaFinalizado)
        {
            // conexion
            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            try
            {
                string queryModificaFinalizado = "UPDATE evaluacion_calidad SET finalizado = "+ estaFinalizado + " WHERE id = "+ id_evaluacion +"";
                Console.WriteLine(queryModificaFinalizado);
                NpgsqlCommand cmd = new NpgsqlCommand(queryModificaFinalizado, conexion);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                Console.WriteLine("Error! no se puede modificar la finalizacion");
            }

            conexion.Close();
        }


        // inserta nivel calidad producto final
        private void insertarCalidadProducto(double valorCalidadProducto)
        {
            // conexion
            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            try
            {

                string queryInsertaResultadosMetricas = "INSERT INTO resultado_evaluacion_calidad(id, nivel_calidad, valor_nivel_calidad, id_evaluacion_calidad) VALUES ((select nextval('s_resultado_evaluacion_calidad')), '" + Etiquetas.obtenerEtiquetaLenguistica(valorCalidadProducto) + "' ,'" + Math.Round(valorCalidadProducto, 2) + "' ,'" + id_evaluacion + "');";


                Console.WriteLine(queryInsertaResultadosMetricas);
                NpgsqlCommand cmd = new NpgsqlCommand(queryInsertaResultadosMetricas, conexion);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                Console.WriteLine("Error! no se puede inserta el resultado de la metrica");
            }
        
            conexion.Close();
        }

        private void insertaResultadoSubCaracteristica (Usabilidad usabilidad, Funcionalidad funcionalidad, Eficiencia eficiencia, Fiabilidad fiabilidad)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            try
            {
                string queryRepetida = "INSERT INTO resultado_subcaracteristica(id, nivel_calidad, id_evaluacion_calidad, valor_nivel_calidad, id_subcaracteristica) VALUES((select nextval('s_resultado_subcaracteristica')),";

                string Atractividad = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(usabilidad.Atractividad) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(usabilidad.Atractividad, 2) + "' , 13);";
               // Console.WriteLine(Atractividad);
                string FacilidadAprendizaje = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(usabilidad.FacilidadAprendizaje) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(usabilidad.FacilidadAprendizaje, 2) + "' , 10);";
                string Comprensibilidad = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(usabilidad.Comprensibilidad ) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(usabilidad.Comprensibilidad, 2) + "' , 11);";
                string Operabilidad = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(usabilidad.Operabilidad) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(usabilidad.Operabilidad, 2) + "' , 12);";
                string CumplimientoUsabilidad = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(usabilidad.CumplimientoUsabilidad) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(usabilidad.CumplimientoUsabilidad, 2) + "' , 14);";

                string ComportamientoTemporal = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(eficiencia.ComportamientoTemporal) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(eficiencia.ComportamientoTemporal, 2) + "' , 15);";
                string UtilizacionRecursos = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(eficiencia.UtilizacionRecursos) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(eficiencia.UtilizacionRecursos, 2) + "' , 16);";
                string CumplimientoEficiencia = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(eficiencia.CumplimientoEficiencia) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(eficiencia.CumplimientoEficiencia, 2) + "' , 17);";

                string Madurez = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(fiabilidad.Madurez) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(fiabilidad.Madurez, 2) + "' , 6);";
                string ToleranciaFallos = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(fiabilidad.ToleranciaFallos) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(fiabilidad.ToleranciaFallos, 2) + "' , 7);";
                string Recuperabilidad = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(fiabilidad.Recuperabilidad) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(fiabilidad.Recuperabilidad, 2) + "' , 8);";
                string CumplimientoFiabilidad = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(fiabilidad.CumplimientoFiabilidad) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(fiabilidad.CumplimientoFiabilidad, 2) + "' , 9);";

                string Adecuacion = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(funcionalidad.Adecuacion) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(funcionalidad.Adecuacion, 2) + "' , 1);"; ;
                string Exactitud = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(funcionalidad.Exactitud) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(funcionalidad.Exactitud, 2) + "' , 2);";
                string Interoperabilidad = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(funcionalidad.Interoperabilidad) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(funcionalidad.Interoperabilidad, 2) + "' , 3);";
                string Seguridad = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(funcionalidad.Seguridad) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(funcionalidad.Seguridad, 2) + "' , 4);";
                string CumplimientoFuncional = queryRepetida + " '" + Etiquetas.obtenerEtiquetaLenguistica(funcionalidad.CumplimientoFuncional) + "' ,'" + id_evaluacion + "' ,'" + Math.Round(funcionalidad.CumplimientoFuncional, 2) + "' , 5);";



                //string queryInsertaResultadosMetricas = "INSERT INTO resultado_subcaracteristica(id, nivel_calidad, valor_nivel_calidad, id_evaluacion_calidad) VALUES ((select nextval('s_resultado_evaluacion_calidad')), '" + Etiquetas.obtenerEtiquetaLenguistica(valorCalidadProducto) + "' ,'" + valorCalidadProducto + "' ,'" + id_evaluacion + "');";


                //Console.WriteLine(queryInsertaResultadosMetricas);
                NpgsqlCommand cmd1 = new NpgsqlCommand(Adecuacion, conexion);
                NpgsqlCommand cmd2 = new NpgsqlCommand(Exactitud, conexion);
                NpgsqlCommand cmd3 = new NpgsqlCommand(Interoperabilidad, conexion);
                NpgsqlCommand cmd4 = new NpgsqlCommand(Seguridad, conexion);
                NpgsqlCommand cmd5 = new NpgsqlCommand(CumplimientoFuncional, conexion);
                NpgsqlCommand cmd6 = new NpgsqlCommand(Madurez, conexion);
                NpgsqlCommand cmd7 = new NpgsqlCommand(ToleranciaFallos, conexion);
                NpgsqlCommand cmd8 = new NpgsqlCommand(Recuperabilidad, conexion);
                NpgsqlCommand cmd9 = new NpgsqlCommand(CumplimientoFiabilidad, conexion);
                NpgsqlCommand cmd10 = new NpgsqlCommand(FacilidadAprendizaje, conexion);
                NpgsqlCommand cmd11 = new NpgsqlCommand(Comprensibilidad, conexion);
                NpgsqlCommand cmd12 = new NpgsqlCommand(Operabilidad, conexion);
                NpgsqlCommand cmd13 = new NpgsqlCommand(Atractividad, conexion);
                NpgsqlCommand cmd14 = new NpgsqlCommand(CumplimientoUsabilidad, conexion);
                NpgsqlCommand cmd15 = new NpgsqlCommand(ComportamientoTemporal, conexion);
                NpgsqlCommand cmd16 = new NpgsqlCommand(UtilizacionRecursos, conexion);
                NpgsqlCommand cmd17 = new NpgsqlCommand(CumplimientoEficiencia, conexion);

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();
                cmd6.ExecuteNonQuery();
                cmd7.ExecuteNonQuery();
                cmd8.ExecuteNonQuery();
                cmd9.ExecuteNonQuery();
                cmd10.ExecuteNonQuery();
                cmd11.ExecuteNonQuery();
                cmd12.ExecuteNonQuery();
                cmd13.ExecuteNonQuery();
                cmd14.ExecuteNonQuery();
                cmd15.ExecuteNonQuery();
                cmd16.ExecuteNonQuery();
                cmd17.ExecuteNonQuery();


            }
            catch
            {
                Console.WriteLine("Error! no se puede inserta el resultado de las sub-caracteristicas");
            }

            conexion.Close();
        }
    

    public async void TrabajoCompletadoNuevaEvaluacion(object sender, RunWorkerCompletedEventArgs e)
    {
            buttonAnt.IsEnabled = false;
            buttonSig.IsEnabled = false;
            buttonFinalizarCuestionario.IsEnabled = false;

            tabControl.SelectedIndex = 2;
            tabReporteEvaluacionCalidad.Header = "Reportes Calidad";

            await this.ShowMessageAsync("Evaluación Finalizada", "La Evaluación de calidad a finalizado correctamente");

            generarReporteNivelCalidadProducto();
    }

    public void generarReporteNivelCalidadProducto()
    {
            
            NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexion.Open();

            // seleccionar metricas a utilizar
            try
            {
                DataTable dtColumnas = new DataTable();
                dtColumnas.Columns.Add("Sub-Caracteristica", typeof(string));
                dtColumnas.Columns.Add("Valor Sin Ponderar", typeof(string));
                dtColumnas.Columns.Add("Valor Incidencia", typeof(string));
                dtColumnas.Columns.Add("Valor Final", typeof(string));
                dtColumnas.Columns.Add("Valor Lenguistico", typeof(string));


                dataGridSubCaracteristicas.ItemsSource = dtColumnas.DefaultView;

                String queryInformacionSubCaracteristicas = "select sc.nombre, AVG(CAST(rm.resultado as REAL)), isb.valor, rs.valor_nivel_calidad, rs.nivel_calidad from resultado_metrica as rm, metrica as m, metricas_utilizar as mu, subcaracteristica as sc, caracteristica as c, incidencia_subcaracteristica as isb, resultado_subcaracteristica as rs where mu.id_subcategoria = "+id_subcategoria+" and rm.id_evaluacion_calidad = "+id_evaluacion+" and rs.id_evaluacion_calidad = "+id_evaluacion+" and rs.id_subcaracteristica = sc.id and isb.id_subcaracteristica = sc.id and rm.id_metrica = m.id and mu.id_metrica = m.id and sc.id = m.id_subcaracteristica and c.id = sc.id_caracteristica group by sc.nombre,rm.resultado, isb.valor, rs.valor_nivel_calidad, rs.nivel_calidad"; ;
                NpgsqlCommand comandoInformacionSubCaracteristicasr = new NpgsqlCommand(queryInformacionSubCaracteristicas, conexion);


                NpgsqlDataReader drComandoInformacionSubCaracteristicasr = comandoInformacionSubCaracteristicasr.ExecuteReader();
                while (drComandoInformacionSubCaracteristicasr.Read())
                {
                    dtColumnas.Rows.Add(new object[] { drComandoInformacionSubCaracteristicasr[0].ToString(), Math.Round(Double.Parse(drComandoInformacionSubCaracteristicasr[1].ToString()), 3), drComandoInformacionSubCaracteristicasr[2].ToString(), drComandoInformacionSubCaracteristicasr[3].ToString(), drComandoInformacionSubCaracteristicasr[4].ToString() });
                                     
                }
            }
            catch
            {
                MessageBox.Show("Error en consultar el generar reporte sub-caracteristica");
            }




            // seleccionar nivel caracteristicas
            try
            {
                DataTable dtColumnas = new DataTable();
                dtColumnas.Columns.Add("Caracteristica", typeof(string));
                dtColumnas.Columns.Add("Valor Incidencia", typeof(string));
                dtColumnas.Columns.Add("Valor Final", typeof(string));
                dtColumnas.Columns.Add("Valor Lenguistico", typeof(string));


                dataGridCaracteristica.ItemsSource = dtColumnas.DefaultView;

                String queryInformacionCaracteristicas = "select c.nombre,  ic.valor, rc.valor_nivel_calidad, rc.nivel_calidad from caracteristica as c, incidencia_caracteristica as ic, resultado_caracteristica as rc where ic.id_subcategoria = "+id_subcategoria +" and rc.id_evaluacion_calidad = "+id_evaluacion+" and rc.id_caracteristica = c.id and ic.id_caracteristica = c.id group by c.nombre, ic.valor, rc.valor_nivel_calidad, rc.nivel_calidad;" ;
                NpgsqlCommand comandoInformacionCaracteristicasr = new NpgsqlCommand(queryInformacionCaracteristicas, conexion);


                NpgsqlDataReader drComandoInformacionCaracteristicasr = comandoInformacionCaracteristicasr.ExecuteReader();
                while (drComandoInformacionCaracteristicasr.Read())
                {
                    dtColumnas.Rows.Add(new object[] { drComandoInformacionCaracteristicasr[0].ToString(), drComandoInformacionCaracteristicasr[1].ToString(), drComandoInformacionCaracteristicasr[2].ToString(), drComandoInformacionCaracteristicasr[3].ToString() });

                }
            }
            catch
            {
                MessageBox.Show("Error en consultar el generar reporte caracteristica");
            }


            // seleccionar nivel calidad producto
            try
            {
                DataTable dtColumnas = new DataTable();
            
                dtColumnas.Columns.Add("Valor Final", typeof(string));
                dtColumnas.Columns.Add("Valor Lenguistico", typeof(string));


                dataGridNivelCalidadProducto.ItemsSource = dtColumnas.DefaultView;

                String queryInformacionCalidadFinal = "select valor_nivel_calidad, nivel_calidad from resultado_evaluacion_calidad where id_evaluacion_calidad = "+id_evaluacion+";";
                NpgsqlCommand comandoInformacionCalidadFinal= new NpgsqlCommand(queryInformacionCalidadFinal, conexion);


                NpgsqlDataReader drComandoInformacionCalidadFinal = comandoInformacionCalidadFinal.ExecuteReader();
                while (drComandoInformacionCalidadFinal.Read())
                {
                    dtColumnas.Rows.Add(new object[] { drComandoInformacionCalidadFinal[0].ToString(), drComandoInformacionCalidadFinal[1].ToString() });

                }
            }
            catch
            {
                MessageBox.Show("Error en consultar el generar reporte  final de calidad");
            }

            conexion.Close();
        }



    private double obtenerResultadoFormula(String formula, double A, double B)
    {
        double resultado = 0;
        if (formula.Equals("A/B"))
        {
            if (A == 0 || B == 0)
            {
                return 0;
            }
            resultado = A / B;
            return Math.Round(resultado, 2);
        }

        if (formula.Equals("A/T"))
            {
                if (A == 0 || B == 0)
                {
                    return 0;
                }
                resultado = A / B;
                return Math.Round(resultado, 2);
         }


            if (formula.Equals("A/T"))
            {
                if (A == 0 || B == 0)
                {
                    return 0;
                }
                resultado = A / B;
                return Math.Round(resultado, 2);
            }


            if (formula.Equals("1-(A/B)"))
            {
                if (B == 0)
                {
                    return 0;
                }
                resultado = 1 - (A / B);
                return Math.Round(resultado, 2);
            }

            if (formula.Equals("1-(A/N)"))
            {
                if (B == 0)
                {
                    return 0;
                }
                resultado = 1 - (A / B);
                return Math.Round(resultado, 2);
            }


            if (formula.Equals("T/A"))
            {
                if (B == 0)
                {
                    return 0;
                }
                resultado =  (A / B);
                return Math.Round(resultado, 2);
            }


            if (formula.Equals("A1/A2"))
            {
                if (B == 0)
                {
                    return 0;
                }
                resultado = 1 - (A / B);
                return Math.Round(resultado, 2);
            }

            if (formula.Equals("T/N"))
            {
                if (B == 0)
                {
                    return 0;
                }
                resultado = 1 - (A / B);
                return Math.Round(resultado, 2);
            }

            if (formula.Equals("SUM(T)/B"))
            {
                if (B == 0)
                {
                    return 0;
                }
                resultado = 1 - (A / B);
                return Math.Round(resultado, 2);
            }


            if (formula.Equals("Tc-Ts"))
            {
                
                resultado = A-B;
                return Math.Round(resultado, 2);
            }

            if (formula.Equals("T1-T2"))
            {

                resultado = A - B;
                return Math.Round(resultado, 2);
            }

            if (formula.Equals("Ta/Tb"))
            {

                resultado = A - B;
                return Math.Round(resultado, 2);
            }


            if (formula.Equals("S/T"))
            {
                if (B == 0)
                {
                    return 0;
                }
                resultado = 1 - (A / B);
                return Math.Round(resultado, 2);
            }
            return resultado;
    }

    // aplicar inserrta id evaluacion y retorna evaluacion
    private string insertaNuevaEvaluacion()
    {
        DateTime dt = DateTime.Now; // 
        string fecha = String.Format("{0:yyyy/MM/dd}", dt);

        NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
        conexion.Open();

        try
        {
            string queryInsertaEvaluacion = "INSERT INTO evaluacion_calidad(id, id_software, fecha_evaluacion, finalizado, id_subcategoria) VALUES ((select nextval('s_evaluacion_calidad')), '" + id_software + "' ,'" + fecha + "' ,'" + 0 + "','" + id_subcategoria + "');";

            Console.WriteLine(queryInsertaEvaluacion);
            NpgsqlCommand cmd = new NpgsqlCommand(queryInsertaEvaluacion, conexion);
            cmd.ExecuteNonQuery();
        }
        catch
        {
            Console.WriteLine("Error! en insertar el id de la nueva evaluacion");
                MessageBox.Show("ERROR DE ERRORES");
        }


        string id_ultima_evaluacion = null;
        try
        {
            String queryIDEvaluacion = "select last_value from s_evaluacion_calidad;";
            NpgsqlCommand comandoBuscaIDEvaluacion = new NpgsqlCommand(queryIDEvaluacion, conexion);


            NpgsqlDataReader drIDEvaluacion = comandoBuscaIDEvaluacion.ExecuteReader();
            while (drIDEvaluacion.Read())
            {
                id_ultima_evaluacion = drIDEvaluacion["last_value"].ToString();
            }
        }
        catch
        {
            Console.WriteLine("Error en consultar el ultimo ID de la evaluacion");
        }

        conexion.Close();
        return id_ultima_evaluacion;
    }

    private void insertarValoresMetricas(string id_evaluacion)
    {
        // conexion
        NpgsqlConnection conexion = new NpgsqlConnection(ParametrosConexionBD.BD);
        conexion.Open();

        for (int i = 0; i < cuestionarioMetricas.Count; i++)
        {
            Metrica unaMetrica = cuestionarioMetricas.ElementAt(i);
            try
            {
                //Console.WriteLine("ID: "+ unaMetrica.Id);
                //Console.WriteLine("A: " +unaMetrica.A1);
                //Console.WriteLine("B: " + unaMetrica.B1);
                //double a = double.Parse(unaMetrica.A1, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                //double b = double.Parse(unaMetrica.B1, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);

                double a;
                double.TryParse(unaMetrica.A1, NumberStyles.Any, CultureInfo.CreateSpecificCulture("en-US"), out a);

                double b;
                double.TryParse(unaMetrica.B1, NumberStyles.Any, CultureInfo.CreateSpecificCulture("en-US"), out b);
                //Console.WriteLine(string.Format("Local culture results for the parsing of {0} is {1}", unaMetrica.A1, localCultreResult));

                string queryInsertaResultadosMetricas = "INSERT INTO resultado_metrica(id, id_metrica, id_evaluacion_calidad, resultado, a , b) VALUES ((select nextval('s_resultado_metrica')), '" + unaMetrica.Id + "' ,'" + id_evaluacion + "', '" + obtenerResultadoFormula(unaMetrica.Formula, a, b) + "', '" + unaMetrica.A1 + "', '" + unaMetrica.B1 + "');";
                // MessageBox.Show(a + "");
                Console.WriteLine(queryInsertaResultadosMetricas);
                NpgsqlCommand cmd = new NpgsqlCommand(queryInsertaResultadosMetricas, conexion);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                  

                Console.WriteLine("Error! no se puede inserta el resultado de la metrica");
            }
        }
        conexion.Close();
    }

        private async Task<bool> encuentraError()
        {
            for (int i = 0; i < cuestionarioMetricas.Count; i++)
            {
                Metrica unaMetrica = cuestionarioMetricas.ElementAt(i);
                if (String.IsNullOrEmpty(unaMetrica.A1))
                {
                    await this.ShowMessageAsync("Campo Faltante", "Completar Campos Variable A");
                    //    MessageBox.Show("Error: Valor A: " + unaMetrica.A1);
                    return true;
                }

                if (String.IsNullOrEmpty(unaMetrica.B1))
                {
                    await this.ShowMessageAsync("Campo Faltante", "Completar Campos Variable B");
                    //MessageBox.Show("Error: Valor B: " + unaMetrica.B1);
                    return true;
                }
            }
            return false;
        }



        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        textBoxA.Text = slider.Value.ToString();
    }


    private void slider_Copy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        textBoxB.Text = slider_Copy.Value.ToString();
    }

    private void textBoxA_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (String.IsNullOrEmpty(textBoxA.Text))
        {
            cuestionarioMetricas.ElementAt(indice).A1 = "";
        } else
        {
            cuestionarioMetricas.ElementAt(indice).A1 = textBoxA.Text;

            //double A;
            //double B;
            //try
            //{
            //    A = Convert.ToDouble(cuestionarioMetricas.ElementAt(indice).A1);
            //    B = Convert.ToDouble(cuestionarioMetricas.ElementAt(indice).B1);
            //    Console.WriteLine("Converted '{0}' to {1}.", textBoxA.Text, A);

            //    double obtenerResultado = obtenerResultadoFormula(cuestionarioMetricas.ElementAt(indice).Formula, A, B);

            //    //textBoxR.Text = "hola";//obtenerResultado + "";
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("Unable to convert '{0}' to a Double.", textBoxA.Text);
            //}
            //catch (OverflowException)
            //{
            //    Console.WriteLine("'{0}' is outside the range of a Double.", textBoxA.Text);
            //}

        }
    }

        private void textBoxB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxB.Text))
            {
                cuestionarioMetricas.ElementAt(indice).B1 = "";
            }
            else
            {
                cuestionarioMetricas.ElementAt(indice).B1 = textBoxB.Text;

                // aplicar resultado 
                //double A = Double.Parse(textBoxA.Text, CultureInfo.InvariantCulture);
                //double B = Double.Parse(textBoxB.Text, CultureInfo.InvariantCulture);

                //MessageBox.Show(textBoxB.Text);

                //double A;
                //double B;
                //try
                //{
                //    A = Convert.ToDouble(cuestionarioMetricas.ElementAt(indice).A1);
                //    B = Convert.ToDouble(cuestionarioMetricas.ElementAt(indice).B1);
                //   // Console.WriteLine("Converted '{0}' to {1}.", textBoxA.Text, A);

                //    double obtenerResultado = obtenerResultadoFormula(cuestionarioMetricas.ElementAt(indice).Formula, A, B);
                //    //textBoxResultado.Text = obtenerResultado.ToString();
                //}
                //catch (FormatException)
                //{
                //    Console.WriteLine("Unable to convert '{0}' to a Double.", textBoxB.Text);
                //}
                //catch (OverflowException)
                //{
                //    Console.WriteLine("'{0}' is outside the range of a Double.", textBoxB.Text);
                //}


                //double obtenerResultado = obtenerResultadoFormula(cuestionarioMetricas.ElementAt(indice).Formula, A, B);
                //textBoxResultado.Text = obtenerResultado.ToString();
            }
        }

        private void textBoxResultado_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

      
    }
}
