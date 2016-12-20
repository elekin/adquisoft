using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Modulos.Configuracion.Categorias.Control_Categorias
{
    class Categoria
    {

        private string id_categoria;
        private string nombre_categoria;
        private string descripcion_categoria;
        private string ejemplo_categoria;

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

        public string Nombre_categoria
        {
            get
            {
                return nombre_categoria;
            }

            set
            {
                nombre_categoria = value;
            }
        }

        public string Descripcion_categoria
        {
            get
            {
                return descripcion_categoria;
            }

            set
            {
                descripcion_categoria = value;
            }
        }

        public string Ejemplo_categoria
        {
            get
            {
                return ejemplo_categoria;
            }

            set
            {
                ejemplo_categoria = value;
            }
        }
    }
}
