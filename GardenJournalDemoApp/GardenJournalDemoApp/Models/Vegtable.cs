using GardenJournalDemoApp.InterfacesAbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardenJournalDemoApp.Models
{
    public class Vegtable : Plant
    {
        public override string GetHarvestInstructions()
        {
            return "Sample Harvest Instructions Vegtable";
        }
    }
}
