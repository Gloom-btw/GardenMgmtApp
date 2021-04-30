using GardenJournalDemoApp.InterfacesAbstractClasses;
using GardenJournalDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using GardenJournalDemoApp.Services;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup;


namespace GardenJournalDemoApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        IService _Service;
        IDialogueService _Dia;
        INavigationService _Nav;
        ObservableCollection<Garden> _Gardens;
        BaseViewModel AddModel;

        public ObservableCollection<Garden> Gardens 
        {
            get => _Gardens;
            set
            {
                _Gardens = value;
                OnPropertyChanged("Gardens");
            }
        }

        public ICommand AddGardenCommand { get; private set; }

        public ICommand RemoveGardenCommand { get; private set; }

        public ICommand GardenSelectedCommand { get; private set; }

        public MainViewModel(IService service, IDialogueService dia, INavigationService nav)
        {
            _Service = service;
            _Dia = dia;
            _Nav = nav;
            PopGarden();
            SetDataModelType(typeof(GardenList));
            AddGardenCommand = new Command(AddGarden, CanExecute);
            RemoveGardenCommand = new Command(RemoveGarden, CanExecute);
            GardenSelectedCommand = new Command(GardenSelected, CanExecuteSelected);

        }

        void AddGarden()
        {
            
            _Dia.ShowMessage("Add Garden", " ", "Ok");
        }

        async void RemoveGarden()
        {
            var names = GetGardenNames();
            string toRemove =  await _Dia.DisplayActionSheet("Select Garden To Remove", "Cancel", null, names);
            if(!String.IsNullOrEmpty(toRemove))
            {
                Garden garden = Gardens.FindByName(toRemove);
                Gardens.Remove(garden);
            }
            //Gardens = _Gardens;
            //OnPropertyChanged("Gardens");
        }

        async void GardenSelected(object obj)
        {
            Garden selectedItem = (Garden)obj;
            await _Nav.NavigateTo(new GardenViewModel(selectedItem, _Nav));
        }
            

        bool CanExecute()
        {
            return true;
        }

        bool CanExecuteSelected(object obj)
        {
            return true;
        }

        string [] GetGardenNames()
        {
            List<string> nameList = new List<string>();
            foreach(Garden g in _Gardens)
            {
                nameList.Add(g.Name);
            }
            return nameList.ToArray();
        }

        void PopGarden()
        {
            Gardens = new ObservableCollection<Garden>();
            Gardens.Add(new Garden
            {
                Name = "West Side Garden",
                Length = 14,
                Width = 14,
                Image = ImageSource.FromFile("otr.png"),
                Harvestables = new ObservableCollection<IHarvestable> { 
                new Fruit { Name = "Strawberries", DatePlanted = DateTime.Today.Date, DaysToHarvest = 60, 
                    Image = ImageSource.FromFile("strawberries.png")},
                new Vegtable {Name = "Beans", DatePlanted = DateTime.Today.Date, DaysToHarvest = 90, Image = ImageSource.FromFile("beans.png") },
                new Fruit {Name = "Blueberries", DatePlanted = DateTime.Today.Date, DaysToHarvest = 120, Image = ImageSource.FromFile("blueBerries.png") },
                new Vegtable {Name = "Cabbage", DatePlanted = DateTime.Today.Date, DaysToHarvest = 70, Image = ImageSource.FromFile("cabbage.png") } }

            });

            Gardens.Add(new Garden
            {
                Name = "East Side Garden",
                Length = 14,
                Width = 14,
                Image = ImageSource.FromFile("otr.png"),
                Harvestables = new ObservableCollection<IHarvestable> { 
                new Fruit { Name = "Strawberries", DatePlanted = DateTime.Today.Date, DaysToHarvest = 60,
                    Image = ImageSource.FromFile("strawberries.png")},
                new Vegtable {Name = "Beans", DatePlanted = DateTime.Today.Date, DaysToHarvest = 90, Image = ImageSource.FromFile("beans.png") },
                new Fruit {Name = "Blueberries", DatePlanted = DateTime.Today.Date, DaysToHarvest = 120, Image = ImageSource.FromFile("blueBerries.png") },
                new Vegtable {Name = "Cabbage", DatePlanted = DateTime.Today.Date, DaysToHarvest = 70, Image = ImageSource.FromFile("cabbage.png") } }

            });

            Gardens.Add(new Garden
            {
                Name = "South Side Garden",
                Length = 14,
                Width = 14,
                Image = ImageSource.FromFile("otr.png"),
                Harvestables = new ObservableCollection<IHarvestable> { 
                new Fruit { Name = "Strawberries", DatePlanted = DateTime.Today.Date, DaysToHarvest = 60,
                    Image = ImageSource.FromFile("strawberries.png")},
                new Vegtable {Name = "Beans", DatePlanted = DateTime.Today.Date, DaysToHarvest = 90, Image = ImageSource.FromFile("beans.png") },
                new Fruit {Name = "Blueberries", DatePlanted = DateTime.Today.Date, DaysToHarvest = 120, Image = ImageSource.FromFile("blueBerries.png") },
                new Vegtable {Name = "Cabbage", DatePlanted = DateTime.Today.Date, DaysToHarvest = 70, Image = ImageSource.FromFile("cabbage.png") } }

            });

            Gardens.Add(new Garden
            {
                Name = "North Side Garden",
                Length = 14,
                Width = 14,
                Image = ImageSource.FromFile("otr.png"),
                Harvestables = new ObservableCollection<IHarvestable> { 
                new Fruit { Name = "Strawberries", DatePlanted = DateTime.Today.Date, DaysToHarvest = 60,
                    Image = ImageSource.FromFile("strawberries.png")},
                new Vegtable {Name = "Beans", DatePlanted = DateTime.Today.Date, DaysToHarvest = 90, Image = ImageSource.FromFile("beans.png") },
                new Fruit {Name = "Blueberries", DatePlanted = DateTime.Today.Date, DaysToHarvest = 120, Image = ImageSource.FromFile("blueBerries.png") },
                new Vegtable {Name = "Cabbage", DatePlanted = DateTime.Today.Date, DaysToHarvest = 70, Image = ImageSource.FromFile("cabbage.png") } }

            });
        }
    }
}
