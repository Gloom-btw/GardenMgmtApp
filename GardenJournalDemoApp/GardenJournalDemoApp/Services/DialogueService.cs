using GardenJournalDemoApp.InterfacesAbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GardenJournalDemoApp.Services
{
    public class DialogueService : IDialogueService
    {
        public async void ShowMessage(string title, string message, string buttonText)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, buttonText);
        }

        public async Task<string> DisplayActionSheet(string title, string cancel, string destruct, params string[] buttons)
        {
            return await Application.Current.MainPage.DisplayActionSheet(title, cancel, destruct, buttons);
        }
    }
}
