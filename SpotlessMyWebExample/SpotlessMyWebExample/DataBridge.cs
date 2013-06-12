using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;
using SQLite;
using TabbedApplication.POC2.Data;
using System.Collections.Generic;
using System.Json;


namespace TabbedApplication.POC2.Data
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
			PopulateStatuses ();
		}

		void DropTables ()
		{
			db.DropTable<Locations> ();
			db.DropTable<ServiceOrders> ();
			db.DropTable<Statuses> ();
		}

		void CreateTables ()
		{
			db.CreateTable<Locations>();
			db.CreateTable<ServiceOrders> ();
			db.CreateTable<Statuses> ();
		}

		void PopulateLocations ()
		{
			db.Insert (new Locations("Melbourne"));
			db.Insert (new Locations("Sydney"));
			db.Insert (new Locations("Brisbane"));
			db.Insert (new Locations("Canberra"));
		}

		void PopulateStatuses ()
		{
			db.Insert (new Statuses("Initial"));
			db.Insert (new Statuses("Cancelled"));
			db.Insert (new Statuses("Complete"));
		}
		#endregion

		#region Utility Functions
		// Conversion
		string ConvertToJSON (object locations)
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject (locations);
		}
		#endregion


		#region Query Methods

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

		#region Statuses
		//TODO: Replace with Repository Pattern
		public IEnumerable<Statuses> GetStatuses()
		{
			return db.Query<Statuses>("SELECT Status from Statuses");
		}

		public string GetStatusesAsJSON()
		{
			return ConvertToJSON (GetStatuses ());
		}
		#endregion

		#endregion
	}
}

