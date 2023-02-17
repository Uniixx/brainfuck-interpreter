using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter.Methods
{
	public class LoopEnd : Instruction
	{
		public void Execute()
		{
			if (Memory.Instance.GetValue() == 0)
			{
				Memory.Instance.Pop();
			}
			else
			{
				Memory.Instance.SetPointer(Memory.Instance.Peek());
			}

		}
	}
}
