using System;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using YourVoice.Core.ViewModels;

namespace YourVoice.Views
{
    [Activity(Label = "Your Voice", MainLauncher = true,Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainView: MvxAppCompatActivity<MainViewModel>
    {
        private Android.Support.V7.Widget.Toolbar mTopToolbar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_Main);

            mTopToolbar = (Toolbar)FindViewById(Resource.Id.my_toolbar);
            SetSupportActionBar(mTopToolbar);
        }
    }
}
