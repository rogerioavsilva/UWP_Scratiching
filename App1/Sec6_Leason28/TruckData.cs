using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sec6_Leason28
{
    public class TruckData : NotificationBase
    {
        public ObservableCollection<TruckInfo> Trucks { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private TruckInfo _SelectedTruck;
        public TruckInfo SelectedTruck
        {
            get { return _SelectedTruck; }
            set 
            {
                if (_SelectedTruck == value)
                    return;

                _SelectedTruck = value;

                NotifyPropertyChange();
            }
        }

        public object SelectedTruckObject
        {
            get { return _SelectedTruck; }
            set
            {
                if (_SelectedTruck == value)
                    return;

                _SelectedTruck = (TruckInfo)value;

                NotifyPropertyChange("SelectedTruck");
            }
        }
    }
}
