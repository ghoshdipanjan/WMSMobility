using System;
using SQLite;
using System.Runtime.Serialization;

namespace TabbedApplication.POC2.Data
{
	public class Locations
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string Location { get; set; }

		public Locations(string location)
		{
			Location = location;
		}

		public Locations() {}
	}
}

