﻿using GameWork.Commands.Actions.Interfaces;
using GameWork.Commands.Interfaces;

namespace GameWork.Commands
{
    public class LogoutCommand : ICommand
    {
        public void Execute(object parameter)
        {
            var castParameter = (ILogout)parameter;
            castParameter.Logout();
        }
    }
}