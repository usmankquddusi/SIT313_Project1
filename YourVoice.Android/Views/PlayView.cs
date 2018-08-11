using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Widget;
using Java.Util;
using System.Linq;
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
        EditText et;
        private _android.Toolbar mTopToolbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_Play);

            mTopToolbar = (_android.Toolbar)FindViewById(Resource.Id.my_toolbar);
            SetSupportActionBar(mTopToolbar);

            et = FindViewById<EditText>(Resource.Id.etText);

             button = FindViewById<Button>(Resource.Id.btnPlay);
            button.Click+= Button_Click;
        }

        void Button_Click(object sender, EventArgs e)
        {
            
            var linq = (from p in YourVoice.Core.Helpers.Settings.DataList 
                        where et.Text == p.Key
                        select p).FirstOrDefault();
            if (linq.Key != null)
            {
                CrossTextToSpeech.Current.Speak(linq.Value, null, 0.8f, 0.4f, 1f);
            }
            else
            {
                CrossTextToSpeech.Current.Speak(et.Text, null, 0.8f, 0.4f, 1f);
            }

        }

    }
}
