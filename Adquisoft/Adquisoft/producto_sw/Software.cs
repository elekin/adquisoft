using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.producto_sw
{
   public class Software
    {
        private string id;
        //informacion general
        private string nombre_producto;
        private string version;
        private string desarrollador;
        private string licencia;
        private string manual_usuario;
        private string categoria;
        private string subcategoria;
        private string descripcion;

        //requerimientos minimos de sistema
        private string sistema_operativo;
        private string procesador;
        private string rom; //almacenamiento necesario para instalar el producto
        private string ram; //memoria ram necesaria para instalar el producto
        private string tarjeta_grafica;
        private string hw_sw_add;  //necesita de sw o hw adicional?
        //costos
        private string c_adquisicion;
        private string c_suscripcion;
        private string periodo_pago;
        private string c_capacitacion;
        private string c_hwSwAdd;
        private string c_total;

        //del producto
        private string nivel_calidad;
        private string valor_nivel_calidad;

        // costos normalizado
        private double costo_normalizado;
        private string nivel_calidad_costo;
        private double puntaje_final;

        public string Nombre_producto
        {
            get
            {
                return nombre_producto;
            }

            set
            {
                nombre_producto = value;
            }
        }

        public string Version
        {
            get
            {
                return version;
            }

            set
            {
                version = value;
            }
        }

        public string Desarrollador
        {
            get
            {
                return desarrollador;
            }

            set
            {
                desarrollador = value;
            }
        }

        public string Licencia
        {
            get
            {
                return licencia;
            }

            set
            {
                licencia = value;
            }
        }

        public string Manual_usuario
        {
            get
            {
                return manual_usuario;
            }

            set
            {
                manual_usuario = value;
            }
        }

        public string Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        public string Subcategoria
        {
            get
            {
                return subcategoria;
            }

            set
            {
                subcategoria = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string Sistema_operativo
        {
            get
            {
                return sistema_operativo;
            }

            set
            {
                sistema_operativo = value;
            }
        }

        public string Procesador
        {
            get
            {
                return procesador;
            }

            set
            {
                procesador = value;
            }
        }

        public string Rom
        {
            get
            {
                return rom;
            }

            set
            {
                rom = value;
            }
        }

        public string Ram
        {
            get
            {
                return ram;
            }

            set
            {
                ram = value;
            }
        }

        public string Tarjeta_grafica
        {
            get
            {
                return tarjeta_grafica;
            }

            set
            {
                tarjeta_grafica = value;
            }
        }

        public string Hw_sw_add
        {
            get
            {
                return hw_sw_add;
            }

            set
            {
                hw_sw_add = value;
            }
        }

        public string C_adquisicion
        {
            get
            {
                return c_adquisicion;
            }

            set
            {
                c_adquisicion = value;
            }
        }

        public string C_suscripcion
        {
            get
            {
                return c_suscripcion;
            }

            set
            {
                c_suscripcion = value;
            }
        }

        public string Periodo_pago
        {
            get
            {
                return periodo_pago;
            }

            set
            {
                periodo_pago = value;
            }
        }

        public string C_capacitacion
        {
            get
            {
                return c_capacitacion;
            }

            set
            {
                c_capacitacion = value;
            }
        }

        public string C_hwSwAdd
        {
            get
            {
                return c_hwSwAdd;
            }

            set
            {
                c_hwSwAdd = value;
            }
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

        public string C_total
        {
            get
            {
                return c_total;
            }

            set
            {
                c_total = value;
            }
        }

        public string Nivel_calidad
        {
            get
            {
                return nivel_calidad;
            }

            set
            {
                nivel_calidad = value;
            }
        }

        public string Valor_nivel_calidad
        {
            get
            {
                return valor_nivel_calidad;
            }

            set
            {
                valor_nivel_calidad = value;
            }
        }

        public double Puntaje_final
        {
            get
            {
                return puntaje_final;
            }

            set
            {
                puntaje_final = value;
            }
        }

        public double Costo_normalizado
        {
            get
            {
                return costo_normalizado;
            }

            set
            {
                costo_normalizado = value;
            }
        }

        public string Nivel_calidad_costo
        {
            get
            {
                return nivel_calidad_costo;
            }

            set
            {
                nivel_calidad_costo = value;
            }
        }








        /// <summary>
        /// Suma el total de costos que involucran la adquisicion de un producto de sw.
        /// El costo de suscripción se toma en base al gasto que tendra en 1 año.
        /// </summary>
        /// <param name="factor">factor a considerar del costo de suscripción</param>
        /// <returns>Costo total</returns>
        public uint CostoTotal()
        {
            uint costototal;
            uint costoadquisicion = UInt32.Parse(this.C_adquisicion);
            uint costohwsw_add = UInt32.Parse(this.C_hwSwAdd);
            uint costocapacitacion = UInt32.Parse(this.C_capacitacion);
            uint costosuscripcion = UInt32.Parse(C_suscripcion);


            uint factor = 0;
            if (costosuscripcion != 0)
            {
                switch (Periodo_pago)
                {

                    case "mensual":
                        factor = 12;
                        break;
                    case "3 meses":
                        factor = 4;
                        break;
                    case "6 meses":
                        factor = 2;
                        break;
                    case "anual":
                        factor = 1;
                        break;
                }
            }


            //calcula costo total
            costototal = costoadquisicion + costohwsw_add + costocapacitacion + costosuscripcion * factor;
            return costototal;
        }

    


       
   


    }
}
