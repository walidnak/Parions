using Caliburn.Micro;
using Parions.ViewModels;
using System.Windows;

namespace Parions
{
    class BootStrapper : BootstrapperBase
    {
        public BootStrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<BackViewModel>();
        }

    }
}
