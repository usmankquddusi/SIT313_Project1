using System;
using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using Plugin.TextToSpeech;
using YourVoice.Core.ViewModels;
using _android = Android.Support.V7.Widget;
namespace YourVoice.Android.Views
{
    [Activity(Label = "Play Voice", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class PlayView: MvxAppCompatActivity<PlayViewModel>
    {
        Button button;
        private _android.Toolbar mTopToolbar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_Play);

            mTopToolbar = (_android.Toolbar)FindViewById(Resource.Id.my_toolbar);
            SetSupportActionBar(mTopToolbar);

             button = FindViewById<Button>(Resource.Id.btnPlay);
            button.Click+= Button_Click;
        }

        void Button_Click(object sender, EventArgs e)
        {
            CrossTextToSpeech.Current.Speak(button.Text, null, 0.5f, 0.5f, 0.5f);
        }

    }
}
