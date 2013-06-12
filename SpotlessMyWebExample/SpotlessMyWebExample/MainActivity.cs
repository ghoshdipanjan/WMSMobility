using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Webkit;  // Webkit required for WebView


namespace SpotlessMyWebExample
{
	[Activity (Label = "SpotlessMyWebExample", MainLauncher = true)]
	public class Activity1 : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//WebView view = new WebView (this);
			//SetContentView (view);
			SetContentView (Resource.Layout.Main);
			WebView view = FindViewById<WebView>(Resource.Id.web);
			view.Settings.LoadWithOverviewMode = true;
			view.Settings.UseWideViewPort = true;
			view.Settings.JavaScriptEnabled = true;
			view.SetWebChromeClient (new MyWebChromeClient ());
			//view.
			view.AddJavascriptInterface (new Foo (this), "Foo");
			view.LoadUrl ("file:///android_asset/Content/Home.html");
			//view.LoadData (html, "text/html", null);
		}
	}

	class MyWebChromeClient : WebChromeClient {
	}
}


