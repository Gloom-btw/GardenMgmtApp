using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GardenJournalDemoApp.InterfacesAbstractClasses
{
    public interface IViewModelLifecycle
    {
        Task BeforeFirstShown();

        Task AfterDismissed();
    }
}
