using System;
using System.Collections.Generic;
using System.Text;

namespace GardenJournalDemoApp.InterfacesAbstractClasses
{
    public interface IService
    {
        dynamic RetrieveData();

        bool StoreData();
    }
}
