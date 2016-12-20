using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Caracteristicas
{
    class IncidenciaCaracteristica
    {
        private string id_incidenciaCaracteristica;
        private string id_subcategoria;
        private string id_caracteristica;
        private string valor_incidencia;

        public string Id_incidenciaCaracteristica
        {
            get
            {
                return id_incidenciaCaracteristica;
            }

            set
            {
                id_incidenciaCaracteristica = value;
            }
        }

        public string Id_subcategoria
        {
            get
            {
                return id_subcategoria;
            }

            set
            {
                id_subcategoria = value;
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

        public string Valor_incidencia
        {
            get
            {
                return valor_incidencia;
            }

            set
            {
                valor_incidencia = value;
            }
        }
    }
}
