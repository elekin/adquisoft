using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Usuario
{
    public class Permisos_usuario
    {

        private string nombre_usuario;
        private bool permiso_administracion;
        private bool permiso_perfil_usuario;
        private bool registro_software;
        private bool evaluacion_calidad;
        private bool evaluacion_adquisicion;
        private bool configuracion;
        private bool informes_evaluacion;


        public Permisos_usuario(string usuario)
        {
            this.nombre_usuario = usuario;
            this.permiso_administracion = true;  //cambiar x consulta BD
            this.permiso_perfil_usuario = true;
            this.registro_software = true;
            this.evaluacion_calidad = true;
            this.evaluacion_adquisicion = true;
            this.configuracion = true;
            this.informes_evaluacion =true;

    }

        public string Nombre_usuario
        {
            get
            {
                return nombre_usuario;
            }

            set
            {
                nombre_usuario = value;
            }
        }

        public bool Permiso_administracion
        {
            get
            {
                return permiso_administracion;
            }

            set
            {
                permiso_administracion = value;
            }
        }

        public bool Permiso_perfil_usuario
        {
            get
            {
                return permiso_perfil_usuario;
            }

            set
            {
                permiso_perfil_usuario = value;
            }
        }

        public bool Registro_software
        {
            get
            {
                return registro_software;
            }

            set
            {
                registro_software = value;
            }
        }

        public bool Evaluacion_calidad
        {
            get
            {
                return evaluacion_calidad;
            }

            set
            {
                evaluacion_calidad = value;
            }
        }

        public bool Evaluacion_adquisicion
        {
            get
            {
                return evaluacion_adquisicion;
            }

            set
            {
                evaluacion_adquisicion = value;
            }
        }

        public bool Configuracion
        {
            get
            {
                return configuracion;
            }

            set
            {
                configuracion = value;
            }
        }

        public bool Informes_evaluacion
        {
            get
            {
                return informes_evaluacion;
            }

            set
            {
                informes_evaluacion = value;
            }
        }
    }
}
