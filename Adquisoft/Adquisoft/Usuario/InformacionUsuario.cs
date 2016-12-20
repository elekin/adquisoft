using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Usuario
{
    class InformacionUsuario
    {


        private string id_usuario;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private string cargo;

        private string name_user;
        private string password;

        public string Id_usuario
        {
            get
            {
                return id_usuario;
            }

            set
            {
                id_usuario = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido1
        {
            get
            {
                return apellido1;
            }

            set
            {
                apellido1 = value;
            }
        }

        public string Apellido2
        {
            get
            {
                return apellido2;
            }

            set
            {
                apellido2 = value;
            }
        }

        public string Cargo
        {
            get
            {
                return cargo;
            }

            set
            {
                cargo = value;
            }
        }

        public string Name_user
        {
            get
            {
                return name_user;
            }

            set
            {
                name_user = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public InformacionUsuario(string nombreUsuario)
        {
            Consultaid_usario_password(nombreUsuario);
            Consulta_info_usuario(Id_usuario);


        }



        private void Consultaid_usario_password(string nombreUsuario)
        {
            string consulta = "select * from usuario where nombre_usuario = '" + nombreUsuario + "';";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            //consulta
            NpgsqlCommand comandoUser = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drNombreuser = comandoUser.ExecuteReader();

            while (drNombreuser.Read())
            {
                this.Id_usuario = drNombreuser["id"].ToString();
                this.Name_user = drNombreuser["nombre_usuario"].ToString();
                this.Password = drNombreuser["password"].ToString();
            }

            conexionBD.Close();
            
        }

        private void  Consulta_info_usuario(string id_usuario)
        {

            string consulta = "select * from perfil_usuario where id_usuario = '" + id_usuario + "';";

            NpgsqlConnection conexionBD = new NpgsqlConnection(ParametrosConexionBD.BD);
            conexionBD.Open();

            //consulta
            NpgsqlCommand comandoUser = new NpgsqlCommand(consulta, conexionBD);
            NpgsqlDataReader drNombreuser = comandoUser.ExecuteReader();

            while (drNombreuser.Read())
            {
                this.Nombre = drNombreuser["nombre"].ToString();
                this.Apellido1 = drNombreuser["apellido1"].ToString();
                this.Apellido2 = drNombreuser["apellido2"].ToString();
                this.Cargo = drNombreuser["cargo"].ToString();
            }

            conexionBD.Close();



        }


        







    }
}
