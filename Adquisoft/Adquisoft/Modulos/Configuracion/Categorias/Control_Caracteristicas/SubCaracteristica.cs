using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Caracteristicas
{
    class SubCaracteristica
    {

        private string id_subcaracteristica;
        private string nombre_subcaracteristica;
        private string descripcion_subcaracteristica;
        private string id_caracteristica;

        public string Id_subcaracteristica
        {
            get
            {
                return id_subcaracteristica;
            }

            set
            {
                id_subcaracteristica = value;
            }
        }

        public string Nombre_subcaracteristica
        {
            get
            {
                return nombre_subcaracteristica;
            }

            set
            {
                nombre_subcaracteristica = value;
            }
        }

        public string Descripcion_subcaracteristica
        {
            get
            {
                return descripcion_subcaracteristica;
            }

            set
            {
                descripcion_subcaracteristica = value;
            }
        }

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
    }
}
