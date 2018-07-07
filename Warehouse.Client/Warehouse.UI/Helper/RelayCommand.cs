// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the RelayCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UI.Helper
{
    using System;
    using System.Windows.Input;

    /// <inheritdoc />
    /// <summary>
    /// The relay command.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The execute.
        /// </summary>
        private readonly Action<object> execute;

        /// <summary>
        /// The can execute.
        /// </summary>
        private readonly Predicate<object> canExecute;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RemoteNotepad.UI.ViewModel.RelayCommand" /> class.
        /// </summary>
        /// <param name="execute">
        /// The execute.
        /// </param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">
        /// The execute.
        /// </param>
        /// <param name="canExecute">
        /// The can execute.
        /// </param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        #region ICommand Members

        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// The can execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Boolean" />.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute?.Invoke(parameter) ?? true;
        }

        /// <inheritdoc />
        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        #endregion
    }
}