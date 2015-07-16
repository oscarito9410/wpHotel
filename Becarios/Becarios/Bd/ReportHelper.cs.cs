using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Becarios.Bd
{
    public class ReportHelper
    {
        public String dbPath = "Data Source=localhost;Database=hotelcolonia;Uid=root;Password=1234";
        private MySqlDataAdapter miAdaptador = new MySql.Data.MySqlClient.MySqlDataAdapter();
        public Common.Gastos getGastos(int idCliente=0)
        {
            var dataSetGastos = new Common.Gastos();
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                   Connection=MidbConexion
                };
                if (idCliente>0)
                {
                    miComando.CommandText = "SELECT*FROM total_gasto WHERE ID_CLIENTE=?id_cliente ORDER BY CLV_ORDEN ASC";
                    miComando.Parameters.AddWithValue("?id_cliente", idCliente);
                }
                else
                {
                   miComando.CommandText = "SELECT*FROM total_gasto  ORDER BY CLV_ORDEN ASC";

                }

                miAdaptador.SelectCommand = miComando;
                miAdaptador.Fill(dataSetGastos,"total_gasto");
                return dataSetGastos;
              }
         }
        public Common.Gastos getTicket(int clvOrden)
        {
            var dataSetGastos = new Common.Gastos();
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion
                };
              
                miComando.CommandText = "SELECT*FROM total_gasto WHERE clv_orden=?clv";
                miComando.Parameters.AddWithValue("?clv", clvOrden);
                miAdaptador.SelectCommand = miComando;
                miAdaptador.Fill(dataSetGastos, "total_gasto");
                return dataSetGastos;
            }
        }

        public Common.Habitacion_Cliente getHabitaciones()
        {
            var dataSetHabitacion = new Common.Habitacion_Cliente();
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion
                };
                miComando.CommandText = "SELECT*FROM habitacion_cliente";
                miAdaptador.SelectCommand = miComando;
                miAdaptador.Fill(dataSetHabitacion, "habitacion_cliente");
                return dataSetHabitacion;
            }
        }
               
    }
}
