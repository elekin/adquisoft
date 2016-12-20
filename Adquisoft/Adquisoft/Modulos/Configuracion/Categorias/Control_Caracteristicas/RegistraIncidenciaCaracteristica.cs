using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Caracteristicas
{
    class RegistraIncidenciaCaracteristica : IncidenciaCaracteristica
    {

        private bool nuevoRegistro;

        public RegistraIncidenciaCaracteristica(string id_subcategoria, string id_caracteristica, string valor, bool nuevoRegistro)
        {

            this.Id_subcategoria = id_subcategoria;
            this.Id_caracteristica = id_caracteristica;
            this.Valor_incidencia = valor;
            this.nuevoRegistro = nuevoRegistro;


           

        }



        public bool RegistraIncidenciaCaracteristicaBD()
        {
            try
            {
                //consultas
                string comandoSQLIncidenciaCaracteristica;

                //conecta BD
                NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
                conexionBD.Open();

                //verifica si es un nuevo registro o es una actualización
                if (!nuevoRegistro)
                {
                    //Actualiza Incidencias Caracteristicas
                    //comandoSQLIncidenciaCaracteristica = "UPDATE incidencia_caracteristica SET valor = '" + Valor_incidencia + "' WHERE id_subcategoria = '" + Id_subcategoria + "'  AND  id_caracteristica = '" + Id_caracteristica + "';";


                    string comandoSQL_eliminarIncidencia = "DELETE FROM incidencia_caracteristica WHERE id_subcategoria ='" + Id_subcategoria + "; ";

                    NpgsqlCommand comandoEliminarIncidencia = new NpgsqlCommand(comandoSQL_eliminarIncidencia, conexionBD);
                    comandoEliminarIncidencia.ExecuteNonQuery();

                }
              



                    //registra Incidencias Caracteristicas
                    comandoSQLIncidenciaCaracteristica = "INSERT INTO incidencia_caracteristica(id, id_subcategoria, id_caracteristica, valor) VALUES((select nextval('s_incidencia_caracteristica')),'" + Id_subcategoria + "','" + Id_caracteristica + "','" + Valor_incidencia + "');";

                



                NpgsqlCommand comandoIncidenciasCaracteristicas = new NpgsqlCommand(comandoSQLIncidenciaCaracteristica, conexionBD);
                comandoIncidenciasCaracteristicas.ExecuteNonQuery();

                conexionBD.Close();  //cierra conexión

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }




    }
}
