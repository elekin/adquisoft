using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Categorias
{
    class ConsultaCategoriaBD: Categoria
    {

        private string id_categoria;


        public ConsultaCategoriaBD(string id_categoria)
        {
            this.id_categoria = id_categoria;
            LeerRegistroCategoria();
        }


        public ConsultaCategoriaBD()
        {

        }






        private void LeerRegistroCategoria()
        {          

            Id_categoria = id_categoria;

            string consulta = "SELECT nombre, descripcion, ejemplo FROM categoria WHERE id_categoria = '"+ id_categoria+"'; ";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoCategorias = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drCategorias = comandoCategorias.ExecuteReader();

            while (drCategorias.Read())
            {
                
                Nombre_categoria = drCategorias["nombre"].ToString();
                Descripcion_categoria = drCategorias["descripcion"].ToString();
                Ejemplo_categoria = drCategorias["ejemplo"].ToString();

            }

            conexionBD.Close();

        }


        public string LeerIdCategoria(string nombreCategoria)
        {
            string id_categoria = string.Empty;

            string consulta = "SELECT id_categoria FROM categoria WHERE nombre = '" + nombreCategoria + "'; ";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoCategoria = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drCategoria = comandoCategoria.ExecuteReader();

            while (drCategoria.Read())
            {

                id_categoria = drCategoria["id_categoria"].ToString();
                

            }

            conexionBD.Close();




            return id_categoria;
        }

        


    }
}
