using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.producto_sw
{
    class ActualizaRegistroSoftwareBD:Software
    {


        public ActualizaRegistroSoftwareBD(Software sw)
        {
            this.Id = sw.Id;
            //información gral de un sw
            this.Nombre_producto = sw.Nombre_producto;
            this.Version = sw.Version;
            this.Desarrollador = sw.Desarrollador;
            this.Licencia = sw.Licencia;
            this.Manual_usuario = sw.Manual_usuario;
            this.Categoria = sw.Categoria;
            this.Subcategoria = sw.Subcategoria;
            this.Descripcion = sw.Descripcion;
            //requerimientos de sistema min
            this.Sistema_operativo = sw.Sistema_operativo;
            this.Procesador = sw.Procesador;
            this.Rom = sw.Rom;
            this.Ram = sw.Ram;
            this.Tarjeta_grafica = sw.Tarjeta_grafica;
            this.Hw_sw_add = sw.Hw_sw_add;
            //costos
            this.C_adquisicion = sw.C_adquisicion;
            this.C_suscripcion = sw.C_suscripcion;
            this.Periodo_pago = sw.Periodo_pago;
            this.C_capacitacion = sw.C_capacitacion;
            this.C_hwSwAdd = sw.C_hwSwAdd;

            ActualizaRegistroSw_BD();
        }

        private void ActualizaRegistroSw_BD()
        {
            
        }
    }
}
