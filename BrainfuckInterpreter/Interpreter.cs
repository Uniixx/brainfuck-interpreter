using BrainfuckInterpreter.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{
	public class Interpreter
	{
		private Memory _memory = Memory.Instance;
		private LinkedList<Instruction> _instructions = new LinkedList<Instruction>();

		public Interpreter()
		{
		}

		public void Execute(LinkedListNode<Instruction> ins)
		{
			if (ins.Value is null)
			{
				return;
			}

			if (ins.Next is null)
			{
				ins.Value.Execute(ins);
				return;
			}

			ins.Value.Execute(ins);
			this.Execute(ins.Next);
		}

		public void Compile(string bf)
		{
			for(int i = 0; i < bf.Length; i++)
			{
				switch(bf[i])
				{
					case '>':
						this._instructions.AddLast(
							new LinkedListNode<Instruction>(
								new MovePointerRight()
								)
							);
					break;
					case '<':
						this._instructions.AddLast(
							new LinkedListNode<Instruction>(
								new MovePointerLeft()
								)
							);
					break;
					case '+':
						this._instructions.AddLast(
							new LinkedListNode<Instruction>(
								new IncreasePointerValue()
								)
							);
					break;
					case '-':
						this._instructions.AddLast(
							new LinkedListNode<Instruction>(
								new DecreasePointerValue()
								)
							);
					break;
					case '[':
						this._instructions.AddLast(
							new LinkedListNode<Instruction>(
								new LoopStart()
								)
							);
					break;
					case ']':
						this._instructions.AddLast(
							new LinkedListNode<Instruction>(
								new LoopEnd()
								)
							);
					break;
					case '.':
						this._instructions.AddLast(
							new LinkedListNode<Instruction>(
								new Out()
								)
							);
					break;
				}
			}

			this.Execute(_instructions.First);
		}
	}
}
