using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Becarios.Model;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Collections.ObjectModel;
namespace Becarios.Bd
{
    public class CrudHabitacion: ICrudHelper
    {
    
        public override async Task<bool> addAsync(object table)
        {
            var habitacion = getCastHabitacion(table);
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = "INSERT INTO habitacion(num_habitacion,estado,tamanio,precio,telefono) VALUES (?habitacion,?estado,?tamanio,?precio,?telefono)"
                };
                miComando.Parameters.AddWithValue("?estado", habitacion.estado == true ? "Ocupado" : "Disponible");
                miComando.Parameters.AddWithValue("?tamanio", habitacion.tamanio);
                miComando.Parameters.AddWithValue("?precio", Convert.ToDouble(habitacion.precio));
                miComando.Parameters.AddWithValue("?telefono", habitacion.telefono);
                miComando.Parameters.AddWithValue("?habitacion", habitacion.numero);
                await miComando.ExecuteNonQueryAsync();
                return true;

            }
        }
        public ObservableCollection<Habitacion> getAll()
        {
            ObservableCollection<Model.Habitacion> listHabitacion = new ObservableCollection<Model.Habitacion>();

            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = String.Format("SELECT*FROM habitacion")
                };
                MySqlDataReader reader = miComando.ExecuteReader();
                while(reader.Read())
                {
                    Habitacion habitacion = new Habitacion();
                    habitacion.estado = Convert.ToString(reader["estado"]).Equals("Ocupado") ? true : false;
                    habitacion.precio = Convert.ToDouble(reader["precio"]);
                    habitacion.tamanio = Convert.ToString(reader["tamanio"]);
                    habitacion.telefono = Convert.ToString(reader["telefono"]);
                    habitacion.numero = Convert.ToInt32(reader["num_habitacion"]);
                    listHabitacion.Add(habitacion);
                }
                return listHabitacion;
            }
        }
        public override async Task<bool> updateAsync(object table)
        {
            var habitacion = getCastHabitacion(table);
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = "UPDATE habitacion SET estado=?estado,tamanio=?tamanio,precio=?precio,telefono=?telefono WHERE num_habitacion=?habitacion"
                };
                miComando.Parameters.AddWithValue("?estado", habitacion.estado == true ? "Ocupado" : "Disponible");
                miComando.Parameters.AddWithValue("?tamanio", habitacion.tamanio);
                miComando.Parameters.AddWithValue("?precio", habitacion.precio);
                miComando.Parameters.AddWithValue("?telefono", habitacion.telefono);
                miComando.Parameters.AddWithValue("?habitacion", habitacion.numero);
                await miComando.ExecuteNonQueryAsync();
                return true;

            }
        }

        public async Task<bool>updateAsync(int num_habitacion,bool estado)
        {
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = "UPDATE habitacion SET estado=?estado WHERE num_habitacion=?habitacion"
                };
                miComando.Parameters.AddWithValue("?estado", estado == true ? "Ocupado" : "Disponible");
                miComando.Parameters.AddWithValue("?habitacion", num_habitacion);
                await miComando.ExecuteNonQueryAsync();
                return true;

            }
        }
        public override async Task<bool>deleteAsync(object table)
        {
            var habitacion = getCastHabitacion(table);
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = "DELETE FROM habitacion WHERE num_habitacion=?habitacion"
                };
                miComando.Parameters.AddWithValue("?habitacion", habitacion.numero);
                await miComando.ExecuteNonQueryAsync();
                return true;
            }
        }
        public override async Task<bool> exists(object table)
        {
            throw new NotImplementedException();
        }
        public Model.Habitacion getCastHabitacion(object table)
        {

            return table as Model.Habitacion;
        }
      
    }
}
