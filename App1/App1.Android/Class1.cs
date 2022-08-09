using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using App1;
using Xamarin.Forms.Platform.Android;
using App1.Droid;

[assembly: ExportRenderer(typeof(RoundedPicker), typeof(Class1))]
namespace App1.Droid
{
    public class Class1 : PickerRenderer
    {
        public Class1(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}