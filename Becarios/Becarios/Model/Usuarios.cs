using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Becarios.Model
{
    public class Usuarios:ViewModel.ViewModelBase
    {
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

        private String _password;
        public String password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
                this.RaisePropertyChanged("password");
            }
        }
    }
}
