using GardenJournalDemoApp.InterfacesAbstractClasses;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace GardenJournalDemoApp.Models
{
    public class Garden
    {
        public ObservableCollection<Plant> Harvestables { get; set; }

        public string Name { get; set; }

        public string Size { get => GetWidth(Length, Width); }

        public int? Width { get; set; }

        public int? Length { get; set; }

        public ImageSource Image {get; set;}

        Func<int?, int?, string> GetWidth = (l, w) => l.ToString() + " x " + w.ToString();
    }
}
