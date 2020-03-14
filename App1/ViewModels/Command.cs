using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        bool _CanExecute = true;
        Func<Task> _FT;

        private void RaiseCanExecuteChanged()
        {
            if(CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute;    
        }

        public async void Execute(object parameter)
        {
            _CanExecute = false;
            RaiseCanExecuteChanged();

            await _FT();

            _CanExecute = true;
            RaiseCanExecuteChanged();
        }

        public Command(Func<Task> func)
        {
            _FT = func;
        }
    }
}
