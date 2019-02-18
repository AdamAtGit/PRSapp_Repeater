using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PRSapp.ViewModels.Commands
{
    public class RepeatMediaOutAsyncCommand : ICommand
    {
        public RepeaterViewModel ViewModel { get; set; }

        public RepeatMediaOutAsyncCommand(RepeaterViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)//Repeater repeater
        {
            //ViewModel.RepeatMediaSpeakAsync();
        }
    }
}
