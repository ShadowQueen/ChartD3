using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebSocketChart.Models;

namespace WebSocketChart
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);

			Task.Run(() =>
			{
				var rand = new Random(Environment.TickCount);
				var gen = new Random();
				DateTime RandomDay()
				{
					DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
					int range = (DateTime.Today - start).Days;
					return start.AddDays(gen.Next(range));
				};

				DateTime RandomDay2()
				{

					var rnd = new Random(Guid.NewGuid().GetHashCode());

					var year = rnd.Next(1, 10000);
					var month = rnd.Next(1, 13);
					var days = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);

					return new DateTime(year, month, days,
						rnd.Next(0, 24), rnd.Next(0, 60), rnd.Next(0, 60), rnd.Next(0, 1000));
				};

				while (true)
				{

					//List<Scale> scaleList = new List<Scale>();

					//scaleList.AddRange(new List<Scale>
					//				{
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)),
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)),
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)),
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)),
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)),
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)),
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)),
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)),
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)),
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)),
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)),
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)),
					//					new Scale(RandomDay(), (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0))
					//				 });


					string output = JsonConvert.SerializeObject(new Scale(DateTime.Now, (rand.NextDouble() * 100.0), (rand.NextDouble() * 100.0)));

					SocketServer.SendMessage(output);
					Thread.Sleep(500);
				}
			});
		}
	}
}
