using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.producto_sw
{
    class RegistraSoftwareBD: Software
    {


        /// <summary>
        /// Registra o actualiza un producto de software en la BD
        /// </summary>
        /// <param name="sw">datos a registrar</param>
        /// <param name="actualizaRegistro">indica si se registrara un nuevo sw (actualizaRegistro = false) o se actualizará uno existente (actualizaRegistro = true)</param>
        public RegistraSoftwareBD(Software sw, bool NuevoRegistro)
        {

            this.Id = sw.Id;
            //información gral de un sw
            this.Nombre_producto = sw.Nombre_producto;
            this.Version = sw.Version;
            this.Desarrollador = sw.Desarrollador;
            this.Licencia = sw.Licencia;
            this.Manual_usuario = sw.Manual_usuario;
            this.Categoria = sw.Categoria;
            this.Subcategoria = sw.Subcategoria;
            this.Descripcion = sw.Descripcion;
            //requerimientos de sistema min
            this.Sistema_operativo = sw.Sistema_operativo;
            this.Procesador = sw.Procesador;
            this.Rom = sw.Rom;
            this.Ram = sw.Ram;
            this.Tarjeta_grafica = sw.Tarjeta_grafica;
            this.Hw_sw_add = sw.Hw_sw_add;
            //costos
            this.C_adquisicion = sw.C_adquisicion;
            this.C_suscripcion = sw.C_suscripcion;
            this.Periodo_pago = sw.Periodo_pago;
            this.C_capacitacion = sw.C_capacitacion;
            this.C_hwSwAdd = sw.C_hwSwAdd;

            //  si NuevoRegistro = true: registra un nuevo registro
            if (NuevoRegistro)
            {
                RegistraNuevoSw_BD(NuevoRegistro);
            }
            else    //si se esta actualizando un registro en la BD (update)
            {
                RegistraNuevoSw_BD(NuevoRegistro);
            }

            

        }

        
        /// <summary>
        /// Consulta a la bd el id que corresponde al tipo de licencia
        /// </summary>
        /// <param name="tipo_licencia"></param>
        /// <returns>id</returns>
        private string BuscaIdLicencia(string tipo_licencia)
        {
            string id_licencia = string.Empty;
            string consulta = "select id from licencia where tipo ='"+tipo_licencia+"';";
            //conecta BD
            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();            
            NpgsqlCommand comandoLicencia = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drLicencia = comandoLicencia.ExecuteReader();


            while (drLicencia.Read())
            {
                id_licencia = drLicencia["id"].ToString();
            }

                conexionBD.Close();  //cierra conexión BD
            return id_licencia;
        }

        /// <summary>
        /// Consulta a la bd el id correspondiente a la categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>id categoria</returns>
        private string BuscaIdCategoria(string categoria)
        {
            string id_categoria = "";
            string consulta = "select id_categoria from categoria where nombre = '"+categoria+"';";

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

        /// <summary>
        /// Consulta en la BD el id correspondiente a la subcategoria
        /// </summary>
        /// <param name="subcategoria"></param>
        /// <returns>id subcategoria</returns>
        private string BuscaIdSubcategoria(string subcategoria)
        {
            string id_Subcategoria = string.Empty;
            string consulta = "select id from subcategoria where nombre = '"+subcategoria+"';";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();
            NpgsqlCommand comandoSubCategoria = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drSubCategoria = comandoSubCategoria.ExecuteReader();


            while (drSubCategoria.Read())
            {
                id_Subcategoria = drSubCategoria["id"].ToString();
            }

            conexionBD.Close();


            return id_Subcategoria;
        }

        /// <summary>
        /// Consulta en la BD el id correspondiente al sistema operativo
        /// </summary>
        /// <param name="so"></param>
        /// <returns>id sistema operativo</returns>
        private string BuscaIdSistemaOperativo(string so)
        {
            string id_sistemaoperativo = string.Empty;
            string consulta = "select id from sistema_operativo where nombre = '" + so + "';";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();
            NpgsqlCommand comandoSistemaOperativo = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drSistemaOperativo = comandoSistemaOperativo.ExecuteReader();


            while (drSistemaOperativo.Read())
            {
                id_sistemaoperativo = drSistemaOperativo["id"].ToString();
            }

            conexionBD.Close();


            return id_sistemaoperativo;
        }


        /// <summary>
        /// Busca en la BD el id correspondiente al periodo de pago
        /// </summary>
        /// <param name="periodopago"></param>
        /// <returns>id periodo de pago</returns>
        private string BuscaIdPeriodoPago(string periodopago)
        {
            string idperiodopago=string.Empty;
            string consulta = "select id from periodo_pago where periodo = '" + periodopago + "';";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();
            NpgsqlCommand comandoPeriodoPago = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drPeriodoPago = comandoPeriodoPago.ExecuteReader();


            while (drPeriodoPago.Read())
            {
                idperiodopago = drPeriodoPago["id"].ToString();
            }

            conexionBD.Close();


            return idperiodopago;
        }



        /// <summary>
        /// Registra un nuevo producto de software en la BD o lo Actualiza
        /// </summary>
        /// <param name="RegistraNuevoSw">Indica si el registro es un nuevo registro o es una actualización</param>
        private void RegistraNuevoSw_BD(bool RegistraNuevoSw)
        {
            
            //consulta sql registro informacion gral
            string comandoSQLInformacionGral;
            string comandoSQLRequerimientosmin;
            string comandoSQLCostos;


            //rescata id licencia
            string id_licencia = BuscaIdLicencia(Licencia);         
            
            //rescata id categoria            
            string idCategoria = BuscaIdCategoria(Categoria);
            //rescata id de la subcategoria
            string id_subcategoria = BuscaIdSubcategoria(Subcategoria);
            //rescata id sistema operativo
            string id_so = BuscaIdSistemaOperativo(Sistema_operativo);
            //rescata id periodo pago
            string id_periodoPago = BuscaIdPeriodoPago(Periodo_pago);

            //conecta BD
            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            //verifica si es un nuevo registro o es una actualización
            if (!RegistraNuevoSw)
            {
                //registra informacion gral
                comandoSQLInformacionGral = "UPDATE software SET nombre_producto ='"+ Nombre_producto + "', version ='"+ Version + "', desarrollador ='"+ Desarrollador + "', id_licencia ='"+ id_licencia + "', descripcion ='"+ Descripcion + "', id_subcategoria ='"+ id_subcategoria + "', manual_usuario ='"+ Manual_usuario + "' WHERE id = '"+Id+"'; ";
                //registra requerimientos min
                comandoSQLRequerimientosmin = "UPDATE requerimientos_minimos_sistema  SET  procesador ='"+ Procesador + "', rom ='"+ Rom + "', ram ='"+ Ram + "', tarjeta_grafica ='"+ Tarjeta_grafica + "', hw_adicional ='"+ Hw_sw_add + "', id_so ='"+ id_so + "'  WHERE id_software = '"+ Id + "' ;";
                //registra costos
                comandoSQLCostos = "UPDATE costo SET  hw_sw_adicional ='"+ C_hwSwAdd + "', capacitacion ='"+ C_capacitacion + "', suscripcion ='"+ C_suscripcion + "', adquisicion ='"+ C_adquisicion + "',id_periodo_pago ='"+ id_periodoPago + "'  WHERE id_software = '"+ Id + "';";
            }
            else
            {
                //registra informacion gral
                comandoSQLInformacionGral = "INSERT INTO software(id, nombre_producto, version, desarrollador, id_licencia, descripcion,manual_usuario, id_subcategoria) VALUES ((select nextval('s_software')),'" + Nombre_producto + "','" + Version + "','" + Desarrollador + "','" + id_licencia + "','" + Descripcion + "','" + Manual_usuario + "','" + id_subcategoria + "');";
                //registra requerimientos min
                comandoSQLRequerimientosmin = "INSERT INTO requerimientos_minimos_sistema(id, procesador, rom, ram, tarjeta_grafica, hw_adicional, id_so,id_software) VALUES((select nextval('s_requerimientosmin')),'" + Procesador + "','" + Rom + "','" + Ram + "','" + Tarjeta_grafica + "','" + Hw_sw_add + "','" + id_so + "','" + Id + "'); ";
                //registra costos
                comandoSQLCostos = "INSERT INTO costo(id, hw_sw_adicional, capacitacion, suscripcion, adquisicion,id_periodo_pago, id_software) VALUES((select nextval('s_costos')),'" + C_hwSwAdd + "','" + C_capacitacion + "','" + C_suscripcion + "','" + C_adquisicion + "','" + id_periodoPago + "','" + Id + "');";

            }

            
            NpgsqlCommand comandoInformacionGral = new NpgsqlCommand(comandoSQLInformacionGral, conexionBD);
            comandoInformacionGral.ExecuteNonQuery();            

            NpgsqlCommand comandoRequerimientosMin = new NpgsqlCommand(comandoSQLRequerimientosmin, conexionBD);
            comandoRequerimientosMin.ExecuteNonQuery();           

            NpgsqlCommand comandoCostos = new NpgsqlCommand(comandoSQLCostos, conexionBD);
            comandoCostos.ExecuteNonQuery();

            conexionBD.Close();  //cierra conexión
            
        }   








    }
}
