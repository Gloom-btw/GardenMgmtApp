using GardenJournalDemoApp.InterfacesAbstractClasses;
using GardenJournalDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace GardenJournalDemoApp.ViewModels
{
    public class AddGardenViewModel : BaseViewModel
    {
        IDialogueService _Dia;

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

        int? _Width;

        public int? Width
        {
            get => _Width;
            set
            {
                _Width = value;
                OnPropertyChanged("Width");
            }
        }

        int? _Length;

        public int? Length
        {
            get => _Length;
            set
            {
                _Length = value;
                OnPropertyChanged("Length");
            }
        }

        public ICommand NameEntryCommand { get; private set; }

        public ICommand LengthEntryCommand { get; private set; }

        public ICommand WidthEntryCommand { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public AddGardenViewModel(IDialogueService dia, INavigationService nav)
        {
            _Dia = dia;
            _Nav = nav;
            NameEntryCommand = new Command(NameEntry, CanExecute);
            LengthEntryCommand = new Command(LengthEntry, CanExecute);
            WidthEntryCommand = new Command(WidthEntry, CanExecute);
            SaveCommand = new Command(Save, CanExecute);
        }

        void NameEntry(object name)
        {
            string newName = (string)name;
            Name = newName;
        }

        void LengthEntry(object length)
        {
            string newLength = (string)length;
            Length = Int32.Parse(newLength);
        }

        void WidthEntry(object width)
        {
            string newWidth = (string)width;
            Width = Int32.Parse(newWidth);
        }

        void Save(object obj)
        {
            if(ValidateGarden())
            {
                Garden g = new Garden();
                g.Name = _Name;
                g.Width = _Width;
                g.Length = _Length;

                ItemAdded(this, new SelectedItemEventArgs { Selected = g });
                _Nav.NavigateBack();
            }
            else
            {
                _Dia.ShowMessage("Invalid Input", "Please fill all fields.", "Ok");
            }
        }

        bool ValidateGarden()
        {
            if(Name == null || Length == null || Width == null)
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
