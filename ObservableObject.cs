using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pruefung2
{

    // Die ursprüngliche Implementierung von ObservableObject kommt aus
    // Prism (Microsoft.Practices.Composite.Presentation)
    // http://stackoverflow.com/a/10093257/33311
    //
    // Dies ist eine Variante davon.
    [Serializable]
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(this, e);
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            VerifyPropertyName(propertyName);
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Warnt den Compiler, falls es zum spezifizierten Namen kein Property im Objekt existiert.
        /// Diese Methode ist nur für Debug Build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Sicherstellen, dass der Proterty Name auf dem Objekt exisiert  
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                Debug.Fail("Invalid property name: " + propertyName);
            }
        }
    }
}

//    public event PropertyChangedEventHandler PropertyChanged;

//        public void RaisePropertyChanged(string propertyName)
//        {
//            VerifyPropertyName(propertyName);
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

//        [Conditional("DEBUG")]
//        public void VerifyPropertyName(string propertyName)
//        {
//            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
//            {
//                Debug.Fail("Invalid property name: {0}", propertyName);
//            }
//        }
//    }
//}
