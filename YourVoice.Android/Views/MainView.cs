using System;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using YourVoice.Core.ViewModels;
using _android =  Android.Support.V7.Widget;
namespace YourVoice.Android.Views
{
    [Activity(Label = "Your Voice", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {
        private _android.Toolbar mTopToolbar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_Main);

            mTopToolbar = (_android.Toolbar)FindViewById(Resource.Id.my_toolbar);
            SetSupportActionBar(mTopToolbar);
        }
    }
}
