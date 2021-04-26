using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace App1
{
    [Activity(Label = "ActivityWebView")]
    public class ActivityWebView : Activity
    {
        Button back;
        WebView web_view;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.webview);
            back = FindViewById<Button>(Resource.Id.button1);
            web_view = FindViewById<WebView>(Resource.Id.webview);
            // Create your application here
            web_view.Settings.JavaScriptEnabled = true;
            web_view.SetWebViewClient(new HelloWebViewClient());
            web_view.LoadUrl("https://tu-sofia.bg/");
        }
        public override bool OnKeyDown(Android.Views.Keycode keyCode, Android.Views.KeyEvent
e)
        {
            if (keyCode == Keycode.Back && web_view.CanGoBack())
            {
                web_view.GoBack();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}