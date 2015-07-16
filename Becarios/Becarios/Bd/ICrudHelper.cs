using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Becarios.Bd
{
    public abstract class ICrudHelper
    {
        public String dbPath = "Data Source=localhost;Database=hotelcolonia;Uid=root;Password=1234";
        public abstract Task<Boolean> addAsync(Object table);
        public abstract Task<Boolean> exists(Object table);
        public abstract Task<bool>updateAsync(Object table);
        public abstract Task<bool> deleteAsync(Object table);
        public async Task<int> getMinAsync(String tableName,String id)
        {
            int min = 1;
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = String.Format("SELECT MIN({0}) AS MINIMO FROM {1}", id, tableName)

                };
                var reader = await miComando.ExecuteReaderAsync();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("MINIMO")))
                    {
                        min = Convert.ToInt32(reader[0]);
                    }
                    else
                    {
                        min = 1;
                    }
                }


            }
            return min;
        }
        public async Task<int> getMaxAsync(String tableName,String id)
        {
            int max = 0;
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = String.Format("SELECT Max({0}) AS MAXIMO FROM {1}", id, tableName)

                };
                var  reader = await miComando.ExecuteReaderAsync();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("Maximo")))
                    {
                        max = Convert.ToInt32(reader[0]) + 1;
                    }
                    else
                    {
                        max = 1;
                    }
                }


            }
            return max;


        }
        public async Task<bool> isUpdate(String tableName, String idColumn, int idValue)
        {
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE {1}=?id", tableName, idColumn)
                };
                miComando.Parameters.AddWithValue("?id", idValue);
                return Convert.ToInt32(await miComando.ExecuteScalarAsync()) == 0 ? false : true;

            }
        }
        public async Task<ObservableCollection<Model.Habitacion>> getHabitacionesDisponibles(String tamanio)
        {
            ObservableCollection<Model.Habitacion> listHabitaciones = new ObservableCollection<Model.Habitacion>();

            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = String.Format("SELECT*FROM view_disponibles WHERE tamanio='{0}'", tamanio)
                };
                 var  reader = await miComando.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Model.Habitacion habitacion = new Model.Habitacion();
                    habitacion.numero = Convert.ToInt32(reader["num_habitacion"]);
                    habitacion.estado = true;
                    habitacion.tamanio = Convert.ToString(reader["tamanio"]);
                    habitacion.telefono = Convert.ToString(reader["telefono"]);
                    habitacion.precio = Convert.ToDouble(reader["precio"]);
                    listHabitaciones.Add(habitacion);

                }
                return listHabitaciones;

            }
        }
     
    }
}
