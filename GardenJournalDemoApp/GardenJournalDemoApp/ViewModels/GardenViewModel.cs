using GardenJournalDemoApp.InterfacesAbstractClasses;
using GardenJournalDemoApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace GardenJournalDemoApp.ViewModels
{
    class GardenViewModel : BaseViewModel
    {
        INavigationService _Nav;

        string _Name;

        public string Name 
        {
            get => _Name;
            set 
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        string _Size;

        public string Size
        {
            get => _Size;
            set
            {
                _Size = value;
                OnPropertyChanged("Size");
            }
        }

        ObservableCollection<IHarvestable> _Plants;

        public ObservableCollection<IHarvestable> Plants
        {
            get => _Plants;
            set
            {
                _Plants = value;
                OnPropertyChanged("Plants");
            }
        }

        public ICommand HarvestableSelectCommand { get; private set; }

        public ICommand AddHarvestableCommand { get; private set; }

        public ICommand RemoveHarvestableCommand { get; private set; }

        public GardenViewModel(Garden garden, INavigationService nav)
        {
            _Nav = nav;
            Name = garden.Name;
            Size = garden.Size;
            Plants = garden.Harvestables;
            HarvestableSelectCommand = new Command(HarvestableSelect, CanExecuteSelect);
            RemoveHarvestableCommand = new Command(RemoveHarvestable, CanExecuteSelect);
            AddHarvestableCommand = new Command(AddHarvestable, CanExecuteSelect);
        }

        void HarvestableSelect(object obj)
        {
            Plant plant = (Plant)obj;
            _Nav.NavigateTo(new HarvestableViewModel(plant));
        }


        void AddHarvestable(object obj)
        { 

        }

        void RemoveHarvestable(object obj)
        {

        }


        bool CanExecuteSelect(object obj)
        {
            return true;
        }
    }
}
