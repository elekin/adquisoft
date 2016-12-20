using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Caracteristicas
{
    class IncidenciaSubcaracteristica
    {
        private string id_incidencia_subcaracteristica;
        private string id_subcategoria;
        private string id_subcaracteristica;
        private string valor_incidencia;

        public string Id_incidencia_subcaracteristica
        {
            get
            {
                return id_incidencia_subcaracteristica;
            }

            set
            {
                id_incidencia_subcaracteristica = value;
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
