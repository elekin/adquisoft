using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluate.SubCaracteristicas
{
    public class Eficiencia
    {
        private double comportamientoTemporal = 0;
        private double utilizacionRecursos = 0;
        private double cumplimientoEficiencia = 0;

        private double calidadEficiencia;


        private int id_comportamientoTemporal;
        private int id_utilizacionRecursos;
        private int id_cumplimientoEficiencia;


        private double incidencia_comportamientoTemporal;
        private double incidencia_utilizacionRecursos;
        private double incidencia_cumplimientoEficiencia;

        public Eficiencia(double incidencia_ComportamientoTemporal, double incidencia_UtilizacionRecursos, double incidencia_CumplimientoEficiencia)
        {
            this.incidencia_comportamientoTemporal = incidencia_ComportamientoTemporal;
            this.incidencia_utilizacionRecursos = incidencia_UtilizacionRecursos;
            this.incidencia_cumplimientoEficiencia = incidencia_CumplimientoEficiencia;


        }

        public double ComportamientoTemporal
        {
            get
            {
                return comportamientoTemporal;
            }

            set
            {
                comportamientoTemporal = value;
            }
        }

        public double UtilizacionRecursos
        {
            get
            {
                return utilizacionRecursos;
            }

            set
            {
                utilizacionRecursos = value;
            }
        }

        public double CumplimientoEficiencia
        {
            get
            {
                return cumplimientoEficiencia;
            }

            set
            {
                cumplimientoEficiencia = value;
            }
        }

        public double CalidadEficiencia
        {
            get
            {
                return calidadEficiencia;
            }

            set
            {
                calidadEficiencia = value;
            }
        }

        public int Id_comportamientoTemporal
        {
            get
            {
                return id_comportamientoTemporal;
            }

            set
            {
                id_comportamientoTemporal = value;
            }
        }

        public int Id_utilizacionRecursos
        {
            get
            {
                return id_utilizacionRecursos;
            }

            set
            {
                id_utilizacionRecursos = value;
            }
        }

        public int Id_cumplimientoEficiencia
        {
            get
            {
                return id_cumplimientoEficiencia;
            }

            set
            {
                id_cumplimientoEficiencia = value;
            }
        }

        public void calcularValoresNormalizado()
        {
            double[] normalizar = { this.incidencia_comportamientoTemporal, this.incidencia_cumplimientoEficiencia, this.incidencia_utilizacionRecursos };
            double max = normalizar.Max();
            if (max == 0)
            {
                comportamientoTemporal = 0;
                cumplimientoEficiencia = 0;
                utilizacionRecursos = 0;
            }
            else
            {


                double div_comportamientoTemporal = (this.incidencia_comportamientoTemporal / max);
                double div_utilizacionRecursos = (this.incidencia_utilizacionRecursos / max);
                double div_cumplimientoEficiencia = (this.incidencia_cumplimientoEficiencia / max);



                this.ComportamientoTemporal = (div_comportamientoTemporal * this.ComportamientoTemporal);
                this.UtilizacionRecursos = (div_utilizacionRecursos * this.UtilizacionRecursos);
                this.CumplimientoEficiencia = (div_cumplimientoEficiencia * this.CumplimientoEficiencia);

                if (this.ComportamientoTemporal > 1.0)
                {
                    this.comportamientoTemporal = 1.0;
                }
                if (this.UtilizacionRecursos > 1.0)
                {
                    this.UtilizacionRecursos = 1.0;
                }
                if (this.CumplimientoEficiencia > 1.0)
                {
                    this.CumplimientoEficiencia = 1.0;
                }

                Console.WriteLine("\n Imprimiento valores antes de la logica difusa Eficiencia");
                Console.WriteLine("Comportamiento Temporal: " + comportamientoTemporal);
                Console.WriteLine("Utilizacion Recursos: " + utilizacionRecursos);
                Console.WriteLine("Cumplimiento Eficiencia: " + cumplimientoEficiencia);
                Console.WriteLine("\n");
            }
        }

       
    }
}
