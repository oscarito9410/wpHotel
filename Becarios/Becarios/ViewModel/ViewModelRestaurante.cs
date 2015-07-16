using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Becarios.Common;
using System.Windows.Input;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Becarios.ViewModel
{
    public class ProductoOrden:Model.Producto
    {

        private Double _totalPagar;
        public Double totalPagar
        {
            get
            {
                return this._totalPagar;
            }
            set
            {
                this._totalPagar = value;
                this.RaisePropertyChanged("totalPagar");
            }
        }
    }
    public class Orden: ViewModelBase
    {
        private int _claveOrden;
        public int claveOrden
        {
            get
            {
                return this._claveOrden;
            }
            set
            {
                this._claveOrden = value;
                this.RaisePropertyChanged("claveOrden");
            }
        }
        private DateTime _fechaOrden;
        public DateTime fechaOrden
        {
            get
            {
                return this._fechaOrden;
            }
            set
            {
                this._fechaOrden = value;
                this.RaisePropertyChanged("fechaOrden");
            }
        }
        private int _idCliente;
        public int idCliente
        {
            get
            {
                return this._idCliente;
            }
            set
            {
                this._idCliente = value;
                this.RaisePropertyChanged("idCliente");
            }
        }
        private int _numMesa;
        public int numMesa
        {
            get
            {
                return this._numMesa;
            }
            set
            {
                this._numMesa = value;
                this.RaisePropertyChanged("numMesa");

            }
        }
    }
    public class ViewModelRestaurante:ViewModelBase
    {
        private bool _isLoading;
        public bool isLoading
        {
            get
            {
                return this._isLoading;
            }
            set
            {
                this._isLoading = value;
                this.RaisePropertyChanged("isLoading");
            }
        }
        private String _clienteNombre;
        public String clienteNombre
        {
            get
            {
                return this._clienteNombre;
            }
            set
            {
                this._clienteNombre = value;
                this.RaisePropertyChanged("clienteNombre");
            }
        }

        private int _selectedMesa;
        public int selectedMesa
        {
            get
            {
                return this._selectedMesa;
            }
            set
            {
                this._selectedMesa = value;
                this.RaisePropertyChanged("selectedMesa");
            }
        }
        private ObservableCollection<String> _clientes;
        public ObservableCollection<String>clientes
        {
            get
            {
                return this._clientes;
            }
            set
            {
                this._clientes = value;
            }
        }
        private DateTime _fecha;
        public DateTime fecha
        {
            get
            {
                return this._fecha;
            }
            set
            {
                this._fecha = value;
                this.RaisePropertyChanged("fecha");
            }
        }
        private Double _totalPagar;
        public Double totalPagar
        {
            get
            {
                return this._totalPagar;
            }
            set
            {
                this._totalPagar = value;
                this.RaisePropertyChanged("totalPagar");
            }
        }



        private ObservableCollection<Model.Producto> _listPlatillos;
        public ObservableCollection<Model.Producto>listPlatillos
        {
            get
            {
                return this._listPlatillos;
            }
            set
            {
                this._listPlatillos = value;
                this.RaisePropertyChanged("listPlatillos");
            }
        }

        private ObservableCollection<ProductoOrden> _listOrden;
        public ObservableCollection<ProductoOrden> listOrden
        {
            get
            {
                return this._listOrden;
            }
            set
            {
                this._listOrden= value;
                this.RaisePropertyChanged("listOrden");
            }
        }

        private ProductoOrden _selectedProducto;
        public ProductoOrden selectedProducto
        {
            get
            {
                return this._selectedProducto;
            }
            set
            {
                this._selectedProducto = value;
                if (selectedProducto.cantidad > 0)
                {
                    selectedProducto.cantidad = 1;
                }
                else
                {
                   this.selectedProducto.totalPagar = (selectedProducto.cantidad * selectedProducto.precio);
                }
                this.RaisePropertyChanged("selectedProducto");
            }
        }
        private String _selectedCategoria;
        public String selectedCategoria
        {
            get
            {
                return this._selectedCategoria;
            }
            set
            {
                this._selectedCategoria = value;
                this.loadPlatillos(value);
                this.RaisePropertyChanged("selectedCategoria");
            }
        }
        private ObservableCollection<String> _listCategorias;
        public ObservableCollection<String> listCategorias
        {
            get
            {
                return this._listCategorias;
            }
            set
            {
                this._listCategorias = value;
                this.RaisePropertyChanged("listCategorias");
            }
        }
        private int clv_orden{ get; set; }
        private int max { get; set; }
        private int min { get; set; }
        public ViewModelRestaurante()
        {
            getAll();
        }
        private async void getMaxMin()
        {
            if (this.crudHelper == null)
            {
                this.crudHelper = new Bd.CrudOrden();
            }
            this.max=await this.crudHelper.getMaxAsync("orden", "clv_orden");
            this.min = await this.crudHelper.getMinAsync("orden", "clv_orden");
            this.clv_orden = max;
        }
        private async void getAll()
        {
            
            this.crudHelper = new Bd.CrudCliente();
            var crudCliente=crudHelper as Bd.CrudCliente;
            var clientesList=await crudCliente.getAll();
            if (clientesList != null)
            {
                clientes = new ObservableCollection<String>(clientesList.Select(x => x.nombre).ToList());
            }
            this.listCategorias= new ObservableCollection<String>(new Keys().ProductosCategoria);
            this.fecha = DateTime.Now;
            this.commandAddList = new DelegateCommand(addOrden);
            this.commandProcesar= new DelegateCommand(procesarPago);
            this.commandDeleteFromList = new DelegateCommand<object>(deleteFromList);
            this.commandGoBack = new DelegateCommand(goBack);
            this.listOrden = new ObservableCollection<ProductoOrden>();
            this.getMaxMin();
            this.loadPlatillos();

        }
        private void loadPlatillos(String categoria="")
        {
            var crudPlatillos = new Bd.CrudProducto();
       
            this.listPlatillos = new ObservableCollection<Model.Producto>();
            if (String.IsNullOrEmpty(categoria))
            {
                this.listPlatillos = crudPlatillos.getAll();
            }
            else
            {
                var platillosCategoria=crudPlatillos.getAll().Where(producto => producto.categoria == categoria);
                listPlatillos = new ObservableCollection<Model.Producto>(platillosCategoria.ToList());
            }
        }
        private void deleteFromList(object paramter)
        {
            var producto = paramter as ProductoOrden;
            this.listOrden.Remove(producto);
            this.updatePrecio();
        }
       private void addOrden()
        {
          
            if (this.listOrden.Any(x => x.descripcion.Equals(this.selectedProducto.descripcion)))
            {
                this.OnMessageDialogReceived(Common.Settings.titulo, "El articulo ya fue ingresado, solo actualiza la cantidad");      
            }
            else
            {
                this.listOrden.Add(this.selectedProducto);
                this.updatePrecio();


            }

        }
        public async void procesarPago()
        {
            if (!this.clientes.Contains(this.clienteNombre))
            {
                this.OnMessageDialogReceived(Settings.titulo, "Elige un cliente valido");
            }
            else if (selectedMesa == 0)
            {
                this.OnMessageDialogReceived(Settings.titulo, "Selecciona el número de mesa");
            }
            else
            {
                this.isLoading = true;
                await Task.Delay(TimeSpan.FromSeconds(1));
                Orden orden = new Orden();
                orden.fechaOrden = DateTime.Now;
                orden.numMesa = selectedMesa;
                orden.claveOrden = this.clv_orden;
                var clientes= await new Bd.CrudCliente().getAll();
                orden.idCliente = clientes.Where(x => x.nombre.Equals(this.clienteNombre)).Select(x => x.id).FirstOrDefault();
                var crudOrden = new Bd.CrudOrden();
                crudOrden.setListProducto(this.listOrden.ToList());
                await crudOrden.addAsync(orden);

                var metroWindow = (Application.Current.MainWindow as MetroWindow);
                MessageDialogResult result=await metroWindow.ShowMessageAsync("Orden añadida correctamente","¿Te gustaría imprimir el ticket ahora?",MessageDialogStyle.AffirmativeAndNegative);
                if (result == MessageDialogResult.Affirmative)
                {
                    this.OnChildWindowShow(this.clv_orden);
                }
                this.getMaxMin();
                this.isLoading = false;


            }
        }
        public void updatePrecio()
        {
            if (listOrden == null)
                return;
            this.totalPagar = 0;

            if (this.selectedProducto != null)
            {
                this.selectedProducto.totalPagar = (selectedProducto.precio * selectedProducto.cantidad);
            }

            foreach(var producto in listOrden)
            {
                this.totalPagar += producto.totalPagar;
            }
           
        }
        public void goBack()
        {
            this.OnWindowActionReceived(false, new View.OptionMenu());
        }
        public ICommand commandProcesar
        {
            get;
            private set;
        }
    public ICommand commandDeleteFromList
        {
            get;
            private set;
        }

        public ICommand commandAddList
        {
            get;
            private set;
        }

        public ICommand commandGoBack
        {
            get;
            private set;
        }

    }
}
