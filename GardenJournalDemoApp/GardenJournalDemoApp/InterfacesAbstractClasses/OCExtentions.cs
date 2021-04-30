using GardenJournalDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GardenJournalDemoApp.InterfacesAbstractClasses
{
    public static class OCExtentions
    {
        public static Garden FindByName(this ObservableCollection<Garden> list, string name)
        {
            foreach(Garden g in list)
            {
                if (g.Name.Equals(name))
                {
                    return g;
                }
            }
            return null;
        }
    }
}
