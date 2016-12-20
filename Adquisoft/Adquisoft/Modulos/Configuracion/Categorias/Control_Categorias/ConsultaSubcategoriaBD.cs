using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Categorias
{
    class ConsultaSubcategoriaBD : SubCategoria
    {

        private string id_sub_categoria;

        public ConsultaSubcategoriaBD(string id_sub_categoria)
        {
            this.id_sub_categoria =  id_sub_categoria;
            LeerRegistroCategoria();
        }

        
        private void LeerRegistroCategoria()
        {

            Id_subcategoria = this.id_sub_categoria;

            string consulta = "SELECT nombre, id_categoria, descripcion FROM subcategoria WHERE id =  '" + id_sub_categoria + "'; ";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoSubCategorias = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drSubCategorias = comandoSubCategorias.ExecuteReader();

            while (drSubCategorias.Read())
            {

                Nombre_subcategoria = drSubCategorias["nombre"].ToString();
                Descripcion_subcategoria = drSubCategorias["descripcion"].ToString();
                Id_categoria = drSubCategorias["id_categoria"].ToString();

            }

            conexionBD.Close();

        }
    }
}
