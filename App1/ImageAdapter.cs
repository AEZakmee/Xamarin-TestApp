
using Android.Content;
using Android.Views;
using Android.Widget;

namespace App1
{
    internal class ImageAdapter : BaseAdapter
    {
        Context context;
        public ImageAdapter(Context c)
        {
            context = c;
        }
        public override int Count { get { return thumbIds.Length; } }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return 0;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView i = new ImageView(context);
            i.SetImageResource(thumbIds[position]);
            i.LayoutParameters = new Gallery.LayoutParams(750, 600);
            i.SetScaleType(ImageView.ScaleType.FitXy);
            return i;
        }
        int[] thumbIds = {
        Resource.Drawable.sample_1,
        Resource.Drawable.sample_2,
        Resource.Drawable.sample_3,
        Resource.Drawable.sample_4,
        Resource.Drawable.sample_5,
        Resource.Drawable.sample_6,
        Resource.Drawable.sample_7
        };

    }
}