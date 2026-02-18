using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TodoApp.Client.Infrastructure
{
    public class RelayCommand : ICommand
    {
        //ButtonなどのUI操作をViewModelの処理へバインドする
        private readonly Func<object?, Task>? _executeAsync;
        private readonly Action<object?>? _executeSync;
        private readonly Func<object?, bool>? _canExecute;

        public RelayCommand(Func<Task> executeAsync)
            : this(async _ => await executeAsync(), null, null) { }

        public RelayCommand(Func<object?, Task> executeAsync)
            : this(executeAsync, null, null) { }

        public RelayCommand(Action executeSync)
            : this(null, _ => executeSync(), null) { }

        public RelayCommand(Action<object?> executeSync)
            : this(null, executeSync, null) { }

        public RelayCommand(
            Func<object?, Task>? executeAsync,
            Action<object?>? executeSync,
            Func<object?, bool>? canExecute = null)
        {
            _executeAsync = executeAsync;
            _executeSync = executeSync;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
            => _canExecute?.Invoke(parameter) ?? true;

        public async void Execute(object? parameter)
        {
            try
            {
                if (_executeAsync != null)
                    await _executeAsync(parameter);
                else
                    _executeSync?.Invoke(parameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RaiseCanExecuteChanged()
            => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}