using GardenJournalDemoApp.InterfacesAbstractClasses;
using GardenJournalDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GardenJournalDemoApp.ViewModels
{
    public class RemoveGardenViewModel : BaseViewModel
    {
        ObservableCollection<Garden> _GardenNames;

        INavigationService _Nav;

        public ObservableCollection<Garden> GardenNames
        {
            get => _GardenNames;
            set
            {
                _GardenNames = value;
                OnPropertyChanged("GardenNames");
            }
        }

        public ICommand RemoveGardenCommand { get; private set; }

        public RemoveGardenViewModel(ObservableCollection<Garden> gardens, INavigationService nav)
        {
            _GardenNames = gardens;
            RemoveGardenCommand = new Command(RemoveGarden);
        }

        void RemoveGarden(object obj)
        {
            ItemSelected(this, new SelectedItemEventArgs {ToRemove = obj});
        }

        public event EventHandler<SelectedItemEventArgs> ItemSelected;
    }
}
