﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tomorrow_Is_Stock_King.ViewModel.Commands.GameMainWindowCommands
{
    public class RepaymentCommand : ICommand
    {
        GameTurnVM GameTurnVM { get; set; }

        public RepaymentCommand(GameTurnVM vm)
        {
            GameTurnVM = vm;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null) return true;
            if ((string)parameter == "") return false;
            string str = (string)parameter;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if ((int)str[i] > 46 && (int)str[i] < 58)
                {

                }
                else
                {
                    return false;
                }
            }
            if (GameTurnVM.SettingVM.PlayerVM.PlayerDataToShow.CurMoney < long.Parse((string)parameter) || GameTurnVM.SettingVM.PlayerVM.PlayerDataToShow.LoanMoney < long.Parse((string)parameter)) 
            {
                return false;
            }
            
            return true;
        }

        public void Execute(object parameter)
        {
            if (GameTurnVM.SoundVM.SoundDataToShow.IsTurnOnEffect)
            {
                GameTurnVM.SoundVM.playClickSound();
            }

            GameTurnVM.RepaymentLoan(long.Parse((string)parameter));
        }
    }
}
