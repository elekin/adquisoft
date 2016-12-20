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
using AdquisicionSoftware.Modulos.Metricas;
using Npgsql;
using Adquisoft.Constantes;

namespace Adquisoft.Modulos.Metricas
{
    /// <summary>
    /// Interaction logic for AgregarMetrica.xaml
    /// </summary>
    public partial class AgregarMetrica : MetroWindow
    {
        private DataGrid dataGridMetricas;

        public AgregarMetrica()
        {
            InitializeComponent();

            CargaComponentes();


        }

        public AgregarMetrica(DataGrid dataGridMetricas)
        {
            InitializeComponent();
            this.dataGridMetricas = dataGridMetricas;
            
        }



        private void CargaComponentes()
        {


            string primerRegistro = PrimerRegistroMetricas();
            CargaMetrica(primerRegistro);





        }


        private void CargaMetrica(string id_metrica)
        {
            Metrica m = ConsultaMetricasBD(id_metrica);


            text_id.Text = m.Id;
            textNombre.Text = m.Nombre;
            textProposito.Text = m.Proposito;
            textMetodo.Text = m.Metodo;
            textFormula.Text = m.Formula;
            textMejorValor.Text = m.MejorValor;
            textPeorValor.Text = m.PeorValor;
            textPerspectiva.Text = m.Perspectiva;
            textidSubcaracteristica.Text = m.SubCaracteristica;
            textVariables.Text = m.Variables;
            textDescripcionv1.Text = m.DescripcionA;
            textDescripcionv2.Text = m.DescripcionB;
        }




        private Metrica ConsultaMetricasBD(string idMetrica)
        {

            Metrica m = new Metrica();
                     

            string consulta = "select * from metrica where id = '" + idMetrica + "';";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            //informacion gral
            NpgsqlCommand comandoInfoMetrica = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drInfoMetrica = comandoInfoMetrica.ExecuteReader();

            while (drInfoMetrica.Read())
            {
                m.Id = drInfoMetrica["id"].ToString();
                m.Nombre = drInfoMetrica["nombre"].ToString();
                m.Proposito = drInfoMetrica["proposito"].ToString();
                m.Metodo = drInfoMetrica["metodo"].ToString();
                m.Formula = drInfoMetrica["formula"].ToString();
                m.MejorValor = drInfoMetrica["mejor_valor"].ToString();
                m.PeorValor = drInfoMetrica["peor_valor"].ToString();
                m.Perspectiva = drInfoMetrica["id_perspectiva"].ToString();
                m.SubCaracteristica = drInfoMetrica["id_subcaracteristica"].ToString();
                m.Variables = drInfoMetrica["variables"].ToString();
                m.DescripcionA = drInfoMetrica["descripcion_a"].ToString();
                m.DescripcionB = drInfoMetrica["descripcion_b"].ToString();

            }


            conexionBD.Close();

            return m;
        }


        private string PrimerRegistroMetricas()
        {
            string id_metrica = string.Empty;


            string consulta = "select id from metrica limit 1";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoIdMetrica = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drIdMetrica = comandoIdMetrica.ExecuteReader();

            while (drIdMetrica.Read())
            {
                //primer registro
                id_metrica = drIdMetrica["id"].ToString();

            }

            conexionBD.Close();


            return id_metrica;

        }



        /// <summary>
        /// Consulta el ultimo registro de metrica
        /// </summary>
        /// <returns>id</returns>
        private string UltimoRegistroProductoMetrica()
        {
            string id_ultimo_registro = string.Empty;

            string consulta = "SELECT id FROM metrica ORDER BY id  DESC LIMIT 1";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoIdMetrica = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drIdMetrica = comandoIdMetrica.ExecuteReader();

            while (drIdMetrica.Read())
            {
                //primer registro
                id_ultimo_registro = drIdMetrica["id"].ToString();

            }

            conexionBD.Close();


            return id_ultimo_registro;
        }

        /// <summary>
        /// Consulta el id siguiente registro 
        /// </summary>
        /// <param name="id_metrica"></param>
        /// <returns>id del siguiente registro</returns>
        public string SiguienteRegistroMetrica(string id_metrica)
        {
            string id_siguiente = string.Empty;

            string consulta = "SELECT id FROM metrica WHERE id> '" + id_metrica + "' ORDER BY id LIMIT 1; ";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoIdSoftware = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drIdSoftware = comandoIdSoftware.ExecuteReader();

            while (drIdSoftware.Read())
            {
                //siguiente registro
                id_siguiente = drIdSoftware["id"].ToString();

            }

            //si no hay mas registros vulve a comenzar desde el primero
            if (id_siguiente == string.Empty)
            {
                id_siguiente = PrimerRegistroMetricas();
            }

            conexionBD.Close();

            return id_siguiente;

        }



        /// <summary>
        /// Consulta el id anterior registro 
        /// </summary>
        /// <param name="id_metrica"></param>
        /// <returns>id</returns>
        public string AnteriorRegistroMetrica(string id_metrica)
        {
            string id_anterior = string.Empty;

            string consulta = "SELECT id FROM metrica WHERE id< '" + id_metrica + "' ORDER BY id DESC LIMIT 1; ";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoIdMetrica = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drIdMetrica = comandoIdMetrica.ExecuteReader();

            while (drIdMetrica.Read())
            {
                //siguiente registro
                id_anterior = drIdMetrica["id"].ToString();

            }

            //si no hay mas registros muestra el ultimo registro
            if (id_anterior == string.Empty)
            {
                id_anterior = UltimoRegistroProductoMetrica();
            }

            conexionBD.Close();

            return id_anterior;

        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {


           

            if (this.text_id.Text != string.Empty)
            {

                string siguiente_id = SiguienteRegistroMetrica(this.text_id.Text);
                CargaMetrica(siguiente_id);

            }

            
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {

            if (this.text_id.Text != string.Empty)
            {

                string anterior_id = AnteriorRegistroMetrica(this.text_id.Text);
                CargaMetrica(anterior_id);

            }

        }
    }
}
