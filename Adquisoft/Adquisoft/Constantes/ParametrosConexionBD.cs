using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adquisoft.Constantes
{
    public static class ParametrosConexionBD
    {
        private static string PORT = "5433";
        private static string USER = "adquisoft";
        private static string PASSWORD = "123";
        private static string DATA_BASE = "adquisoft";

        public static string BD = ("Server=localhost;Port="+PORT+";UserId="+USER+"; Password="+PASSWORD+";Database="+DATA_BASE+";");
    }
}
