using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{
	public interface Instruction
	{ 
		public void Execute();
	}
}
