using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Categorias
{
    class SubCategoria
    {
        private string id_subcategoria = string.Empty;
        private string nombre_subcategoria = string.Empty;
        private string id_categoria = string.Empty;
        private string descripcion_subcategoria = string.Empty;

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

        public string Nombre_subcategoria
        {
            get
            {
                return nombre_subcategoria;
            }

            set
            {
                nombre_subcategoria = value;
            }
        }

        public string Id_categoria
        {
            get
            {
                return id_categoria;
            }

            set
            {
                id_categoria = value;
            }
        }

        public string Descripcion_subcategoria
        {
            get
            {
                return descripcion_subcategoria;
            }

            set
            {
                descripcion_subcategoria = value;
            }
        }
    }
}
