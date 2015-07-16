using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Becarios.Model
{
    public class Habitacion: ViewModel.ViewModelBase
    {
        private int _numero;
        public int numero
        {
            get
            {
                return this._numero;
            }
            set
            {
                this._numero = value;
                this.RaisePropertyChanged("numero");
            }
        }

        private String _tamanio;
        public String tamanio
        {
            get
            {
                return this._tamanio;
            }
            set
            {
                this._tamanio = value;
                this.RaisePropertyChanged("tamanio");
            }
        }

        private String _telefono;
        public String telefono
        {
            get
            {
                return this._telefono;
            }
            set
            {
                this._telefono = value;
                this.RaisePropertyChanged("telefono");
            }
        }
        private bool _estado;
        public bool estado
        {
            get
            {
                return this._estado;
            }
            set
            {
                this._estado = value;
                this.RaisePropertyChanged("estado");
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

    }
}
