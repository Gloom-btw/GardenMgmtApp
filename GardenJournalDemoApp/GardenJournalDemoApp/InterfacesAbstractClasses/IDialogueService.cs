using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GardenJournalDemoApp.InterfacesAbstractClasses
{
    public interface IDialogueService
    {
        void ShowMessage(string title, string message, string buttonText);

        Task<string> DisplayActionSheet(string title, string cancel, string destruct, params string[] buttons);
    }
}
