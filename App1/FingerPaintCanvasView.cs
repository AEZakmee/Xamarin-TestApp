using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;

namespace App1
{
    public class FingerPaintCanvasView : View
    {
        // създаване на колекции за съхраняване на изчертаното
        Dictionary<int, FingerPaintPolyline> inProgressPolylines = new Dictionary<int,
        FingerPaintPolyline>();
        List<FingerPaintPolyline> completedPolylines = new
        List<FingerPaintPolyline>();
        // създаване на обект от тип paint
        Paint paint = new Paint();
        // създаване на конструктори
        public FingerPaintCanvasView(Context context) : base(context)
        {
            Initialize();
        }
        public FingerPaintCanvasView(Context context, IAttributeSet attrs) :
        base(context, attrs)
        {
            Initialize();
        }

        void Initialize()
        {
        }
        // get и set методи и задаване на цвят Червен и дебелина на линията
        public Color StrokeColor { set; get; } = Color.Red;
        public float StrokeWidth { set; get; } = 2;
        //метод за изтриване на начертаното
        public void ClearAll()
        {
            completedPolylines.Clear();
            Invalidate();
        }
        // Overrides
        public override bool OnTouchEvent(MotionEvent args)
        {
            // Get the pointer index
            int pointerIndex = args.ActionIndex;
            // взимане на id за индентификация за положението на пръста
            int id = args.GetPointerId(pointerIndex);
            // Use ActionMasked here rather than Action to reduce the number of
            //possibilities
        switch (args.ActionMasked)

            {
                case MotionEventActions.Down:
                case MotionEventActions.PointerDown:

                    // създаване на линия и инициализирането и съхраняването и
                    FingerPaintPolyline polyline = new FingerPaintPolyline

                    {
                        Color = StrokeColor,
                        StrokeWidth = StrokeWidth

                    };
                    polyline.Path.MoveTo(args.GetX(pointerIndex),
                    args.GetY(pointerIndex));
                    inProgressPolylines.Add(id, polyline);

                    break;

                case MotionEventActions.Move:
                    // Събитията за множество движения са групирани, така че да ги обработвате
                    //по различен начин
        for (pointerIndex = 0; pointerIndex < args.PointerCount;
        pointerIndex++)
                    {
                        id = args.GetPointerId(pointerIndex);
                        inProgressPolylines[id].Path.LineTo(args.GetX(pointerIndex),
                        args.GetY(pointerIndex));
                    }
                    break;

                case MotionEventActions.Up:
                case MotionEventActions.Pointer1Up:
                    inProgressPolylines[id].Path.LineTo(args.GetX(pointerIndex),
                    args.GetY(pointerIndex));
                    // превръщане на създадената линия към завършена линия
                    completedPolylines.Add(inProgressPolylines[id]);

                    inProgressPolylines.Remove(id);

                    break;

                case MotionEventActions.Cancel:
                    inProgressPolylines.Remove(id);

                    break;

            }
            // Invalidate to update the view
            Invalidate();
            // Request continued touch input
            return true;
        }
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            // изтриване на canvas към бял цвят
            paint.SetStyle(Paint.Style.Fill);
            paint.Color = Color.White;
            canvas.DrawPaint(paint);

            // изчертаване
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeCap = Paint.Cap.Round;
            paint.StrokeJoin = Paint.Join.Round;
            // изчертаване на готови линий
            foreach (FingerPaintPolyline polyline in completedPolylines)
            {
                paint.Color = polyline.Color;
                paint.StrokeWidth = polyline.StrokeWidth;
                canvas.DrawPath(polyline.Path, paint);
            }
            // изчертаване на линии
            foreach (FingerPaintPolyline polyline in inProgressPolylines.Values)
            {
                paint.Color = polyline.Color;
                paint.StrokeWidth = polyline.StrokeWidth;
                canvas.DrawPath(polyline.Path, paint);
            }
        }
    }
}