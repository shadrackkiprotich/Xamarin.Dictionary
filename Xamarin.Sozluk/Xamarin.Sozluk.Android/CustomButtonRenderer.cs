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
using Xamarin.Forms;
using Xamarin.Sozluk.Droid;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer))]
namespace Xamarin.Sozluk.Droid
{
    public class CustomButtonRenderer : Forms.Platform.Android.ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {

        }
    }
} 