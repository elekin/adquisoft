using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluate.SubCaracteristicas
{
    public class Funcionalidad
    {
        private double adecuacion = 0;
        private double exactitud = 0;
        private double interoperabilidad = 0;
        private double seguridad = 0;
        private double cumplimientoFuncional = 0;

        private double calidadfuncionalidad;


        private int id_adecuacion;
        private int id_exactitud;
        private int id_interoperabilidad;
        private int id_seguridad;
        private int id_cumplimientoFuncional;


        private double incidencia_Adecuacion;
        private double incidencia_Exactitud;
        private double incidencia_Interoperabilidad;
        private double incidencia_Seguridad;
        private double incidencia_CumplimientoFuncional;

        public Funcionalidad(double incidencia_Adecuacion, double incidencia_Exactitud, double incidencia_Interoperabilidad, double incidencia_Seguridad, double incidencia_CumplimientoFuncional)
        {
            this.incidencia_Adecuacion = incidencia_Adecuacion;
            this.incidencia_Exactitud = incidencia_Exactitud;
            this.incidencia_Interoperabilidad = incidencia_Interoperabilidad;
            this.incidencia_Seguridad = incidencia_Seguridad;
            this.incidencia_CumplimientoFuncional = incidencia_CumplimientoFuncional;
        }

        public double Adecuacion
        {
            get
            {
                return adecuacion;
            }

            set
            {
                adecuacion = value;
            }
        }

        public double Exactitud
        {
            get
            {
                return exactitud;
            }

            set
            {
                exactitud = value;
            }
        }

        public double Interoperabilidad
        {
            get
            {
                return interoperabilidad;
            }

            set
            {
                interoperabilidad = value;
            }
        }

        public double Seguridad
        {
            get
            {
                return seguridad;
            }

            set
            {
                seguridad = value;
            }
        }

        public double CumplimientoFuncional
        {
            get
            {
                return cumplimientoFuncional;
            }

            set
            {
                cumplimientoFuncional = value;
            }
        }

        public double Calidadfuncionalidad
        {
            get
            {
                return calidadfuncionalidad;
            }

            set
            {
                calidadfuncionalidad = value;
            }
        }

        public int Id_adecuacion
        {
            get
            {
                return id_adecuacion;
            }

            set
            {
                id_adecuacion = value;
            }
        }

        public int Id_exactitud
        {
            get
            {
                return id_exactitud;
            }

            set
            {
                id_exactitud = value;
            }
        }

        public int Id_interoperabilidad
        {
            get
            {
                return id_interoperabilidad;
            }

            set
            {
                id_interoperabilidad = value;
            }
        }

        public int Id_seguridad
        {
            get
            {
                return id_seguridad;
            }

            set
            {
                id_seguridad = value;
            }
        }

        public int Id_cumplimientoFuncional
        {
            get
            {
                return id_cumplimientoFuncional;
            }

            set
            {
                id_cumplimientoFuncional = value;
            }
        }

        public void calcularValoresNormalizado()
        {
            double[] normalizar = { this.incidencia_Adecuacion, this.incidencia_Exactitud, this.incidencia_Interoperabilidad, this.incidencia_Seguridad, this.incidencia_CumplimientoFuncional };
            double max = normalizar.Max();
            if (max == 0)
            {
                this.Adecuacion = 0;
                this.Exactitud = 0;
                this.Interoperabilidad = 0;
                this.Seguridad = 0;
                this.CumplimientoFuncional = 0;
            }
            else
            {
                double div_adecuacion = (this.incidencia_Adecuacion / max);
                double div_exactitud = (this.incidencia_Exactitud / max);
                double div_interoperabilidad = (this.incidencia_Interoperabilidad / max);
                double div_seguridad = (this.incidencia_Seguridad / max);
                double div_cumplimientoFuncional = (this.incidencia_CumplimientoFuncional / max);


                this.adecuacion = (div_adecuacion * this.adecuacion);
                this.exactitud = (div_exactitud * this.exactitud);
                this.interoperabilidad = (div_interoperabilidad * this.interoperabilidad);
                this.seguridad = (div_seguridad * this.seguridad);
                this.cumplimientoFuncional = (div_cumplimientoFuncional * this.cumplimientoFuncional);


                if (this.adecuacion > 1.0)
                {
                    this.adecuacion = 1.0;
                }
                if (this.exactitud > 1.0)
                {
                    this.exactitud = 1.0;
                }
                if (this.interoperabilidad > 1.0)
                {
                    this.interoperabilidad = 1.0;
                }
                if (this.seguridad > 1.0)
                {
                    this.seguridad = 1.0;
                }
                if (this.cumplimientoFuncional > 1.0)
                {
                    this.cumplimientoFuncional = 1.0;
                }

                Console.WriteLine("\n Imprimiento valores antes de la logica difusa Funcionalidad");
                Console.WriteLine("Adecuacion: " + this.adecuacion);
                Console.WriteLine("Exactitud: " + this.exactitud);
                Console.WriteLine("Interoperabilidad: " + this.interoperabilidad);
                Console.WriteLine("Seguridad: " + this.seguridad);
                Console.WriteLine("Cumplimiento Funcional: " + this.cumplimientoFuncional);
            }
        }
    }
}
