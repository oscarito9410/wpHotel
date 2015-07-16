using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Becarios.Common
{
    public class Keys
    {
        public Dictionary<String, int> Habitaciones = new Dictionary<String, int>();
        public List<String> ProductosCategoria = new List<String>();
        public Keys()
        {
            Habitaciones.Add("Sencilla", 300);
            Habitaciones.Add("Doble", 600);
            Habitaciones.Add("Suite", 1500);
            ProductosCategoria.Add("Entradas");
            ProductosCategoria.Add("Bebidas");
            ProductosCategoria.Add("Postres");
            ProductosCategoria.Add("Platillos");

        }
    }
}
