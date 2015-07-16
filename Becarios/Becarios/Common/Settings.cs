using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Becarios.Common
{
    public class Settings
    {
        public static String titulo = "HOTEL COLONIA";

        public static String imposibleBorrar = "No se puede eliminar un regitro que no ha sido añadido aún";

       /// <summary>
       /// Retorna una cadena de string
       /// </summary>
       /// <param name="foo">cosa que fue ingresada</param>
       /// <returns>Ejem cliente actualizado correctamente</returns>
        public static String getActualizado(String foo)
        {
            return String.Format("{0} actualizado correctamente!",foo);
        }
        public static String getInsertado(String foo)
        {
            return String.Format("{0} ingresado correctamente",foo);
        }
    }
}
