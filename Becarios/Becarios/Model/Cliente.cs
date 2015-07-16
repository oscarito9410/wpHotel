using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Becarios.Model
{
    public class Cliente:ViewModel.ViewModelBase
    {

        private int _id;
        public int id
        {
            get

            {
                return this._id;
            }
            set

            {
                this._id = value;
                this.RaisePropertyChanged("id");
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
        private String _origen;
        public String origen
        {
            get
            {
                return this._origen;
            }
            set
            {
                this._origen = value;
                this.RaisePropertyChanged("origen");

            }
        }
        private String _nombre;
        public String nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
                this.RaisePropertyChanged("nombre");
            }
        }
        private int _acompaniantes;
        public int acompaniantes
        {
            get
            {
                return this._acompaniantes;
            }
            set
            {
                this._acompaniantes = value;
                this.RaisePropertyChanged("acompaniantes");
            }
        }
        private String _tarjeta;
        public String tarjeta
        {
            get
            {
                return this._tarjeta;
            }
            set
            {
                this._tarjeta = value;
                this.RaisePropertyChanged("tarjeta");
            }
        }
        private String _email;
        public String email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
                this.RaisePropertyChanged("email");
            }
        }
        private DateTime _dateEntrada;
        public DateTime dateEntrada
        {
            get
            {
                return _dateEntrada;
            }
            set
            {
                this._dateEntrada = value;
                this.updateDateSalida(diasEstancia);
                this.RaisePropertyChanged("dateEntrada");
            }
        }
        private int _diasEstancia;
        public int diasEstancia
        {
            get
            {
                return this._diasEstancia;
            }
            set
            {
                this._diasEstancia = value;
                this.updateDateSalida(value);
                this.RaisePropertyChanged("diasEstancia");
            }

        }
        private DateTime _dateSalida;
        public DateTime dateSalida
        {
            get
            {
                return _dateSalida;
            }
            set
            {
                this._dateSalida = value;
                this.RaisePropertyChanged("dateSalida");
            }
        }

        private void updateDateSalida(int days)
        {
            this.dateSalida = dateEntrada.AddDays(days);
        }
    }
}
