using GardenJournalDemoApp.InterfacesAbstractClasses;
using GardenJournalDemoApp.Services;
using GardenJournalDemoApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GardenJournalDemoApp
{
    public partial class App : Application, IMainPage
    {
        public App()
        {
            InitializeComponent();

            var navigator = new NavigationService(this, new ViewLocator());

            var rootViewModel = new MainViewModel(new ApiService(), new DialogueService(), navigator);

            navigator.PresentAsNavigatableMainPage(rootViewModel);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
