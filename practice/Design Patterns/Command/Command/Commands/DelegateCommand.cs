﻿using System;
using System.Windows.Input;

namespace Command.Commands
{
    internal class DelegateCommand : ICommand
    {
        private readonly Action action;


        public DelegateCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}