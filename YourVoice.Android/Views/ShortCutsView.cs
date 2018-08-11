using System;
using System.Collections.Generic;
using Android.App;
using System.Linq;
using Android.OS;
using YourVoice.Core.Helpers;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using YourVoice.Core.ViewModels;
using Android.Content;
using Android.Views;
using _android = Android.Support.V7.Widget;
namespace YourVoice.Android.Views
{
    [Activity(Label = "Configure Shortcuts", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class ShortCutsView: MvxAppCompatActivity<ShortcutsViewModel>
    {
        public Dictionary<string, string> Data;
        public List<string> keys;
        public List<string> values;

        private _android.Toolbar mTopToolbar;
        private ListView _list;
        private Button _addButton;
        private EditText _key;
        private EditText _value;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_Shortcuts);

            mTopToolbar = (_android.Toolbar)FindViewById(Resource.Id.my_toolbar);
            SetSupportActionBar(mTopToolbar);

            _list = FindViewById<ListView>(Resource.Id.shortcuts_list_view);
            _addButton = FindViewById<Button>(Resource.Id.btnAdd);
            _addButton.Click+= _addButton_Click;
            _key = FindViewById<EditText>(Resource.Id.etKey);
            _value = FindViewById<EditText>(Resource.Id.etValue);

            keys = new List<string>();
            values = new List<string>();
            Data = new Dictionary<string, string>();

            Inits();
            _list.LongClick+= _list_LongClick;


        }

        void _list_LongClick(object sender, View.LongClickEventArgs e)
        {
            //var list = sender as ListView;
            //Data.Remove(keys[e.]);
            //Settings.DataList = parent.Data;

            //parent.Inits();
        }


        void _addButton_Click(object sender, EventArgs e)
        {
            var linq = (from p in Settings.DataList
                        where _key.Text == p.Key
                        select p).Any();
            if (linq)
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                AlertDialog alert = dialog.Create();
                alert.SetTitle("Error");
                alert.SetMessage("You can not two similar keys !");
                alert.SetButton("OK", (c, ev) =>
                {
                    // Ok button click task  
                });
                alert.Show();
            }
            else
            {
                var oldList = Settings.DataList;
                oldList.Add(_key.Text, _value.Text);
                Settings.DataList = oldList;
                Inits();
            }
        }

        public void Inits()
        {

            Data = Settings.DataList;
            keys = new List<string>();
            values = new List<string>();
            foreach (var item in Data)
            {
                keys.Add(item.Key);
                values.Add(item.Value);
            }
            var adapter = new ShortcutsAdapter(this, keys, values);
            _list.Adapter = adapter;
            adapter.NotifyDataSetChanged();

        }

      

        public class ShortcutsAdapter: BaseAdapter < Dictionary<string,string> > {  
            public List < string > keys;  
            public List<string> values;
            private Context sContext;  
            public ShortcutsAdapter(Context context, List < string > _keys,List<string> _values) 
            {
                
                keys = _keys;
                values = _values;
                sContext = context;  
            }  
            public override Dictionary<string,string> this[int position] {  
        get 
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    for (int i = 0; i < keys.Count; i++)
                    {
                        dic.Add(keys[i], values[i]);
                    }

                    return dic;
        }  
    }  
    public override int Count {  
        get {  
                    return keys.Count;  
        }  
    }  
    public override long GetItemId(int position) {  
        return position;  
    }  

    public override View GetView(int position, View convertView, ViewGroup parent) {  
        View row = convertView;  
        try {  
            if (row == null) {  
                row = LayoutInflater.From(sContext).Inflate(Resource.Layout.shortcut_list_template, null, false);  
            }  
                    TextView txtKey = row.FindViewById < TextView > (Resource.Id.txtKey);
                    TextView txtValue = row.FindViewById<TextView>(Resource.Id.txtValue);
                    txtKey.Text = keys[position];
                    txtValue.Text = values[position];
        } catch (Exception ex) {  
            System.Diagnostics.Debug.WriteLine(ex.Message);  
        } finally {}  
        return row;  
    }  



}  

    }
}
