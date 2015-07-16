using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Becarios.Bd
{
    public class CrudUsuario : ICrudHelper
    {
        public override async Task<bool> addAsync(object table)
        {
            var usuario = getCastUsuario(table);
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();//Abrimos la conexion para realizar los siguientes pasos
                // 'Declaro comando para poder realizar mis instrucciones sql
                MySqlCommand micomando = new MySqlCommand { Connection = MidbConexion, CommandText = "INSERT INTO usuario(nombre,password) VALUES (?Nom,?Pass)" };
                micomando.Parameters.AddWithValue("?Nom", usuario.nombre);
                micomando.Parameters.AddWithValue("?Pass", usuario.password);
                await micomando.ExecuteNonQueryAsync();
                return true;
            }
        }

       

        public override async Task<bool> deleteAsync(object table)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> exists(object table)
        {
            var usuario = this.getCastUsuario(table);
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();//Abrimos la conexion para realizar los siguientes pasos
                // 'Declaro comando para poder realizar mis instrucciones sql
                MySqlCommand micomando = new MySqlCommand { Connection = MidbConexion, CommandText = "SELECT*FROM usuario WHERE nombre=?Nom AND Password=?Pass" };
                micomando.Parameters.AddWithValue("?Nom", usuario.nombre);
                micomando.Parameters.AddWithValue("?Pass", usuario.password);
                Console.WriteLine("NOMBRE {0}", usuario.nombre);
                Console.WriteLine("Passwor {0}", usuario.password);
                int numEncontrado = Convert.ToInt32(await micomando.ExecuteScalarAsync());
                if (numEncontrado == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
        public Model.Usuarios getCastUsuario(object table)
        {

            return table as Model.Usuarios;
        }

        public override Task<bool> updateAsync(object table)
        {
            throw new NotImplementedException();
        }
    }
}
