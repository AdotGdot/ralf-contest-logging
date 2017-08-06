using Ralf.ScratchPadMemory.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace Ralf.ScratchPadMemory.Views
{
    /// <summary>
    /// Interaction logic for ScratchPadView.xaml
    /// </summary>
    public partial class ScratchPadView : Window
    {
        public ScratchPadView(IScratchPadViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            this.callsignTextBox.KeyUp += viewModel.callsignTextBox_KeyUp;
            setCallsignTextBoxFocus();
        }

        private void setCallsignTextBoxFocus()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(
                   (a) =>
                   {
                       System.Threading.Thread.Sleep(300);
                       callsignTextBox.Dispatcher.Invoke(
                       new Action(() =>
                       {
                           callsignTextBox.Focus();
                       }));
                   });
        }


    }
}
