using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Becarios.Bd
{
    public class CrudOrden : ICrudHelper
    {
        private List<ViewModel.ProductoOrden> listProducto { get; set; }
        public void setListProducto(List<ViewModel.ProductoOrden> listProducto)
        {
            this.listProducto = listProducto;
        }
        public override async Task<bool> addAsync(object table)
        {
            var orden = this.getTable(table);
            using (MySqlConnection MidbConexion = new MySqlConnection(this.dbPath))
            {
                MidbConexion.Open();
                MySqlCommand miComando = new MySqlCommand()
                {
                    Connection = MidbConexion,
                    CommandText = "INSERT INTO orden(clv_orden,nummesa,fecha,id_cliente) VALUES (?clv_orden,?nummesa,?fecha,?id_cliente)"
                };
                miComando.Parameters.AddWithValue("?clv_orden", orden.claveOrden);
                miComando.Parameters.AddWithValue("?nummesa", orden.numMesa);
                miComando.Parameters.AddWithValue("?fecha", orden.fechaOrden);
                miComando.Parameters.AddWithValue("?id_cliente", orden.idCliente);
                await miComando.ExecuteNonQueryAsync();
                miComando.Parameters.Clear();
                foreach (var producto in listProducto)
                {
                    for (int i = producto.cantidad;i>0;i--)
                    {
                        miComando.CommandText = "INSERT INTO detalle_orden(clv_orden,clv_producto) VALUES(?clv_orden,?clv_producto)";
                        miComando.Parameters.AddWithValue("?clv_orden", orden.claveOrden);
                        miComando.Parameters.AddWithValue("?clv_producto", producto.clvProducto);
                        await miComando.ExecuteNonQueryAsync();
                        miComando.Parameters.Clear();
                    }
                   
                }
                
                miComando.CommandText = "INSERT INTO detalle_gasto(clv_gasto,clv_orden) VALUES(?clv_gasto,?clv_orden)";
                miComando.Parameters.AddWithValue("?clv_gasto",await new CrudCliente().getClienteGasto(orden.idCliente));
                miComando.Parameters.AddWithValue("?clv_orden", orden.claveOrden);
                await miComando.ExecuteNonQueryAsync();
                return true;

            }
        }

        public override Task<bool> deleteAsync(object table)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> exists(object table)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> updateAsync(object table)
        {
            throw new NotImplementedException();
        }

        public ViewModel.Orden getTable(object table)
        {
            return table as ViewModel.Orden;
        }
    }
}
