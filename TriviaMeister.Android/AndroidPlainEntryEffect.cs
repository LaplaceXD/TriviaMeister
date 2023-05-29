using Android.Content.Res;
using TriviaMeister.Droid;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ResolutionGroupName("PlainEntryGroup")]
[assembly: ExportEffect(typeof(AndroidPlainEntryEffect), "PlainEntryEffect")]

namespace TriviaMeister.Droid
{
    public class AndroidPlainEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                if (Control != null)
                {
                    Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Unable to set property on attached control", ex.Message);
            }
        }

        protected override void OnDetached() {}
    }
}