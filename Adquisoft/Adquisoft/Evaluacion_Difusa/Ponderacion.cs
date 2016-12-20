using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Evaluacion_Difusa
{
    static class Ponderacion
    {

        public static double obtenerPonderacion (double valorReal, double valorIncidencia, double [] valoresIncidencia)
        {
            double max = valoresIncidencia.Max();
            if (max == 0)
            {
                return 0;
            }
            else
            {
                double limite = ((valorIncidencia / max) * valorReal);
                if (limite > 1.0)
                {
                    return 1.0;
                }
                return ((valorIncidencia / max) * valorReal);
            }
        }
    }
}
