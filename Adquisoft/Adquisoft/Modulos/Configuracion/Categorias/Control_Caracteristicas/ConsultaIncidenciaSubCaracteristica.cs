using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Caracteristicas
{
    class ConsultaIncidenciaSubCaracteristica : IncidenciaSubcaracteristica
    {

        public ConsultaIncidenciaSubCaracteristica(string id_subcategoria, string id_sub_caracteristica)
        {
            Id_subcaracteristica = id_sub_caracteristica;
            Id_subcategoria = id_subcategoria;
            LeerIncidenciaSubCaracteristica();
        }


        private void LeerIncidenciaSubCaracteristica()
        {

            string consulta = "SELECT id, valor  FROM incidencia_subcaracteristica WHERE id_subcategoria =  '" + this.Id_subcategoria + "' AND  id_subcaracteristica = '" + Id_subcaracteristica + "'; ";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoIncidenciaSubCaracteristica = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drIncidenciaSubCaracteristica = comandoIncidenciaSubCaracteristica.ExecuteReader();

            while (drIncidenciaSubCaracteristica.Read())
            {
                Id_incidencia_subcaracteristica = drIncidenciaSubCaracteristica["id"].ToString();
                Valor_incidencia = drIncidenciaSubCaracteristica["valor"].ToString();

            }

            conexionBD.Close();

        }

    }
}
