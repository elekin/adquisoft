using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Caracteristicas
{
    class RegistraIncidenciaSubCaracteristica: IncidenciaSubcaracteristica
    {
        private bool nuevoRegistro;
        
        public RegistraIncidenciaSubCaracteristica(string id_subcategoria,string id_subcaracteristica, string valor, bool nuevoRegistro)
        {
            //Id_incidencia_subcaracteristica = SiguienteRegistroIncidenciaSubcaracteristica();
            Id_subcategoria = id_subcategoria;
            Id_subcaracteristica = id_subcaracteristica;
            Valor_incidencia = valor;

            this.nuevoRegistro = nuevoRegistro;            


        }



        public bool RegistrarIncidenciaSubcaracteristicaBD()
        {
            bool exito = false;
            try
            {
                //consultas
                string comandoSQLIncidenciaSubcaracteristica;

                //conecta BD
                NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
                conexionBD.Open();

                //verifica si es un nuevo registro o es una actualización
                if (!nuevoRegistro)
                {


                //elimina las incidencias de la bd

                string comandoSQL_eliminarIncidencia = "DELETE FROM incidencia_subcaracteristica WHERE id_subcategoria ='" + Id_subcategoria+ "'; ";

                NpgsqlCommand comandoEliminarIncidencia = new NpgsqlCommand(comandoSQL_eliminarIncidencia, conexionBD);
                comandoEliminarIncidencia.ExecuteNonQuery();



                //Actualiza Incidencias Subcaracteristicas
                //comandoSQLIncidenciaSubcaracteristica = "UPDATE incidencia_subcaracteristica SET valor = '" + Valor_incidencia + "' WHERE id_subcategoria ='" + Id_subcategoria + "' AND id_subcaracteristica = '" + Id_subcaracteristica + "'; ";

                }


            //registra Incidencias Subcaracteristicas
            comandoSQLIncidenciaSubcaracteristica = "INSERT INTO incidencia_subcaracteristica(id, id_subcategoria, id_subcaracteristica, valor) VALUES((select nextval('s_incidencia_subcaracteristica')),'" + Id_subcategoria + "','" + Id_subcaracteristica + "','" + Valor_incidencia + "'); ";

            
            NpgsqlCommand comandoIncidenciaSubcaracteristica = new NpgsqlCommand(comandoSQLIncidenciaSubcaracteristica, conexionBD);
            comandoIncidenciaSubcaracteristica.ExecuteNonQuery();

                conexionBD.Close();  //cierra conexión

                exito = true;
                return exito;
          }
            catch (Exception)
            {
                return exito;
                throw;
            }

            
        }

        /*
        private string SiguienteRegistroIncidenciaSubcaracteristica()
        {
            string id_siguiente = string.Empty;
            //



            return id_siguiente;
        }*/

    }
}
