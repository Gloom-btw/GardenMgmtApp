using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GardenJournalDemoApp.InterfacesAbstractClasses
{
    public abstract class BaseViewModel : BindableObject, IViewModelLifecycle
    {
        public Type DataModelType { get; private set; }

        public void SetDataModelType(Type type)
        {
            DataModelType = type;
        }

        public virtual Task BeforeFirstShown()
        {
            return Task.CompletedTask;
        }

        public virtual Task AfterDismissed()
        {
            return Task.CompletedTask;
        }
    }
}
