using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Webkit;
using Java.Interop;
using System.IO;

namespace SpotlessMyWebExample
{
	public class Foo : Java.Lang.Object
		{
		private DataBridge dataBridge;
		private static string db_file = "test.db3";
			public Foo (Context context)
			{
				this.context = context;

			string pathToDb = Path.Combine (System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal), db_file);
			bool exists = File.Exists (pathToDb);

			dataBridge = new DataBridge (pathToDb);
			dataBridge.InitialiseDatabase();
			}

			public Foo (IntPtr handle, JniHandleOwnership transfer)
				: base (handle, transfer)
			{
			}

			Context context;

			[Export ("bar")]
			// to become consistent with Java/JS interop convention, the argument cannot be System.String.
			public string Bar (Java.Lang.String message)
			{
			Console.WriteLine ("Foo.Bar invoked!" + dataBridge.GetLocationsAsJSON());
				//Toast.MakeText (context, "This is a Toast from C#! " + message, ToastLength.Short).Show ();
			return dataBridge.GetLocationsAsJSON();
			}
		}

}

