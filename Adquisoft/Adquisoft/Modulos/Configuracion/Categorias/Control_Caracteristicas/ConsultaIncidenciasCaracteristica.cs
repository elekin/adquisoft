using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Caracteristicas
{
    class ConsultaIncidenciasCaracteristica:IncidenciaCaracteristica
    {

      

        public ConsultaIncidenciasCaracteristica(string id_subcategoria, string id_caracteristica)
        {
            Id_caracteristica = id_caracteristica;
            Id_subcategoria = id_subcategoria;
            LeerIncidenciaCaracteristica();
        }


        private void  LeerIncidenciaCaracteristica()
        {            

            string consulta = "SELECT id, valor  FROM incidencia_caracteristica WHERE id_subcategoria = '" + this.Id_subcategoria + "' AND id_caracteristica = '"+ Id_caracteristica + "'; ";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoIncidenciaCaracteristica = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drIncidenciaCaracteristica = comandoIncidenciaCaracteristica.ExecuteReader();

            while (drIncidenciaCaracteristica.Read())
            {
                Id_incidenciaCaracteristica = drIncidenciaCaracteristica["id"].ToString();
                Valor_incidencia = drIncidenciaCaracteristica["valor"].ToString();             

               
            }

            conexionBD.Close();

            
        }
    }
}
