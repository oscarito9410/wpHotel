using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Becarios.Bd;
using System.Collections.ObjectModel;
using MahApps.Metro.Controls.Dialogs;
using Becarios.Model;
using Becarios.Common;

namespace Becarios.ViewModel
{
    public class ViewModelClient: Model.Cliente,ICustomCommand
    {
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
        private Habitacion _selectedHabitacion;
        public  Habitacion selectedHabitacion
        {
            get
            {
                return this._selectedHabitacion;
            }
            set
            {
                this._selectedHabitacion = value;
                this.selectedPrecio = value.precio;
                this.RaisePropertyChanged("selectedHabitacion");
            }
        }
        private double _selectedPrecio;
        public double selectedPrecio
        {
            get
            {
                return this._selectedPrecio;
            }
            set
            {
                this._selectedPrecio = value;
                this.RaisePropertyChanged("selectedPrecio");
            }
        }
        private ObservableCollection<Cliente> allClientes;
        private ObservableCollection<Habitacion> _listHabitacionesDisponibles;
        public ObservableCollection<Habitacion> listHabitacionesDisponibles
        {
            get
            {
                return this._listHabitacionesDisponibles;
            }
            set

            {
                this._listHabitacionesDisponibles = value;
                this.RaisePropertyChanged("listHabitacionesDisponibles");
            }
        }
        private int max = 0;
        private int min = 0;
        public ViewModelClient()
        {
            this.dateEntrada = DateTime.Now;
            this.dateSalida = DateTime.Now.AddDays(1);
            this.commandSave = new DelegateCommand(save);
            this.crudHelper = new CrudCliente();
            this.commandAddNew = new DelegateCommand(addNew);
            this.commandOpenDelete = new DelegateCommand(openPopupDelete);
            this.commandSiguiente = new DelegateCommand(this.siguiente);
            this.commandAnterior = new DelegateCommand(this.anterior);
            this.commandDelete = new DelegateCommand(this.delete);
            this.commandGoBack = new DelegateCommand(this.goBack);
            this.getAllClientes();
           
        }
        private async void updateListCliente()
        {
            var crudClient = this.crudHelper as CrudCliente;
            this.allClientes = await crudClient.getAll();
        }
        private async void getAllClientes()
        {
            var crudClient = this.crudHelper as CrudCliente;
            this.allClientes=await crudClient.getAll();
            this.listHabitacionesDisponibles = new ObservableCollection<Model.Habitacion>();
            this.min = await this.crudHelper.getMinAsync("cliente_detalles", "id_cliente");
            this.max = await this.crudHelper.getMaxAsync("cliente_detalles", "id_cliente");
            this.id = min;
            this.navigate(this.id,false);
        }
        public async void addNew()
        {
            this.id =  await this.crudHelper.getMaxAsync("cliente", "id_cliente");
            this.max = this.id;
            this.nombre = String.Empty;
            this.dateEntrada = DateTime.Now;
            this.dateSalida = DateTime.Now.AddDays(1);
            this.origen = String.Empty;
            this.email = String.Empty;
            this.acompaniantes = 0;
            this.tarjeta = String.Empty;
            this.telefono = String.Empty;
            this.diasEstancia = 0;
        }
        public void navigate(int id, bool anterior)
        {
            Model.Cliente cliente =  allClientes.Where(x => x.id == id).FirstOrDefault();
            /*
                        do
                        {
                            if (anterior == true)
                            {
                                cliente = allClientes.Where(x => x.id == id - 1).FirstOrDefault();
                            }
                            else
                            {
                                cliente = allClientes.Where(x => x.id == id + 1).FirstOrDefault();
                            }
                        }
                        while (cliente == null);
                        */
            if (cliente != null) {
                this.id = cliente.id;
                this.nombre = cliente.nombre;
                this.dateEntrada = cliente.dateEntrada;
                this.dateSalida = cliente.dateSalida;
                this.origen = cliente.origen;
                this.email = cliente.email;
                this.telefono = cliente.telefono;
                this.diasEstancia = cliente.diasEstancia;
                this.acompaniantes = cliente.acompaniantes;
                this.tarjeta = cliente.tarjeta;
             }
        }
        public async void save()
        {
            if(String.IsNullOrEmpty(nombre))
            {
                this.OnMessageDialogReceived(Settings.titulo, "Ingresa tu nombre");
            }
            else if(String.IsNullOrEmpty(email))
            {
                this.OnMessageDialogReceived(Settings.titulo, "Ingresa tu email");
            }
            else if(String.IsNullOrEmpty(tarjeta) || tarjeta.Length<4)
            {
                this.OnMessageDialogReceived(Settings.titulo, "Numero tarjeta no valido");
            }
           
            else if(!Regex.IsMatch(this.email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                this.OnMessageDialogReceived(Settings.titulo, "Email no valido");
            }
            else if(String.IsNullOrEmpty(telefono))
            {
                this.OnMessageDialogReceived(Settings.titulo, "Ingresa telefono");
            }
            else if(String.IsNullOrEmpty(origen))
            {
                this.OnMessageDialogReceived(Settings.titulo, "Ingresa el origen");
            }
            else if (this.selectedHabitacion == null)
            {
                this.OnMessageDialogReceived(Settings.titulo, "Selecciona la habitación del usuario");
            }
            else
            {

                if (await this.crudHelper.isUpdate("cliente", "id_cliente", this.id) == true)
                {
                    await this.crudHelper.updateAsync(this);
                    this.OnMessageDialogReceived(Settings.titulo, Settings.getActualizado("Cliente"));
                    this.getAllClientes();
                }
                else
                {
                
                    await this.crudHelper.addAsync(this);
                    this.OnMessageDialogReceived(Settings.titulo,Settings.getInsertado("Cliente"));
                    this.getAllClientes();
                }
               
               
            }
         
        }
        public async void delete()
        {
            if(await this.crudHelper.deleteAsync(this)==true)
            {
                this.isOpen = false;
                this.addNew();
            }
        }
        public void siguiente()
        {
            if (id < max - 1)
            {
                this.id++;
                this.navigate(id,false);
            }
        }
        public void anterior()
        {
            if (id > min)
            {
                this.id--;
                this.navigate(id,true);
            }
        }
        public void openPopupDelete()
        {
           
                if (this.id == max)
                {
                    OnMessageDialogReceived(Settings.titulo, Settings.imposibleBorrar);
                    return;
                }

                this.isOpen = !this.isOpen;
         }

        public void goBack()
        {
            this.OnWindowActionReceived(false, new View.OptionMenu());
        }

        public ICommand commandAnterior
        {
            get; set;
        }
        public ICommand commandSiguiente
        {
            get;  set;
        }
        public ICommand commandAddNew
        {
            get; set;
        }
        public ICommand commandOpenDelete
        {
            get;  set;
        }
        public ICommand commandDelete
        {
            get;  set;
        }
        public ICommand commandSave
        {
            get;  set;
        }

        public ICommand commandGoBack
        {
            get; set;
        }
    }
}
