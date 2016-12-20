using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Evaluacion_Difusa
{
    static class Etiquetas
    {
        static string MM = "Muy Mala";
        static string M = "Mala";
        static string R = "Regular";
        static string B = "Buena";
        static string MB = "Muy Buena";

        public static string obtenerEtiquetaLenguistica(double x)
        {
            if (x >= 0.0 && x < 0.20)
            {
                return MM;
            }

            if (x >= 0.20 && x < 0.40)
            {
                return M;
            }


            if (x >= 0.40 && x < 0.60)
            {
                return R;
            }

            if (x >= 0.60 && x < 0.80)
            {
                return B;
            }

            if (x >= 0.80 && x <= 1.0)
            {
                return MB;
            }
            return null;
        }

        public static string obtenerEtiquetaLenguisticaCosto(double x)
        {
            if (x >= 0.0 && x < 0.20)
            {
                return "No Tiene";
            }

            if (x >= 0.20 && x < 0.40)
            {
                return "Bajo";
            }


            if (x >= 0.40 && x < 0.60)
            {
                return "Regular";
            }

            if (x >= 0.60 && x < 0.80)
            {
                return "Alto";
            }

            if (x >= 0.80 && x <= 1.0)
            {
                return "Muy Alto";
            }
            return null;
        }

    }
}
