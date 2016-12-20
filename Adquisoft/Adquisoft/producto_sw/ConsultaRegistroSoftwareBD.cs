using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.producto_sw
{
    class ConsultaRegistroSoftwareBD:Software
    {      
        
       
       
      


        /// <summary>
        /// Lee información de un Producto de software: Información general, Requerimientos
        /// minimos de sistema y Costos
        /// </summary>
        public void LeerRegistroSwBD(string id_software)
        {
            

            string consulta = "select * from software where id = '" + id_software + "';";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            //informacion gral
            NpgsqlCommand comandoInfoSoftware = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drInfoSoftware = comandoInfoSoftware.ExecuteReader();

            while (drInfoSoftware.Read())
            {
                //información general
                Id = drInfoSoftware["id"].ToString();
                Nombre_producto = drInfoSoftware["nombre_producto"].ToString();
                Version = drInfoSoftware["version"].ToString();
                Desarrollador = drInfoSoftware["desarrollador"].ToString();
                Licencia = LeerTipoLicencia(drInfoSoftware["id_licencia"].ToString());  //realizar consulta para recuperar el nombre
                Descripcion = drInfoSoftware["descripcion"].ToString();

                Categoria = LeerNombreCategoriaDeSubcategoria(drInfoSoftware["id_subcategoria"].ToString()); //Consulta por el nombre de la categoria a la que pertenece la subcategoria

                Subcategoria = LeerNombreSubCategoria(drInfoSoftware["id_subcategoria"].ToString());   //recupera nombre de la subcategoria
                Manual_usuario = drInfoSoftware["manual_usuario"].ToString();               
                
                
            }
            
            //requerimientos min sistema
            consulta = "select * from requerimientos_minimos_sistema where id_software = '"+ id_software + "';";
            NpgsqlCommand comandoReqMinSoftware = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drReqMinSoftware = comandoReqMinSoftware.ExecuteReader();


            while (drReqMinSoftware.Read())
            {
                //información de requerimientos mínimos
                Sistema_operativo = LeerNombreSistemaOperativo(drReqMinSoftware["id_so"].ToString());
                Procesador = drReqMinSoftware["procesador"].ToString();
                Rom = drReqMinSoftware["rom"].ToString();
                Ram = drReqMinSoftware["ram"].ToString();
                Tarjeta_grafica = drReqMinSoftware["tarjeta_grafica"].ToString();
                Hw_sw_add = drReqMinSoftware["hw_adicional"].ToString();
            }
            
            //info costos
            consulta = "select * from costo where id_software = '"+ id_software + "';";
            NpgsqlCommand comandoCostos = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drCostos = comandoCostos.ExecuteReader();


            while (drCostos.Read())
            {
                //costos
                C_adquisicion = drCostos["adquisicion"].ToString();
                C_suscripcion = drCostos["suscripcion"].ToString();
                Periodo_pago = LeerPeriodoPago(drCostos["id_periodo_pago"].ToString());  //recupera nombre periodo pago
                C_capacitacion = drCostos["capacitacion"].ToString();
                C_hwSwAdd = drCostos["hw_sw_adicional"].ToString();
            }
            
                conexionBD.Close();
            
        }


        /// <summary>
        /// Consulta a la BD el tipo de licencia que tiene un producto de sw, dado el id
        /// de la Licencia.
        /// </summary>
        /// <param name="id_licencia"></param>
        /// <returns>Tipo de Licencia</returns>
        private string LeerTipoLicencia(string id_licencia)
        {
            string tipo_licencia = string.Empty;

            string consulta = "select tipo from licencia where id = '" + id_licencia + "';";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            //consulta
            NpgsqlCommand comandoTipoLicencia = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drTipoLicencia = comandoTipoLicencia.ExecuteReader();

            while (drTipoLicencia.Read())
            {
                tipo_licencia = drTipoLicencia["tipo"].ToString();
            }

            conexionBD.Close();
                return tipo_licencia;
        }

        /// <summary>
        /// Consulta el nombre de la subcategoria en la BD dado su id
        /// </summary>
        /// <param name="id_subcategoria"></param>
        /// <returns>nombre de la subcategoria</returns>
        private string LeerNombreSubCategoria(string id_subcategoria)
        {
            string nombre_categoria = string.Empty;

            string consulta = "select nombre from subcategoria where id = '" + id_subcategoria + "';";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            //consulta
            NpgsqlCommand comandoSubCategoria = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drNombreSubcategoria = comandoSubCategoria.ExecuteReader();

            while (drNombreSubcategoria.Read())
            {
                nombre_categoria = drNombreSubcategoria["nombre"].ToString();
            }

            conexionBD.Close();


            return nombre_categoria;

        }


        /// <summary>
        /// Lee el nombre de la categoria a la cual pertenece el id de una subcategoria
        /// </summary>
        /// <param name="id_subcategoria"></param>
        /// <returns>nombre de la categoria</returns>
        private string LeerNombreCategoriaDeSubcategoria(string id_subcategoria)
        {
            string nombre_categoria = string.Empty;

            string consulta = "select nombre from categoria where id_categoria =  (select id_categoria from subcategoria where id ='" + id_subcategoria + "');";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            //consulta
            NpgsqlCommand comandoCategoria = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drNombrecategoria = comandoCategoria.ExecuteReader();

            while (drNombrecategoria.Read())
            {
                nombre_categoria = drNombrecategoria["nombre"].ToString();
            }

            conexionBD.Close();


            return nombre_categoria;
        }


        /// <summary>
        /// Consulta el nombre del sistema operativo en la bd dado su id
        /// </summary>
        /// <param name="id_so"></param>
        /// <returns>nombre sistema operativo</returns>
        private string LeerNombreSistemaOperativo(string id_so)
        {
            string nombre_so=string.Empty;

            string consulta = "select nombre from sistema_operativo where id = '" + id_so + "';";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            //consulta
            NpgsqlCommand comandoSistemaOperativo = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drNombreSistemaOperativo = comandoSistemaOperativo.ExecuteReader();

            while (drNombreSistemaOperativo.Read())
            {
                nombre_so = drNombreSistemaOperativo["nombre"].ToString();
            }

            conexionBD.Close();


            return nombre_so;
        }

        /// <summary>
        /// Consulta el periodo de pago en la BD, dado su id
        /// </summary>
        /// <param name="id_periodoPago"></param>
        /// <returns>Periodo de pago</returns>
        private string LeerPeriodoPago(string id_periodoPago)
        {
            string periodoPago = string.Empty;

            string consulta = "select periodo from periodo_pago where id = '" + id_periodoPago + "';";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            //consulta
            NpgsqlCommand comandoPeriodoPago = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drPeriodoPago = comandoPeriodoPago.ExecuteReader();

            while (drPeriodoPago.Read())
            {
                periodoPago = drPeriodoPago["periodo"].ToString();
            }

            conexionBD.Close();


            return periodoPago;
        }

        
        /// <summary>
        /// Consulta el primer id de un sw en la bd
        /// </summary>
        /// <returns>id</returns>
        public string PrimerRegistroProductoSw()
        {
            string id_sw = string.Empty;

            string consulta = "select id from software limit 1";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();
           
            NpgsqlCommand comandoIdSoftware = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drIdSoftware = comandoIdSoftware.ExecuteReader();

            while (drIdSoftware.Read())
            {
                //primer registro
                id_sw = drIdSoftware["id"].ToString();            
                
            }

            conexionBD.Close();


            return id_sw;
        }


        /// <summary>
        /// Consulta el ultimo registro de sw
        /// </summary>
        /// <returns>id</returns>
        public string UltimoRegistroProductoSw()
        {
            string id_ultimo_registro=string.Empty;

            string consulta = "SELECT id FROM software ORDER BY id  DESC LIMIT 1";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoIdSoftware = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drIdSoftware = comandoIdSoftware.ExecuteReader();

            while (drIdSoftware.Read())
            {
                //primer registro
                id_ultimo_registro = drIdSoftware["id"].ToString();

            }

            conexionBD.Close();


            return id_ultimo_registro;
        }

        /// <summary>
        /// Consulta el id siguiente registro de un producto de sw en la BD
        /// </summary>
        /// <param name="id_software"></param>
        /// <returns>id del siguiente registro</returns>
        public string SiguienteRegistroProductoSw(string id_software)
        {
            string id_siguiente = string.Empty;           

            string consulta = "SELECT id FROM software WHERE id> '" + id_software + "' ORDER BY id LIMIT 1; ";

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
                id_siguiente = PrimerRegistroProductoSw();
            }

            conexionBD.Close();

            return id_siguiente;

        }

        /// <summary>
        /// Consulta el id anterior registro de un producto de sw en la BD
        /// </summary>
        /// <param name="id_software"></param>
        /// <returns>id</returns>
        public string AnteriorRegistroProductoSw(string id_software)
        {
            string id_anterior = string.Empty;

            string consulta = "SELECT id FROM software WHERE id< '" + id_software + "' ORDER BY id DESC LIMIT 1; ";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            NpgsqlCommand comandoIdSoftware = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drIdSoftware = comandoIdSoftware.ExecuteReader();

            while (drIdSoftware.Read())
            {
                //siguiente registro
                id_anterior = drIdSoftware["id"].ToString();

            }

            //si no hay mas registros muestra el ultimo registro
            if (id_anterior == string.Empty)
            {
                id_anterior = UltimoRegistroProductoSw();
            }

            conexionBD.Close();

            return id_anterior;

        }
        
    }
}
