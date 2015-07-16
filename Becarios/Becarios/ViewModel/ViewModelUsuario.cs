using Becarios.Bd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Becarios.Bd;
using Becarios.Common;

namespace Becarios.ViewModel
{
    public class ViewModelUsuario:Model.Usuarios
    {
        private String _usuarioRegistrar;
        public String usuarioRegistrar
        {
            get
            {
                return this._usuarioRegistrar;
            }
            set
            {
                this._usuarioRegistrar = value;
                this.RaisePropertyChanged("usuarioRegistrar");
            }
        }
        private String _passwordRegistrar;
        public String passwordRegistrar
        {
            get
            {
                return this._passwordRegistrar;
            }
            set
            {
                this._passwordRegistrar = value;
                this.RaisePropertyChanged("passwordRegistrar");
            }
        }

        private String _passwordConfirmar;
        public String passwordConfirmar
        {
            get
            {
                return this._passwordConfirmar;
            }
            set
            {
                this._passwordConfirmar = value;
                this.RaisePropertyChanged("passwordConfirmar");
            }
        }

        private bool _isOpen;
        public bool isOpen
        {
            get
            {
                return this._isOpen;
            }
            set
            {
                this._isOpen = value;
                this.RaisePropertyChanged("isOpen");
            }
        } 
      
        public ViewModelUsuario()
        {
            this.crudHelper = new CrudUsuario();
            this.registrarCommand = new DelegateCommand(Registrar);
            this.ingresarCommand = new DelegateCommand(Validar);
            this.openRegistrarCommand = new DelegateCommand(Open);
        }
        public void Open()
        {
            this.isOpen = !this.isOpen;
        }
        public async void Validar()
        {
            if (String.IsNullOrEmpty(this.nombre))
            {

                this.OnMessageDialogReceived(Settings.titulo, "Ingresa el nombre de usuario");
            }
            else if (String.IsNullOrEmpty(this.password))
            {
                this.OnMessageDialogReceived(Settings.titulo, "Ingresa la password");
            }
            else
            {

                if (await crudHelper.exists(this) == true)
                {
                    this.OnWindowActionReceived(true,new View.OptionMenu());
                    
                }
                else
                {
                    this.OnMessageDialogReceived("Usuario no encontrado", "Verifica tu usuario y password");
                }
            }
               
        }

        public async void Registrar()
        {
            if(String.IsNullOrEmpty(this.usuarioRegistrar))
            {
                this.OnMessageDialogReceived(Settings.titulo, "Por favor ingresa el nombre de usuario");
            }
            else if(String.IsNullOrEmpty(this.passwordConfirmar) || String.IsNullOrEmpty(this.passwordRegistrar))
            {
                this.OnMessageDialogReceived(Settings.titulo, "Por favor ingresa las passwords");
            }
            else if(passwordRegistrar!=passwordConfirmar)
            {
                this.OnMessageDialogReceived(Settings.titulo, "Las passwords no son iguales");
            }
            else
            {
                if(await this.crudHelper.addAsync(new Model.Usuarios() { nombre = this.usuarioRegistrar, password = this.passwordRegistrar })==true)
                {
                    this.OnMessageDialogReceived(Settings.titulo, Settings.getInsertado("Usuario"));
                    this.isOpen = false;
                }
            }
        }

        public ICommand registrarCommand
        {
            get;
            private set;

        }
        public ICommand ingresarCommand
        {
            get;
            private set;
        }

        public ICommand openRegistrarCommand
        {
            get;
            private set;
        }


    }
}
