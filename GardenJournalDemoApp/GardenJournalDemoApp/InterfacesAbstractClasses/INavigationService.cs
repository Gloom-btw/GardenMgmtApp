using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GardenJournalDemoApp.InterfacesAbstractClasses
{
    public interface INavigationService
    {
        void PresentAsMainPage(BaseViewModel viewModel);

        void PresentAsNavigatableMainPage(BaseViewModel viewModel);

        Task NavigateTo(BaseViewModel viewModel);

        Task NavigateBack();

        Task NavigateBackToRoot();
    }
}
