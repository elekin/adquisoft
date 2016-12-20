using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdquisicionSoftware.Modulos.Metricas
{
    public class Metrica
    {
        private string id;
        private string nombre;
        private string proposito;
        private string metodo;
        private string formula;
        private string mejorValor;
        private string peorValor;
        private string perspectiva;
        private string caracteristica;
        private string subCaracteristica;
        private string variables;

        private string A;
        private string B;

        private string descripcionA;
        private string descripcionB;

        public Metrica()
        {

        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Proposito
        {
            get
            {
                return proposito;
            }

            set
            {
                proposito = value;
            }
        }

        public string Metodo
        {
            get
            {
                return metodo;
            }

            set
            {
                metodo = value;
            }
        }

        public string Formula
        {
            get
            {
                return formula;
            }

            set
            {
                formula = value;
            }
        }

        public string MejorValor
        {
            get
            {
                return mejorValor;
            }

            set
            {
                mejorValor = value;
            }
        }

        public string PeorValor
        {
            get
            {
                return peorValor;
            }

            set
            {
                peorValor = value;
            }
        }

        public string Perspectiva
        {
            get
            {
                return perspectiva;
            }

            set
            {
                perspectiva = value;
            }
        }

        public string Caracteristica
        {
            get
            {
                return caracteristica;
            }

            set
            {
                caracteristica = value;
            }
        }

        public string SubCaracteristica
        {
            get
            {
                return subCaracteristica;
            }

            set
            {
                subCaracteristica = value;
            }
        }

        public string Variables
        {
            get
            {
                return variables;
            }

            set
            {
                variables = value;
            }
        }

        public string A1
        {
            get
            {
                return A;
            }

            set
            {
                A = value;
            }
        }

        public string B1
        {
            get
            {
                return B;
            }

            set
            {
                B = value;
            }
        }

        public string DescripcionA
        {
            get
            {
                return descripcionA;
            }

            set
            {
                descripcionA = value;
            }
        }

        public string DescripcionB
        {
            get
            {
                return descripcionB;
            }

            set
            {
                descripcionB = value;
            }
        }

        public Metrica(string id, string nombre, string proposito, string metodo, string formula, string mejorValor, string peorValor, string perspectiva, string caracteristica, string subCaracteristica, string variables)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Proposito = proposito;
            this.Metodo = metodo;
            this.Formula = formula;
            this.MejorValor = mejorValor;
            this.PeorValor = peorValor;
            this.Perspectiva = perspectiva;
            this.Caracteristica = caracteristica;
            this.SubCaracteristica = subCaracteristica;
            this.Variables = variables;
        }


    }
}
