using System.Collections.Generic;

namespace TestMVC.Infrastructure.Services
{
	public class FilterDiagnostics : IFilterDiagnostics
	{
		private readonly List<string> list = new List<string>();
		public IEnumerable<string> Messages => list;

		public void AddMessage(string msg)
		{
			list.Add(msg);
		}
	}
}
