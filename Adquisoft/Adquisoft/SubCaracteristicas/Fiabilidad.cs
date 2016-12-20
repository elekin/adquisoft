using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluate.SubCaracteristicas
{
    public class Fiabilidad
    {
        private double madurez = 0;
        private double toleranciaFallos = 0;
        private double recuperabilidad = 0;
        private double cumplimientoFiabilidad = 0;

        private double calidadFiabilidad;


        private int id_madurez;
        private int id_toleranciaFallos;
        private int id_recuperabilidad;
        private int id_cumplimientoFiabilidad;


        public double Madurez
        {
            get
            {
                return madurez;
            }

            set
            {
                madurez = value;
            }
        }

        public double ToleranciaFallos
        {
            get
            {
                return toleranciaFallos;
            }

            set
            {
                toleranciaFallos = value;
            }
        }

        public double Recuperabilidad
        {
            get
            {
                return recuperabilidad;
            }

            set
            {
                recuperabilidad = value;
            }
        }

        public double CumplimientoFiabilidad
        {
            get
            {
                return cumplimientoFiabilidad;
            }

            set
            {
                cumplimientoFiabilidad = value;
            }
        }

        public double CalidadFiabilidad
        {
            get
            {
                return calidadFiabilidad;
            }

            set
            {
                calidadFiabilidad = value;
            }
        }

        public int Id_madurez
        {
            get
            {
                return id_madurez;
            }

            set
            {
                id_madurez = value;
            }
        }

        public int Id_toleranciaFallos
        {
            get
            {
                return id_toleranciaFallos;
            }

            set
            {
                id_toleranciaFallos = value;
            }
        }

        public int Id_recuperabilidad
        {
            get
            {
                return id_recuperabilidad;
            }

            set
            {
                id_recuperabilidad = value;
            }
        }

        public int Id_cumplimientoFiabilidad
        {
            get
            {
                return id_cumplimientoFiabilidad;
            }

            set
            {
                id_cumplimientoFiabilidad = value;
            }
        }

        private double incidencia_Madurez;
        private double incidencia_ToleranciaFallos;
        private double incidencia_Recuperabilidad;
        private double incidencia_CumplimientoFiabilidad;

        public Fiabilidad(double incidencia_Madurez, double incidencia_ToleranciaFallos, double incidencia_Recuperabilidad, double incidencia_CumplimientoFiabilidad)
        {


            this.incidencia_Madurez = incidencia_Madurez;
            this.incidencia_ToleranciaFallos = incidencia_ToleranciaFallos;
            this.incidencia_Recuperabilidad = incidencia_Recuperabilidad;
            this.incidencia_CumplimientoFiabilidad = incidencia_CumplimientoFiabilidad;
        }

    


        // valor antes de entrar a la logica difusa
        public void calcularValoresNormalizado()
        {
      
            double[] normalizar = { this.incidencia_Madurez, this.incidencia_ToleranciaFallos, this.incidencia_Recuperabilidad, this.incidencia_CumplimientoFiabilidad };
            double max = normalizar.Max();
            if (max == 0)
            {
                this.Madurez = 0;
                this.ToleranciaFallos = 0;
                this.Recuperabilidad = 0;
                this.CumplimientoFiabilidad = 0;
            }
            else
            {

                double div_madurez = (this.incidencia_Madurez / max);
                double div_toleranciaFallos = (this.incidencia_ToleranciaFallos / max);
                double div_recuperabilidad = (this.incidencia_Recuperabilidad / max);
                double div_cumplimientoFiabilidad = (this.incidencia_CumplimientoFiabilidad / max);


                this.madurez = (div_madurez * this.madurez);
                this.toleranciaFallos = (div_toleranciaFallos * this.toleranciaFallos);
                this.recuperabilidad = (div_recuperabilidad * this.recuperabilidad);
                this.cumplimientoFiabilidad = (div_cumplimientoFiabilidad * this.cumplimientoFiabilidad);


                if (this.madurez > 1.0)
                {
                    this.madurez = 1.0;
                }
                if (this.toleranciaFallos > 1.0)
                {
                    this.toleranciaFallos = 1.0;
                }
                if (this.recuperabilidad > 1.0)
                {
                    this.recuperabilidad = 1.0;
                }
                if (this.cumplimientoFiabilidad > 1.0)
                {
                    this.cumplimientoFiabilidad = 1.0;
                }

                Console.WriteLine("\n Imprimiento valores antes de la logica difusa Fiabilidad");
                Console.WriteLine("madurez: " + this.madurez);
                Console.WriteLine("toleranciaFallos: " + this.toleranciaFallos);
                Console.WriteLine("recuperabilidad: " + this.recuperabilidad);
                Console.WriteLine("cumplimientoFiabilidad: " + this.cumplimientoFiabilidad);
            }
        }
    }
}
