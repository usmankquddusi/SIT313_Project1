using System;
using MvvmCross;
using MvvmCross.ViewModels;
using YourVoice.Core.ViewModels;

namespace YourVoice.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainViewModel>();
        }
    }
}
