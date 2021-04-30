using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GardenJournalDemoApp.InterfacesAbstractClasses
{
    public abstract class Plant : IHarvestable
    {
        public string Name { get; set; }

        public DateTime DatePlanted { get; set; }

        public int DaysToHarvest { get; set; }

        public ImageSource Image { get; set; }

        public DateTime HarvestDate { get => getHarvestDate(DatePlanted, DaysToHarvest); }

        Func<DateTime, int, DateTime> getHarvestDate = (d, g) => d.AddDays(g);

        public abstract string GetHarvestInstructions();
    }
}
