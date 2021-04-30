using GardenJournalDemoApp.InterfacesAbstractClasses;
using GardenJournalDemoApp.Pages;
using GardenJournalDemoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GardenJournalDemoApp.Services
{
    public class ViewLocator : IViewLocator
    {

        private static Dictionary<Type, Type> BindingResource = new Dictionary<Type, Type> 
        {   
            {typeof(MainViewModel), typeof(MainView) }, {typeof(GardenViewModel), typeof(GardenView) },
            {typeof(RemoveGardenViewModel), typeof(RemoveGardenView) }, {typeof(AddGardenViewModel), typeof(AddGardenView) },
            {typeof(AddItemViewModel), typeof(AddItemView) }
        };
        public Page CreateAndBindPageFor<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel
        {
            var pageType = FindPageForViewModel(viewModel.GetType());

            var page = (Page)Activator.CreateInstance(pageType);

            page.BindingContext = viewModel;

            return page;
        }

        protected virtual Type FindPageForViewModel(Type viewModelType)
        {

            return BindingResource[viewModelType];
            
            //var pageTypeName = viewModelType
            //    .AssemblyQualifiedName
            //    .Replace(".Views", ".Pages")
            //    .Replace("ViewModel", "View");
            //
            //var pageType = Type.GetType(pageTypeName);
            //if (pageType == null)
            //    throw new ArgumentException(pageTypeName + " type does not exist");
            //
            //return pageType;
        }
    }
}
