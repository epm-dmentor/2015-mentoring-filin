﻿using System;
using System.Windows.Input;

namespace Command.Commands
{
    public class RelayCommand : ICommand
    {
        private Predicate<object> canExecute;
        private Action<object> execute;

        public RelayCommand(Action<object> execute)
            : this(execute, DefaultCanExecute)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute != null && canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        private event EventHandler CanExecuteChangedInternal;

        public void OnCanExecuteChanged()
        {
            if (CanExecuteChangedInternal != null) CanExecuteChangedInternal(this, EventArgs.Empty);
        }

        public void Destroy()
        {
            canExecute = _ => false;
            execute = _ => { };
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
    }
}