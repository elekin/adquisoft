using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Caracteristicas
{
    class RegistraSubcategoria :  Control_Categorias.SubCategoria
    {

        private bool nuevoRegistro;

        public RegistraSubcategoria(string idSubcategoria, string nombreSubcategoria,string idCategoria, string descripcion,bool nuevo_registro)
        {
            this.nuevoRegistro = nuevo_registro;
            Id_subcategoria = idSubcategoria;
            Nombre_subcategoria = nombreSubcategoria;
            Id_categoria = idCategoria;
            Descripcion_subcategoria = descripcion;
           
            
        }



        public bool RegistraSubcategoriaBD()
        {

            try
            {

                //consultas
                string comandoSQLInformacionSubcategoria;

                //conecta BD
                NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
                conexionBD.Open();

                //verifica si es un nuevo registro o es una actualización
                if (!nuevoRegistro)
                {
                    //actualiza Información Subcategoria
                    comandoSQLInformacionSubcategoria = "UPDATE subcategoria SET nombre = '" + Nombre_subcategoria + "', id_categoria ='" + Id_categoria + "', descripcion ='" + Descripcion_subcategoria + "' WHERE id ='" + Id_subcategoria + "'; ";

                }
                else
                {
                    //registra Información Subcategoria
                    comandoSQLInformacionSubcategoria = "INSERT INTO subcategoria(id, nombre, id_categoria, descripcion) VALUES((select nextval('s_subcategoria')),'" + Nombre_subcategoria + "','" + Id_categoria + "','" + Descripcion_subcategoria + "');";


                }


                NpgsqlCommand comandoInformacionGral = new NpgsqlCommand(comandoSQLInformacionSubcategoria, conexionBD);
                comandoInformacionGral.ExecuteNonQuery();


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
