using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GardenJournalDemoApp.InterfacesAbstractClasses
{
    public interface IViewLocator
    {
        Page CreateAndBindPageFor<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel;
    }
}
