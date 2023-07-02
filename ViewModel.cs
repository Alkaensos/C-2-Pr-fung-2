using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__2_Prüfung_2
{
    public class MyViewModel : ObservableObject
    {
        private string _myProperty;

        public string MyProperty
        {
            get { return _myProperty; }
            set
            {
                if (_myProperty != value)
                {
                    _myProperty = value;
                    RaisePropertyChanged(nameof(MyProperty));
                }
            }
        }
    }
}
