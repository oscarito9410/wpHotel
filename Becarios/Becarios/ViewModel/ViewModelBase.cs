using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Becarios.ViewModel
{

    public class ChildWindowActionEventArgs : EventArgs
    {
        private readonly object args;
        public ChildWindowActionEventArgs(object args)
        {
            this.args = args;
        }

        public object Args
        {
            get
            {
                return args;
            }
        }
    }
    public class WindowActionEventArgs:EventArgs
    {
        private readonly bool isClose;
        private readonly Window mwindow;
        public WindowActionEventArgs(bool isClose,Window mwindow)
        {
            this.isClose = isClose;
            this.mwindow = mwindow;
        }
        public Window MWindow
        {
            get
            {
                return this.mwindow;
            }
        }
        public bool IsClose
        {
            get
            {
                return this.isClose;
            }
          
        }
    }

    public class MessageDialogAsyncEventArgs:EventArgs
    {
        private readonly String title;
        private readonly String content;
       
        public MessageDialogAsyncEventArgs(String title,String content)
        {

            this.title = title;
            this.content = content;
          
        }
      

        public String Title
        {
            get
            {
                return this.title;
            }
        }
        public String Content
        {
            get
            {
                return this.content;
            }
        }
    }
    public class ViewModelBase: INotifyPropertyChanged
    {
        public Bd.ICrudHelper crudHelper { get; set; }

        public ViewModelBase()
        {
            var dic = new Common.Keys();
            this.listTamanios = new ObservableCollection<String>(dic.Habitaciones.Keys.ToList());
      
        }
        private ObservableCollection<String> _listTamanios;
        public ObservableCollection<String> listTamanios
        {
            get
            {
                return this._listTamanios;
            }
            set
            {
                this._listTamanios = value;
                this.RaisePropertyChanged("listTamanios");
            }
        }
        public delegate void ChildWindowActionEventHandler(object sender, ChildWindowActionEventArgs args);
        public delegate void WindowActionEventHandler(object sender, WindowActionEventArgs args);
        public delegate void MessageAsyncEventHandler(object sender, MessageDialogAsyncEventArgs args);
        public event MessageAsyncEventHandler OnMessageDailogShowEvent;
        public event WindowActionEventHandler OnWindowActionEvent;
        public event PropertyChangedEventHandler PropertyChanged;
        public event ChildWindowActionEventHandler OnChildShowEvent;

        public void OnChildWindowShow(object args)
        {
            if (OnChildShowEvent != null)
            {
                this.OnChildShowEvent(this, new ChildWindowActionEventArgs(args));
            }
        }

        public void OnWindowActionReceived(bool isOpen,Window mWindow)
        {
            if(OnWindowActionEvent!=null)
            {
                this.OnWindowActionEvent(this, new WindowActionEventArgs(isOpen,mWindow));
            }
        }
        public void OnMessageDialogReceived(String title,String content)
        {
            if (OnMessageDailogShowEvent != null)
            {
               this.OnMessageDailogShowEvent(this, new MessageDialogAsyncEventArgs(title, content));
            }

        }

      


        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
