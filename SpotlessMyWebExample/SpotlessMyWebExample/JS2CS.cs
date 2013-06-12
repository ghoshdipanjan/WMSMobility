using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Interop;
using Android.Net;
using Android.Provider;
using Android.Graphics;
using Java.IO;
using System.Collections;
using Android.Content.PM;	



namespace CallingcsharpFromJS
{
	public class JS2CS : Java.Lang.Object, Java.Lang.IRunnable
	{

		Context context;

		public JS2CS (Context context)
		{
			this.context = context;
		}

		//[Export]
		public void Run ()
		{
			//Toast.MakeText (context, "Hello from C#", ToastLength.Short).Show ();
			//Toast.MakeText (context, "This is a Toast from C#!", ToastLength.Short).Show ();
			//Intent second = new Intent(context.A, typeof(SecondActivity));
			//Android.App.Activity Act = new Activity();
			//context.StartActivity(typeof(SecondActivity));
		}
	}
}

