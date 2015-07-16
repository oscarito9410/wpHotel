using Becarios.Bd;
using Becarios.Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Becarios.ViewModel
{
    public class ViewModelProductos : Model.Producto, ICustomCommand
    {

        private int min = 0;
        private int max= 0;
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
        private ObservableCollection<Model.Producto> listAllProducto = new ObservableCollection<Model.Producto>();
        public ViewModelProductos()
        {
            this.crudHelper = new Bd.CrudProducto();
            this.commandAddNew = new DelegateCommand(this.addNew);
            this.commandSave = new DelegateCommand(this.save);
            this.commandSiguiente = new DelegateCommand(this.siguiente);
            this.commandAnterior = new DelegateCommand(this.anterior);
            this.commandOpenDelete = new DelegateCommand(this.openPopupDelete);
            this.commandDelete = new DelegateCommand(this.delete);
            this.commandGoBack = new DelegateCommand(this.goBack);
            this.commandOpenFileDialog = new DelegateCommand(this.openFileDialog);
            this.listCategorias = new ObservableCollection<String>(new Keys().ProductosCategoria);
            this.getAll();
        }

        public async void getAll()
        {
            this.max = await this.crudHelper.getMaxAsync("producto", "clv_producto");
            this.min = await this.crudHelper.getMinAsync("producto", "clv_producto");
            this.clvProducto = this.min;
            var crudProducto = this.crudHelper as CrudProducto;
            this.listAllProducto = crudProducto.getAll();
            this.navigate(this.clvProducto, false);
        }
        private void openFileDialog()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                this.imgProducto = op.FileName;
            }

        }
        public  async void addNew()
        {
            this.clvProducto = await this.crudHelper.getMaxAsync("producto", "clv_producto");
            this.cantidad = 0;
            this.precio =0;
            this.descripcion = String.Empty;
            this.imgProducto = String.Empty;
        }

        public void navigate(int id, bool anterior)
        {
            var producto = this.listAllProducto.Where(x => x.clvProducto == id).FirstOrDefault();
            if (producto != null)
            {
                this.clvProducto = producto.clvProducto;
                this.cantidad = producto.cantidad;
                this.precio = producto.precio;
                this.descripcion = producto.descripcion;
                this.imgProducto = producto.imgProducto;
                this.categoria = producto.categoria;
            }
        }

        public async void delete()
        {
            if (await this.crudHelper.deleteAsync(this) == true)
            {
                this.isOpen = !this.isOpen;
                this.getAll();

            }
        }

        public void siguiente()
        {

            if (this.clvProducto < max - 1)
            {
                this.clvProducto++;
                this.navigate(clvProducto, false);
            }
        }

        public void anterior()
        {
            if (this.clvProducto > min)
            {
                this.clvProducto--;
                this.navigate(this.clvProducto, true);
            }
        }

        public void openPopupDelete()
        {
            if (this.clvProducto == max)
            {
                OnMessageDialogReceived(Settings.titulo, Settings.imposibleBorrar);
                return;
            }

            this.isOpen = !this.isOpen;
        }

        public async void save()
        {
            
                if (String.IsNullOrEmpty(this.precio.ToString()))
                {
                    this.OnMessageDialogReceived(Settings.titulo, "Ingresa el precio");
                }
                else if (String.IsNullOrEmpty(this.descripcion))
                {
                    this.OnMessageDialogReceived(Settings.titulo, "Ingresa la descripción del producto");
                }
                else
                {
                    if (await this.crudHelper.isUpdate("producto", "clv_producto", this.clvProducto) == true)
                    {
                           await this.crudHelper.updateAsync(this);
                           this.OnMessageDialogReceived(Settings.titulo, Settings.getActualizado("Producto"));
                     }
                    else
                    {
                         await this.crudHelper.addAsync(this);
                         this.OnMessageDialogReceived(Settings.titulo, Settings.getInsertado("Producto"));
                         this.max= await this.crudHelper.getMaxAsync("producto", "clv_producto");
                    }
                
                  
                }
         }

        public void goBack()
        {
            this.OnWindowActionReceived(false, new View.OptionMenu());
        }

        public ICommand commandOpenFileDialog
        {
            get; set;
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
