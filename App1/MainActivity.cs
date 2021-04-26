using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button GalleryB;
        Button WebViewB;
        Button PaintB;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            GalleryB = FindViewById<Button>(Resource.Id.GalleryBUT);
            WebViewB = FindViewById<Button>(Resource.Id.WebViewBUT);
            PaintB = FindViewById<Button>(Resource.Id.PaintBUT);
            GalleryB.Click += GalleryB_Click;
            WebViewB.Click += WebViewB_Click;
            PaintB.Click += PaintB_Click;
        }
        private void PaintB_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(ActivityPaint));
        }
        private void GalleryB_Click(object sender, System.EventArgs e)

        {
            StartActivity(typeof(ActivityGalery));
        }
        private void WebViewB_Click(object sender, System.EventArgs e)
        {
           StartActivity(typeof(ActivityWebView));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}