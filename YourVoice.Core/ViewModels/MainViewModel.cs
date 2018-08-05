using System;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace YourVoice.Core.ViewModels
{
    public class MainViewModel:MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        private IMvxCommand _showPlayCommand;
        public IMvxCommand ShowPlayCommand
        {
            get
            {
                _showPlayCommand = _showPlayCommand ?? new MvxCommand(() => _navigationService.Navigate<PlayViewModel>());
                return _showPlayCommand;
            }
        }

        private IMvxCommand _showShortcutsCommand;
        public IMvxCommand ShowShortcutsCommand
        {
            get
            {
                _showShortcutsCommand = _showShortcutsCommand ?? new MvxCommand(() => _navigationService.Navigate<ShortcutsViewModel>());
                return _showShortcutsCommand;
            }
        }

    }
}
