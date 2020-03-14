using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class TrucksVM : NotificationBase
    {
        public TrucksVM()
        {
            Trucks = new ObservableCollection<TruckVM>();
            RefreshCommand = new Command(LoadAsync);
        }

        public Command RefreshCommand { get; set; }

        private ObservableCollection<TruckVM> _Trucks;
        public ObservableCollection<TruckVM> Trucks
        {
            get { return _Trucks; }
            set 
            {
                if (_Trucks == value)
                    return;
                _Trucks = value;
                NotifyPropertyChanged();
            }
        }

        private TruckVM _SelectedTruck;

        public TruckVM SelectedTruck
        {
            get { return _SelectedTruck; }
            set 
            { 
                if(_SelectedTruck == value)
                    return;
                _SelectedTruck = value;
                NotifyPropertyChanged();
            }
        }


        public async Task LoadAsync()
        {
            var trucks = TruckInfoSampleData.GetSampleData();
            Trucks.Clear();

            await Task.Delay(2000);

            foreach (var truck in trucks)
                Trucks.Add(new TruckVM() 
                {
                    ID = truck.ID,
                    Name = truck.Name,
                    Style = truck.Style
                });

            await Repository
                    .GetObject<IDialogService>()
                    .ShowDialogAsync("Initialization", "Data loaded", "OK", null);
        }

        public async void Launch()
        {
            await LoadAsync();
        }

    }
}
