using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Caracteristicas
{
    class ConsultaCaracteristicaBD : Caracteristica
    {

        



        public ConsultaCaracteristicaBD(string _id_caracteristica)
        {
            Id_caracteristica = _id_caracteristica;
            LeerCaracteristicaBD();
        }





        private void LeerCaracteristicaBD()
        {
            

            string consulta = "SELECT nombre, descripcion FROM caracteristica WHERE id = '" + Id_caracteristica + "'; ";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoCaracteristicas = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drCaracteristicas = comandoCaracteristicas.ExecuteReader();

            while (drCaracteristicas.Read())
            {

                Nombre_caracteristica = drCaracteristicas["nombre"].ToString();
                Descripcion = drCaracteristicas["descripcion"].ToString();
                

            }

            conexionBD.Close();
        }
    }
}
