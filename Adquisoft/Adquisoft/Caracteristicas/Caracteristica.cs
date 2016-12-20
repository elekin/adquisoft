using Evaluate.SubCaracteristicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluate.Caracteristicas
{
    class Caracteristica
    {
        private Eficiencia eficiencia;
        private Fiabilidad fiabilidad;
        private Funcionalidad funcionalidad;

        public Caracteristica(Eficiencia eficiencia, Fiabilidad fiabilidad, Funcionalidad funcionalidad)
        {
            this.eficiencia = eficiencia;
            this.fiabilidad = fiabilidad;
            this.funcionalidad = funcionalidad;
        }
    }
}
