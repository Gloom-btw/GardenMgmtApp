using GardenJournalDemoApp.Models;
using GardenJournalDemoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GardenJournalDemoApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GardenView : ContentPage
    {
        public GardenView()
        {
            InitializeComponent();
        }
    }
}