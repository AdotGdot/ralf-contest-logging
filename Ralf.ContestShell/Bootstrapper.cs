using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Prism.Modularity;
using Prism.Unity;
using Ralf.ContestLogging.Common.Types;
using System.Windows;

namespace Ralf.ContestShell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }
        protected override IUnityContainer CreateContainer()
        {
            var iuc = base.CreateContainer();
            iuc.LoadConfiguration("ContestContainer");
            Application.Current.Resources.Add("UnityContainer", iuc);
            return iuc;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new AggregateModuleCatalog();
        }

        protected override void ConfigureModuleCatalog()
        {
            ConfigurationModuleCatalog configurationCatalog = new ConfigurationModuleCatalog();
            ((AggregateModuleCatalog)ModuleCatalog).AddCatalog(configurationCatalog);
        }
    }
}

