using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{
	public enum MemoryEventType
	{
		INCREASE_POINTER,
		DECREASE_POINTER,
		INCREASE_VALUE,
		DECREASE_VALUE,
		SET_VALUE,
		GET_VALUE,
		RESET,
		OUT
	}
	public class MemoryEvent
	{
		public MemoryEventType Type { get; set; }
		public Memory Memory { get; set; }
		public byte Data { get; set; }
	}
}
