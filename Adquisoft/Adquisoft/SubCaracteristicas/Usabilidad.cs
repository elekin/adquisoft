using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluate.SubCaracteristicas
{
    public class Usabilidad
    {
        private double facilidadAprendizaje = 0;
        private double comprensibilidad = 0;
        private double operabilidad = 0;
        private double atractividad = 0;
        private double cumplimientoUsabilidad = 0;

        private double calidadUsabilidad;


        private int id_facilidadAprendizaje;
        private int id_comprensibilidad;
        private int id_operabilidad;
        private int id_atractividad;
        private int id_cumplimientoUsabilidad;

        private double incidencia_FacilidadAprendizaje;
        private double incidencia_Comprensibilidad;
        private double incidencia_Operabilidad;
        private double incidencia_Atractividad;
        private double incidencia_CumplimientoUsabilidad;


       

        // valor antes de entrar a la logica difusa
        public void calcularValoresNormalizado ()
        {
            double[] normalizar = { this.incidencia_Atractividad, this.incidencia_Comprensibilidad, this.incidencia_CumplimientoUsabilidad, this.incidencia_FacilidadAprendizaje, this.incidencia_Operabilidad };
            double max = normalizar.Max();
            if (max == 0)
            {
                this.FacilidadAprendizaje = 0;
                this.Comprensibilidad = 0;
                this.Operabilidad = 0;
                this.Atractividad = 0;
                this.CumplimientoUsabilidad = 0;
            }
            else
            {
                double div_facilidadAprendizaje = (this.incidencia_FacilidadAprendizaje / max);
                double div_comprensibilidad = (this.incidencia_Comprensibilidad / max);
                double div_operabilidad = (this.incidencia_Operabilidad / max);
                double div_atractividad = (this.incidencia_Atractividad / max);
                double div_cumplimientoUsabilidad = (this.incidencia_CumplimientoUsabilidad / max);




                this.facilidadAprendizaje = (div_facilidadAprendizaje * this.facilidadAprendizaje);
                this.comprensibilidad = (div_comprensibilidad * this.comprensibilidad);
                this.operabilidad = (div_operabilidad * this.operabilidad);
                this.atractividad = (div_atractividad * this.atractividad);
                this.cumplimientoUsabilidad = (div_cumplimientoUsabilidad * this.cumplimientoUsabilidad);


                if (this.facilidadAprendizaje > 1.0)
                {
                    this.facilidadAprendizaje = 1.0;
                }
                if (this.comprensibilidad > 1.0)
                {
                    this.comprensibilidad = 1.0;
                }
                if (this.operabilidad > 1.0)
                {
                    this.operabilidad = 1.0;
                }
                if (this.atractividad > 1.0)
                {
                    this.atractividad = 1.0;
                }
                if (this.cumplimientoUsabilidad > 1.0)
                {
                    this.cumplimientoUsabilidad = 1.0;
                }

                // IMPRIMIREN POR DENTRO
                Console.WriteLine("Imprimiendo por dentro usabilidad valor que entra a la logica difusa");

                Console.WriteLine("Facilidad Aprendizaje: " + this.facilidadAprendizaje);
                Console.WriteLine("Comprensibilidad: " + this.comprensibilidad);
                Console.WriteLine("Operabilidad: " + this.operabilidad);
                Console.WriteLine("Atractividad: " + this.atractividad);
                Console.WriteLine("Cumplimiento Usabilidad: " + this.cumplimientoUsabilidad);
                Console.WriteLine("\n");
            }
        }



        public Usabilidad(double incidencia_FacilidadAprendizaje, double incidencia_Comprensibilidad, double incidencia_Operabilidad,
            double incidencia_Atractividad, double incidencia_CumplimientoUsabilidad)
        {
     
 
            this.incidencia_FacilidadAprendizaje = incidencia_FacilidadAprendizaje;
            this.incidencia_Comprensibilidad = incidencia_Comprensibilidad;
            this.incidencia_Operabilidad = incidencia_Operabilidad;
            this.incidencia_Atractividad = incidencia_Atractividad;
            this.incidencia_CumplimientoUsabilidad = incidencia_CumplimientoUsabilidad;

            //Console.WriteLine("Incidencia Facilidad Aprendizaje: " + this.incidencia_FacilidadAprendizaje);
            //Console.WriteLine("Incidencia Comprensibilidad: " + this.incidencia_Comprensibilidad);
            //Console.WriteLine("Incidencia Operabilidad: " + this.incidencia_Operabilidad);
            //Console.WriteLine("Incidencia Atractividad: " + this.incidencia_Atractividad);
            //Console.WriteLine("Incidencia Cumplimiento Usabilidad: " + this.incidencia_CumplimientoUsabilidad);
        }

        public double FacilidadAprendizaje
        {
            get
            {
                return facilidadAprendizaje;
            }

            set
            {
                facilidadAprendizaje = value;
            }
        }

        public double Comprensibilidad
        {
            get
            {
                return comprensibilidad;
            }

            set
            {
                comprensibilidad = value;
            }
        }

        public double Operabilidad
        {
            get
            {
                return operabilidad;
            }

            set
            {
                operabilidad = value;
            }
        }

        public double Atractividad
        {
            get
            {
                return atractividad;
            }

            set
            {
                atractividad = value;
            }
        }

        public double CumplimientoUsabilidad
        {
            get
            {
                return cumplimientoUsabilidad;
            }

            set
            {
                cumplimientoUsabilidad = value;
            }
        }

        public double CalidadUsabilidad
        {
            get
            {
                return calidadUsabilidad;
            }

            set
            {
                calidadUsabilidad = value;
            }
        }

        public int Id_facilidadAprendizaje
        {
            get
            {
                return id_facilidadAprendizaje;
            }

            set
            {
                id_facilidadAprendizaje = value;
            }
        }

        public int Id_comprensibilidad
        {
            get
            {
                return id_comprensibilidad;
            }

            set
            {
                id_comprensibilidad = value;
            }
        }

        public int Id_operabilidad
        {
            get
            {
                return id_operabilidad;
            }

            set
            {
                id_operabilidad = value;
            }
        }

        public int Id_atractividad
        {
            get
            {
                return id_atractividad;
            }

            set
            {
                id_atractividad = value;
            }
        }

        public int Id_cumplimientoUsabilidad
        {
            get
            {
                return id_cumplimientoUsabilidad;
            }

            set
            {
                id_cumplimientoUsabilidad = value;
            }
        }
    }
}
