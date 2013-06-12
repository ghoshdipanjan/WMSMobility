using System;
using SQLite;

namespace SpotlessMyWebExample
{
	public class ServiceOrders
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Title { get; set; }
		public string Location { get; set; }
		public string Status { get; set; }

		public ServiceOrders(string title, string location, string status)
		{
			Title = title;
			Location = location;
			Status = status;
		}

		public ServiceOrders() {}
	}
}

