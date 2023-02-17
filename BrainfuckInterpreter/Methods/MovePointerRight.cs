using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter.Methods
{
	public class MovePointerRight : Instruction
	{
		public void Execute()
		{
			Memory.Instance.IncreasePointer();
		}
	}
}
