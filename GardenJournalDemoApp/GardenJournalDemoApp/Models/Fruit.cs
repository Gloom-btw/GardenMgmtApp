using GardenJournalDemoApp.InterfacesAbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardenJournalDemoApp.Models
{
    public class Fruit : Plant
    {
        public override string GetHarvestInstructions()
        {
            return "Sample Harvest Instructions Fruit";
        } 
    }
}
