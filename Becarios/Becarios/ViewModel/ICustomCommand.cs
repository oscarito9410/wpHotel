using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Becarios.ViewModel
{
    interface ICustomCommand
    {
         ICommand commandAnterior { get; set; }
         ICommand commandSiguiente { get; set; }
         ICommand commandAddNew { get;  set; }
         ICommand commandOpenDelete { get; set; }
         ICommand commandDelete { get; set; }
         ICommand commandSave{get;set;}
         ICommand commandGoBack { get; set; }
         void addNew();
         void navigate(int id,bool anterior);
         void delete();
         void siguiente();
         void anterior();
         void openPopupDelete();
         void save();
        void goBack();
    }
}
