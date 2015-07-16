using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Becarios.Bd;
using Becarios.Common;

namespace Becarios.ViewModel
{
    public class ViewModelHabitacion:Model.Habitacion, ICustomCommand
    {


        private int min, max;
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
   
  
        private ObservableCollection<Model.Habitacion> listAllHabitaciones = new ObservableCollection<Model.Habitacion>();
        public ViewModelHabitacion()
        {
            this.crudHelper = new CrudHabitacion();
            this.commandAddNew = new DelegateCommand(this.addNew);
            this.commandSave = new DelegateCommand(this.save);
            this.commandSiguiente = new DelegateCommand(this.siguiente);
            this.commandAnterior = new DelegateCommand(this.anterior);
            this.commandOpenDelete = new DelegateCommand(this.openPopupDelete);
            this.commandDelete = new DelegateCommand(this.delete);
            this.commandGoBack = new DelegateCommand(this.goBack);
            this.getAllHabitaciones();
        }

        public async void getAllHabitaciones()
        {
            var crudHabitacion = this.crudHelper as CrudHabitacion;
            this.listAllHabitaciones = crudHabitacion.getAll();
            this.min = await this.crudHelper.getMinAsync("habitacion", "num_habitacion");
            this.max = await this.crudHelper.getMaxAsync("habitacion", "num_habitacion");
            this.numero = min;
            this.navigate(this.numero,false);

        }
        public async void save()
        {
            if(String.IsNullOrEmpty(this.telefono))
            {
                this.OnMessageDialogReceived(Settings.titulo, "Por favor ingresa el telefono de la habitación");

            }
            else if(String.IsNullOrEmpty(this.precio.ToString()))
            {
                this.OnMessageDialogReceived(Settings.titulo, "Por favor ingresa el precio de la habitación");

            }
            else
            {
                if (await this.crudHelper.isUpdate("habitacion", "num_habitacion", this.numero) == true)
                {
                    await this.crudHelper.updateAsync(this);
                    this.OnMessageDialogReceived(Settings.titulo, Settings.getActualizado("Habitación"));
                }
                else
                {
                    if (await this.crudHelper.addAsync(this) == true)
                    {
                        this.OnMessageDialogReceived(Settings.titulo,Settings.getInsertado("Habitación"));
                        this.max = await this.crudHelper.getMaxAsync("habitacion", "num_habitacion");
                        this.getAllHabitaciones();
                    }
                }
             
            }
        }
        public async void addNew()
        {
           this.numero=  await this.crudHelper.getMaxAsync("habitacion", "num_habitacion");
           this.max = this.numero;
           this.precio = 0;
           this.tamanio = String.Empty;
           this.telefono = String.Empty;
        }
        public void navigate(int id,bool anterior)
        {
           var habitacion=this.listAllHabitaciones.Where(x => x.numero == id).FirstOrDefault();
            if (habitacion!=null)
            {
                this.numero = habitacion.numero;
                this.precio = habitacion.precio;
                this.tamanio = habitacion.tamanio;
                this.telefono = habitacion.telefono;
                this.estado = habitacion.estado;
            }
            
           
        }
        public async void delete()
        {
            if(await this.crudHelper.deleteAsync(this)==true)
            {
                this.isOpen = !this.isOpen;
                this.navigate(this.min,false);
                this.getAllHabitaciones();
               
            }

        }
        public void goBack()
        {
            this.OnWindowActionReceived(false, new View.OptionMenu());
        }
        public  void siguiente()
        {
            if (this.numero < max - 1)
            {
                this.numero++;
                this.navigate(this.numero,false);
            }
        }
        public void anterior()
        {
            if (this.numero > min)
            {
                this.numero--;
                this.navigate(this.numero,true);
            }
        }
        public void openPopupDelete()
        {
     
            if (this.numero == max)
            {
                OnMessageDialogReceived(Settings.titulo, Settings.imposibleBorrar);
                return;
            }

            this.isOpen = !this.isOpen;
        }
        public ICommand commandAnterior
        {
            get; set;
        }
        public ICommand commandSiguiente
        {
            get; set;
        }
        public ICommand commandAddNew
        {
            get; set;
        }
        public ICommand commandOpenDelete
        {
            get; set;
        }
        public ICommand commandDelete
        {
            get; set;
        }
        public ICommand commandSave
        {
            get; set;
        }
        public ICommand commandGoBack
        {
            get; set;
        }
    }
}
