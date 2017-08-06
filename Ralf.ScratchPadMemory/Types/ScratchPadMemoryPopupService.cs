using Microsoft.Practices.Unity;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ScratchPadMemory.ViewModels;
using Ralf.ScratchPadMemory.Views;
using System.Windows;


namespace Ralf.ScratchPadMemory.Types
{
    public class ScratchPadMemoryPopupService : IScratchPadMemoryPopupService
    {
        public void PopupScratchPadMemoryView()
        {
            IUnityContainer container = (IUnityContainer)Application.Current.Resources["UnityContainer"];
            ScratchPadView view = (ScratchPadView)container.Resolve<ScratchPadView>();
            ScratchPadViewModel viewModel = view.DataContext as ScratchPadViewModel;
            view.Owner = Application.Current.MainWindow;
            bool? b = view.ShowDialog();
        }
    }
}
