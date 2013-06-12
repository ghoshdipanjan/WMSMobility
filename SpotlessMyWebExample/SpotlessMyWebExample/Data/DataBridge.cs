using System;
using System.Drawing;
using System.IO;
using SQLite;
using System.Collections.Generic;
using System.Json;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SpotlessMyWebExample
{
	public class DataBridge
	{
		public string PathToDb{ get; set; }

		#region Private Properties

		private SQLiteConnection db;

		#endregion

		public DataBridge(string pathToDb)
		{
			PathToDb = pathToDb;
			db = new SQLiteConnection (pathToDb);
		}

		~DataBridge()
		{
			db.Close ();
			db.Dispose();
		}

		#region Initialise Database Methods
		public void InitialiseDatabase ()
		{
			DropTables ();

			CreateTables ();

			PopulateLocations ();
			//PopulateStatuses ();
		}

		void DropTables ()
		{
			db.DropTable<Locations> ();
			db.DropTable<ServiceOrders> ();
			//db.DropTable<Statuses> ();
		}

		void CreateTables ()
		{
			db.CreateTable<Locations>();
			db.CreateTable<ServiceOrders> ();
			//.CreateTable<Statuses> ();
		}

		void PopulateLocations ()
		{
			db.Insert (new Locations("Melbourne"));
			db.Insert (new Locations("Sydney"));
			db.Insert (new Locations("Brisbane"));
			db.Insert (new Locations("Canberra"));
		}

//		void PopulateStatuses ()
//		{
//			db.Insert (new Statuses("Initial"));
//			db.Insert (new Statuses("Cancelled"));
//			db.Insert (new Statuses("Complete"));
//		}
		#endregion

		#region Utility Functions
		// Conversion
		string ConvertToJSON (object locations)
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject (locations);
		}
		#endregion


		//#region Query Methods

		#region Locations
		//TODO: Replace with Repository Pattern
		public IEnumerable<Locations> GetLocations()
		{
			return db.Query<Locations>("SELECT Location from Locations");
		}

		public string GetLocationsAsJSON()
		{
			return ConvertToJSON (GetLocations ());
		}
		#endregion

	}
}