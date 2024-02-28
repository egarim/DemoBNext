using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBNext.Module.BusinessObjects
{
    public class Cliente:System.ComponentModel.INotifyPropertyChanged
    {

        string apellido;
        string nombre;
        //ps
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        public string Apellido
        {
            get => apellido;
            set
            {
                if (apellido == value)
                    return;
                apellido = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Apellido)));
            }
        }
        

    }
}
