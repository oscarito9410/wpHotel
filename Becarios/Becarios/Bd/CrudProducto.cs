using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Becarios.Model;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace Becarios.Bd
{
    public class CrudProducto : ICrudHelper
    {
        public override async Task<bool> addAsync(object table)
        {
            var producto = getCastProducto(table);
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = @"INSERT INTO PRODUCTO (clv_producto, descripcion, precio, cantidad, img_producto,categoria)   
                                   VALUES (?clv_producto,?descripcion,?precio,?cantidad,?img_producto,?categoria)"
                };
                miComando.Parameters.AddWithValue("?clv_producto", producto.clvProducto);
                miComando.Parameters.AddWithValue("?descripcion", producto.descripcion);
                miComando.Parameters.AddWithValue("?precio", producto.precio);
                miComando.Parameters.AddWithValue("?cantidad", producto.cantidad);
                miComando.Parameters.AddWithValue("?img_producto", producto.imgProducto);
                miComando.Parameters.AddWithValue("?categoria", producto.categoria);
                await miComando.ExecuteNonQueryAsync();
                return true;
            }
          }

        public override async Task<bool> deleteAsync(object table)
        {
            var producto = getCastProducto(table);
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = @"DELETE FROM PRODUCTO WHERE clv_producto=?clv_producto"
                };
                miComando.Parameters.AddWithValue("?clv_producto", producto.clvProducto);
                await miComando.ExecuteNonQueryAsync();
                return true;
            }
        }

        public override async Task<bool> updateAsync(object table)
        {
            var producto = getCastProducto(table);
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = @"UPDATE PRODUCTO  SET descripcion=?descripcion, precio=?precio, cantidad=?cantidad, img_producto=?img_producto,categoria=?categoria  
                                   WHERE clv_producto=?clv_producto"
                };
                miComando.Parameters.AddWithValue("?clv_producto", producto.clvProducto);
                miComando.Parameters.AddWithValue("?descripcion", producto.descripcion);
                miComando.Parameters.AddWithValue("?precio", producto.precio);
                miComando.Parameters.AddWithValue("?cantidad", producto.cantidad);
                miComando.Parameters.AddWithValue("?categoria", producto.categoria);
                miComando.Parameters.AddWithValue("?img_producto", producto.imgProducto);
                await miComando.ExecuteNonQueryAsync();
                return true;
            }
        }

        public ObservableCollection<Producto> getAll()
        {
            ObservableCollection<Producto> listProducto = new ObservableCollection<Producto>();

            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = String.Format("SELECT*FROM producto")
                };
                MySqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.clvProducto = Convert.ToInt32(reader["clv_producto"]);
                    producto.cantidad = Convert.ToInt32(reader["cantidad"]);
                    producto.descripcion = Convert.ToString(reader["descripcion"]);
                    producto.precio = Convert.ToDouble(reader["precio"]);
                    producto.categoria = Convert.ToString(reader["categoria"]);
                    producto.imgProducto = Convert.ToString(reader["img_producto"]);
                    listProducto.Add(producto);
                }
                return listProducto;
            }
        }

        public override Task<bool> exists(object table)
        {
            throw new NotImplementedException();
        }


        private Producto getCastProducto(object table)
        {
            return table as Producto;
        }
    }
}
