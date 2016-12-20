using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Caracteristicas
{
    class ConsultaSubcaracteristicaBD: SubCaracteristica
    {


        public ConsultaSubcaracteristicaBD(string id_subcaracteristica)
        {
            Id_subcaracteristica = id_subcaracteristica;
            LeerNombreCaracteristicaBD(id_subcaracteristica);
        }


        private void LeerNombreCaracteristicaBD(string id_subcaracteristica)
        {


            string consulta = "SELECT nombre, descripcion FROM subcaracteristica WHERE id = '" + Id_subcaracteristica + "'; ";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoCaracteristicas = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drCaracteristicas = comandoCaracteristicas.ExecuteReader();

            while (drCaracteristicas.Read())
            {

                Nombre_subcaracteristica = drCaracteristicas["nombre"].ToString();
                Descripcion_subcaracteristica = drCaracteristicas["descripcion"].ToString();


            }

            conexionBD.Close();
        }

    }
}
