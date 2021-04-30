using GardenJournalDemoApp.InterfacesAbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardenJournalDemoApp.ViewModels
{
    public class HarvestableViewModel : BaseViewModel
    {
        string _Name;

        DateTime _DatePlanted;

        int _DaysToHarvest;

        DateTime _HarvestDate;

        string _HarvestInstructions;

        public HarvestableViewModel(Plant plant)
        {
            
        }
    }
}
