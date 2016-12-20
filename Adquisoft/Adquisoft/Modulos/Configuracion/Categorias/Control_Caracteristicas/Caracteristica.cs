using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Caracteristicas
{
    class Caracteristica
    {

        private string id_caracteristica;
        private string nombre_caracteristica;
        private string descripcion;

        public string Id_caracteristica
        {
            get
            {
                return id_caracteristica;
            }

            set
            {
                id_caracteristica = value;
            }
        }

        public string Nombre_caracteristica
        {
            get
            {
                return nombre_caracteristica;
            }

            set
            {
                nombre_caracteristica = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
    }
}
