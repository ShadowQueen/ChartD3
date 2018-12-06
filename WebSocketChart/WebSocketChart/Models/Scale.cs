using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSocketChart.Models
{
	public class Scale
	{
		static int counter = 0;
		public Scale(DateTime date, double weight, double tLabele)
		{
			this.Date = date;
			this.Weight = weight;
			this.TLabele = tLabele;
			Id = counter++;
		}

		public int Id { get; set; }
		public DateTime Date { get; set; }
		public double Weight { get; set; }
		public double TLabele { get; set; }

	}
}