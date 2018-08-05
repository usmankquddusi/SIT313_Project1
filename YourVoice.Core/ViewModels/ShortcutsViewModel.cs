using System;
using System.Collections.Generic;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using YourVoice.Core.Helpers;

namespace YourVoice.Core.ViewModels
{
    public class ShortcutsViewModel:MvxViewModel,IMvxNotifyPropertyChanged
    {
        public  IList<string> Data;

        private IMvxCommand _AddCommand;
        public IMvxCommand AddCommand
        {
            get
            {
                _AddCommand = _AddCommand ?? new MvxCommand(() => 
                {
                    
                });
                return _AddCommand;
            }
        }
        public ShortcutsViewModel()
        {

        }
    }
}
