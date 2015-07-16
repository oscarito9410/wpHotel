using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Becarios.Bd
{
    public class CrudCliente : ICrudHelper
    {
    

        public override async Task<bool> deleteAsync(object table)
        {
            var cliente = this.getCastCliente(table);
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                //http://blog.openalfa.com/como-trabajar-con-restricciones-de-clave-externa-en-mysql
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = "DELETE FROM cliente WHERE id_cliente =?id_cliente"
                };
                MidbConexion.Open();
                miComando.Parameters.AddWithValue("?id_cliente", cliente.id);
                await miComando.ExecuteNonQueryAsync();
            }
            return true;
        }
                

        public override async Task<bool> updateAsync(object table)
        {
            var cliente = this.getCastCliente(table);
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = @"UPDATE hotelcolonia.cliente SET  numpersonas=?numpersonas,nombre=?nombre,
                                   lugar_procedencia=?lugar_procedencia,correo=?correo,numtarjeta=?numtarjeta,telefono=?telefono
                                   WHERE id_cliente=?id_cliente"

                };
                MidbConexion.Open();
               
                miComando.Parameters.AddWithValue("?id_cliente", cliente.id);
                miComando.Parameters.AddWithValue("?numpersonas", cliente.acompaniantes);
                miComando.Parameters.AddWithValue("?nombre", cliente.nombre);
                miComando.Parameters.AddWithValue("?lugar_procedencia", cliente.origen);
                miComando.Parameters.AddWithValue("?correo", cliente.email);
                miComando.Parameters.AddWithValue("?numtarjeta", cliente.tarjeta);
                miComando.Parameters.AddWithValue("?telefono", cliente.telefono);
                await miComando.ExecuteNonQueryAsync();


                await new CrudHabitacion().updateAsync(cliente.selectedHabitacion.numero, true);

            }
            return true;
        }

        public override async Task<bool> addAsync(object table)
        {
            var cliente = this.getCastCliente(table);
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = @"INSERT INTO cliente(id_cliente,numpersonas,nombre,lugar_procedencia,correo,numtarjeta,telefono) 
                                    VALUES (?id_cliente,?numpersonas,?nombre,?lugar_procedencia,?correo,?numtarjeta,?telefono)"
                };
                MidbConexion.Open();
                miComando.Parameters.AddWithValue("?id_cliente", cliente.id);
                miComando.Parameters.AddWithValue("?numpersonas", cliente.acompaniantes);
                miComando.Parameters.AddWithValue("?nombre", cliente.nombre);
                miComando.Parameters.AddWithValue("?telefono", cliente.telefono);
                miComando.Parameters.AddWithValue("?lugar_procedencia", cliente.origen);
                miComando.Parameters.AddWithValue("?correo", cliente.email);
                miComando.Parameters.AddWithValue("?numtarjeta", cliente.tarjeta);
                await miComando.ExecuteNonQueryAsync();
                miComando.Parameters.Clear();
                miComando.CommandText = @"INSERT INTO control_reservacion(clv_reservacion,dia_entrada,dia_salida,hora_entrada,hora_salida,id_cliente) 
                                    VALUES (?clv_reservacion,?dia_entrada,?dia_salida,?hora_entrada,?hora_salida,?id_cliente)";

                int claveReservacion = await this.getMaxAsync("control_reservacion", "clv_reservacion");
                miComando.Parameters.AddWithValue("?clv_reservacion", claveReservacion);
                miComando.Parameters.AddWithValue("?dia_entrada", cliente.dateEntrada);
                miComando.Parameters.AddWithValue("?dia_salida", cliente.dateSalida);
                miComando.Parameters.AddWithValue("?hora_entrada", cliente.dateEntrada.ToShortTimeString());
                miComando.Parameters.AddWithValue("?hora_salida", cliente.dateSalida.ToShortTimeString());
                miComando.Parameters.AddWithValue("?id_cliente", cliente.id);
                await miComando.ExecuteNonQueryAsync();

                miComando.Parameters.Clear();

                miComando.CommandText = @"INSERT INTO detalle_reservacion(clv_reservacion,num_habitacion) 
                                        VALUES(?clv_reservacion,?num_habitacion)";

                miComando.Parameters.AddWithValue("?clv_reservacion", claveReservacion);
                miComando.Parameters.AddWithValue("?num_habitacion", cliente.selectedHabitacion.numero);

                await miComando.ExecuteNonQueryAsync();
                miComando.Parameters.Clear();
    
                int claveGasto = await this.getMaxAsync("gastos","clv_gasto");
                miComando.CommandText = "INSERT INTO gastos(clv_gasto,id_cliente) VALUES (?clv_gasto,?id_cliente)";
                miComando.Parameters.AddWithValue("clv_gasto", claveGasto);
                miComando.Parameters.AddWithValue("?id_cliente", cliente.id);
                await miComando.ExecuteNonQueryAsync();

                await new CrudHabitacion().updateAsync(cliente.selectedHabitacion.numero, true);

                return true;

            }
        }

        public async Task<int> getClienteGasto(int idCliente)
        {
            int clave = 1;
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = String.Format("SELECT clv_gasto AS Clave FROM gastos WHERE id_cliente=?id_cliente")
                };
                miComando.Parameters.AddWithValue("?id_cliente", idCliente);
                var reader = await miComando.ExecuteReaderAsync();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("Clave")))
                    {
                        clave = Convert.ToInt32(reader[0]);
                    }
                }

            }
            return clave;
        }

        public override async Task<bool> exists(object table)
        {
            throw new NotImplementedException();
        }

       

        public ViewModel.ViewModelClient getCastCliente(object table)
        {

            return table as ViewModel.ViewModelClient;
        }

        public async Task<ObservableCollection<Model.Cliente>> getAll()
        {
            ObservableCollection<Model.Cliente> listClientes = new ObservableCollection<Model.Cliente>();

            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = String.Format("SELECT*FROM cliente_detalles")
                };
                var reader =await miComando.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Model.Cliente cliente = new Model.Cliente();
                    cliente.id = Convert.ToInt32(reader["id_cliente"]);
                    cliente.acompaniantes =Convert.ToInt32(reader["numpersonas"]);
                    cliente.nombre = Convert.ToString(reader["nombre"]);
                    cliente.origen = Convert.ToString(reader["lugar_procedencia"]);
                    cliente.email = Convert.ToString(reader["correo"]);
                    cliente.tarjeta = Convert.ToString(reader["numtarjeta"]);
                    cliente.dateEntrada= Convert.ToDateTime(reader["dia_entrada"]);
                    cliente.dateSalida = Convert.ToDateTime(reader["dia_salida"]);
                    cliente.diasEstancia = getDias(cliente.dateEntrada, cliente.dateSalida);
                    cliente.email = Convert.ToString(reader["correo"]);
                    cliente.telefono = Convert.ToString(reader["telefono"]);
                    
                    listClientes.Add(cliente);

                }
                return listClientes;

            }
        }
        private int getDias(DateTime entrada,DateTime salida)
        {
            return (int)salida.Subtract(entrada).TotalDays;
        }
    }
}
