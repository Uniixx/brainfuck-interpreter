using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter.Exceptions
{
	public class PointerOverflowException : Exception
	{
		public PointerOverflowException() { }

		public PointerOverflowException(string message) : base(message) { }

		public PointerOverflowException(string message, Exception exception) : base(message, exception) { }
	}
}
