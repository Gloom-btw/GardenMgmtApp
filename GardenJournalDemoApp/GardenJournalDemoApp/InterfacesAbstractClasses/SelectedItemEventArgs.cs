using System;
using System.Collections.Generic;
using System.Text;

namespace GardenJournalDemoApp.InterfacesAbstractClasses
{
    public class SelectedItemEventArgs : EventArgs
    {
        public object ToRemove { get; set; }
    }
}
