
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
using Android.Widget;

namespace GlobalLayoutEvent
{
    [Activity(Label = "CSharpStyleActivity", Theme = "@style/Theme.AppCompat")]
    public class CSharpStyleActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.general_layout);
        }

        public override void SetContentView(int layoutResID)
        {
            var view = this.LayoutInflater.Inflate(layoutResID, null);

            EventHandler onGlobalLayout = null;
            onGlobalLayout = (sender, args) =>
            {
                view.ViewTreeObserver.GlobalLayout -= onGlobalLayout;
                System.Diagnostics.Debug.WriteLine("Global Layout Happened");
            };

            view.ViewTreeObserver.GlobalLayout += onGlobalLayout;

            SetContentView(view);
        }
    }
}
