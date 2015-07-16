using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Becarios.ViewModel;
namespace Becarios.Model
{
    public class Producto:ViewModelBase
    {
        private int _clvProducto;
        public int clvProducto
        {
            get
            {
                return this._clvProducto;
            }
            set
            {
                this._clvProducto= value;
                this.RaisePropertyChanged("clvProducto");
            }
        }
        private String _descripcion;
        public String descripcion
        {
            get
            {
                return this._descripcion;
            }
            set
            {
                this._descripcion = value;
                this.RaisePropertyChanged("descripcion");
            }
        }
        private int _cantidad;
        public int cantidad
        {
            get
            {
                return this._cantidad;
            }
            set
            {
                this._cantidad = value;
                this.RaisePropertyChanged("cantidad");
            }
        }
        private Double _precio;
        public Double precio
        {
            get
            {
                return this._precio;
            }
            set
            {
                this._precio = value;
                this.RaisePropertyChanged("precio");
            }
        }

        private String _categoria;
        public String categoria
        {
            get
            {
                return this._categoria;
            }
            set
            {
                this._categoria = value;
                this.RaisePropertyChanged("categoria");
            }
        }

        private String _imgProducto;
        public String imgProducto
        {
            get
            {
                return this._imgProducto;
            }
            set
            {
                this._imgProducto = value;
                this.RaisePropertyChanged("imgProducto");
            }
        }
    }
}
