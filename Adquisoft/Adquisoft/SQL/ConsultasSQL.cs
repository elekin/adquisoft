using Adquisoft.Constantes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.SQL
{
    public static class ConsultasSQL
    {

        //Consultas categorías
        public static string CONSULTAR_LISTA_CATEGORIAS = "SELECT * from categoria";
        public static string CONSULTAR_NOMBRES_CATEGORIAS = "SELECT nombre from categoria";
        public static string CONSULTAR_SUB_CATEGORIAS_DE_CATEGORIAS = "SELECT * FROM subcategoria where id = ";

        //Consultas Metricas
        public static string ACTUALIZAR_TABLA_METRICAS = "SELECT * from caracteristica as c, subcaracteristica as s, metrica as m where c.id_caracteristica = s.id_caracteristica and s.id_subcaracteristica = m.id_subcaracteristica order by c, s.nombre";
        public static string CONSULTA_LISTA_METRICAS = "SELECT * FROM ";
        public static string ELIMINAR_METRICA = "DELETE from metrica where id_metrica = ";

        //Consultas Registro Software


        //consultas evaluaciones

        //consultas usuarios

        //
        
    }
}
