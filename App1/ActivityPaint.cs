using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    [Activity(Label = "ActivityPaint")]
    public class ActivityPaint : Activity
    {
        Button back;
        Button clear;
        FingerPaintCanvasView fingerPaintCanvasView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.paint);
            back = FindViewById<Button>(Resource.Id.button1);
            clear = FindViewById<Button>(Resource.Id.clearButton);
            clear.Click += OnClearButtonClick;
            back.Click += Back_Click;
            // Create your application here
        }

        private void Back_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
        void OnColorSpinnerItemSelected(object sender,
        AdapterView.ItemSelectedEventArgs args)
        {
            Spinner spinner = (Spinner)sender;
            string strColor = (string)spinner.GetItemAtPosition(args.Position);
            Color strokeColor =
            (Color)(typeof(Color).GetProperty(strColor).GetValue(null));
            fingerPaintCanvasView.StrokeColor = strokeColor;
        }
        void OnWidthSpinnerItemSelected(object sender,
        AdapterView.ItemSelectedEventArgs args)
        {
            Spinner spinner = (Spinner)sender;
            float strokeWidth = new float[] { 2, 5, 10, 20, 50 }[args.Position];
            fingerPaintCanvasView.StrokeWidth = strokeWidth;
        }
        void OnClearButtonClick(object sender, EventArgs args)
        {
            fingerPaintCanvasView.ClearAll();

        }
    }
}