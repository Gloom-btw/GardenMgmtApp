using GardenJournalDemoApp.InterfacesAbstractClasses;
using GardenJournalDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace GardenJournalDemoApp.ViewModels
{
    class GardenViewModel : BaseViewModel
    {
        INavigationService _Nav;

        IDialogueService _Dia;

        AddItemViewModel AddModel;

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

        ObservableCollection<Plant> _Plants;

        public ObservableCollection<Plant> Plants
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

        public GardenViewModel(Garden garden, INavigationService nav, IDialogueService dia)
        {
            _Nav = nav;
            _Dia = dia;
            AddModel = new AddItemViewModel(_Nav, _Dia);
            Name = garden.Name;
            Size = garden.Size;
            Plants = garden.Harvestables;
            HarvestableSelectCommand = new Command(HarvestableSelect, CanExecuteSelect);
            RemoveHarvestableCommand = new Command(RemoveHarvestable, CanExecuteSelect);
            AddHarvestableCommand = new Command(AddHarvestable, CanExecuteSelect);
        }

        void HarvestableSelect(object obj)
        {
            // Feature coming soon :)
        }


        void AddHarvestable(object obj)
        {
            AddModel.ItemAdded += ItemAdded;
            _Nav.NavigateTo(AddModel);
        }

        void ItemAdded(object sender, SelectedItemEventArgs e)
        {
            Plant plant = (Plant)e.Selected;
            if(Plants == null)
            {
                Plants = new ObservableCollection<Plant>();
            }
            Plants.Add(plant);
            AddModel.ItemAdded -= ItemAdded;
        }

        async void RemoveHarvestable(object obj)
        {
            var names = GetHarvestableNames();
            string toRemove = await _Dia.DisplayActionSheet("Select Item To Remove", "Cancel", null, names);
            if (!String.IsNullOrEmpty(toRemove))
            {
                Plant plant = Plants.FindByName(toRemove);
                Plants.Remove(plant);
            }
        }

        string [] GetHarvestableNames()
        {
            List<string> names = new List<string>();
            foreach(Plant h in Plants)
            {
                names.Add(h.Name);
            }
            return names.ToArray();
        }


        bool CanExecuteSelect(object obj)
        {
            return true;
        }
    }
}
