using GardenJournalDemoApp.InterfacesAbstractClasses;
using GardenJournalDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GardenJournalDemoApp.ViewModels
{
    public class AddItemViewModel : BaseViewModel
    {
        INavigationService _Nav;
        IDialogueService _Dia;

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

        DateTime _DatePlanted;

        public DateTime DatePlanted
        {
            get => _DatePlanted;
            set
            {
                _DatePlanted = value;
                OnPropertyChanged("DatePlanted");
            }
        }

        int _DaysToHarvest;

        public int DaysToHarvest
        {
            get => _DaysToHarvest;
            set
            {
                _DaysToHarvest = value;
                OnPropertyChanged("DaysToHarvest");
            }
        }


        public ICommand NameEntryCommand { get; private set; }

        public ICommand DTHEntryCommand { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public AddItemViewModel(INavigationService nav, IDialogueService dia)
        {
            _Nav = nav;
            _Dia = dia;

            NameEntryCommand = new Command(NameEntry, CanExecute);
            DTHEntryCommand = new Command(DTHEntry, CanExecute);
            SaveCommand = new Command(Save, CanExecute);
        }

        void NameEntry(object name)
        {
            string newName = (string)name;
            Name = newName;
        }

        void DTHEntry(object daysToHarvest)
        {
            string newDTH = (string)daysToHarvest;
            DaysToHarvest = Int32.Parse(newDTH);
        }

        void Save(object obj)
        {
            if (ValidateItem())
            {
                Plant p = new Vegtable();
                p.Name = _Name;
                p.DaysToHarvest = _DaysToHarvest;
                p.DatePlanted = _DatePlanted;

                ItemAdded(this, new SelectedItemEventArgs { Selected = p });
                _Nav.NavigateBack();
            }
            else
            {
                _Dia.ShowMessage("Invalid Input", "Please fill all fields.", "Ok");
            }
        }

        bool ValidateItem()
        {
            if (Name == null || DaysToHarvest.Equals(null) || DatePlanted == null)
            {
                return false;
            }
            return true;
        }

        bool CanExecute(object obj)
        {
            return true;
        }

        public event EventHandler<SelectedItemEventArgs> ItemAdded;
    }
}
