
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;

namespace GlobalLayoutEvent
{
    [Activity(Label = "NativeStyleActivity", Theme = "@style/Theme.AppCompat")]
    public class NativeStyleActivity : AppCompatActivity, ViewTreeObserver.IOnGlobalLayoutListener
    {
        private View _View;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.general_layout);
        }

        public override void SetContentView(int layoutResID)
        {
            _View = this.LayoutInflater.Inflate(layoutResID, null);

            _View.ViewTreeObserver.AddOnGlobalLayoutListener(this);

            SetContentView(_View);
        }

        public void OnGlobalLayout()
        {
            if (_View != null)
            {
                if (Build.VERSION.SdkInt < BuildVersionCodes.JellyBean)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    _View.ViewTreeObserver.RemoveGlobalOnLayoutListener(this);
#pragma warning restore CS0618 // Type or member is obsolete
                }
                else
                {
                    _View.ViewTreeObserver.RemoveOnGlobalLayoutListener(this);
                }
                System.Diagnostics.Debug.WriteLine("Global Layout Happened");
            }
        }
    }
}
