using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    [Activity(Label = "ActivityGalery")]
    public class ActivityGalery : Activity
    {
        Button back;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.gallery);
            back = FindViewById<Button>(Resource.Id.button1);
            Gallery gallery = (Gallery)FindViewById<Gallery>(Resource.Id.gallery);
            gallery.Adapter = new ImageAdapter(this);
            gallery.ItemClick += delegate (object sender,
            Android.Widget.AdapterView.ItemClickEventArgs args) {
                Toast.MakeText(this, args.Position.ToString(),
            ToastLength.Short).Show();
            };
            back.Click += Back_Click;
            // Create your application here
        }
        private void Back_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}