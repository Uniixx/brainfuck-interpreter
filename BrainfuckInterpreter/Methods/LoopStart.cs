using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter.Methods
{
	public class LoopStart : Instruction
	{
		private int pointer = 0;
		public void Execute()
		{
			pointer = Memory.Instance.GetPointer();
			Memory.Instance.AddLoopEntrance(pointer);
		}
	}
}
