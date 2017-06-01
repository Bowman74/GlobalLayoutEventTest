using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;

namespace GlobalLayoutEvent
{
    [Activity(Label = "GlobalLayoutEvent", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/Theme.AppCompat")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var csharpButton = FindViewById<Button>(Resource.Id.csharp_style);

            csharpButton.Click += CsharpButton_Click;

            var nativeButton = FindViewById<Button>(Resource.Id.native_style);

            nativeButton.Click += NativeButton_Click;

        }

        void CsharpButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(CSharpStyleActivity));
            this.StartActivity(intent);
        }

        void NativeButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(NativeStyleActivity));
            this.StartActivity(intent);
        }
    }
}

