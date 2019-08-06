using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVC.Infrastructure.Services
{
	public interface IFilterDiagnostics
	{
		IEnumerable<string> Messages { get; }
		void AddMessage(string msg);
	}
}
