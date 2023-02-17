using BrainfuckInterpreter.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{ 
	public sealed class Memory : IObservable<MemoryEvent>
	{
		private byte[] _data = new byte[30000];
		private int _pointer = 0;
		private List<IObserver<MemoryEvent>> _observers = new List<IObserver<MemoryEvent>>();
		private static Memory _instance = null;
		private Stack<int> LoopEntries { get; set; } = new Stack<int>();
		private static readonly object _lock = new object();

		public Memory() { }

		public static Memory Instance
		{
			get
			{
				if (_instance == null)
				{
					lock(_lock)
					{
						if (_instance == null)
						{
							_instance = new Memory();
						}
					}
				}
				return _instance;
			}
		}

		public void Pop()
		{
			this.LoopEntries.Pop();
		}

		public byte[] GetBytes()
		{
			return this._data;
		}

		public int Peek()
		{
			return this.LoopEntries.Peek();
		}

		public void SetPointer(int pointer)
		{
			this._pointer = pointer;
		}

		public void Reset()
		{
			this._pointer = 0;
			Array.Clear(this._data, 0, this._data.Length);

			this.OnChange(new MemoryEvent()
			{
				Memory = this,
				Type = MemoryEventType.RESET,
				Data = this.GetValue()
			});
		}

		public void IncreasePointer()
		{
			if (this._pointer + 1 > this._data.Length)
			{
				throw new PointerOverflowException(nameof(this._pointer));
			}

			this._pointer++;

			this.OnChange(new MemoryEvent()
			{
				Memory = this,
				Type = MemoryEventType.INCREASE_POINTER,
				Data = this.GetValue()
			});
		}

		public void DecreasePointer()
		{
			if (this._pointer - 1 < this._data.Length)
			{
				throw new PointerOverflowException(nameof(this._pointer));
			}

			this._pointer--;

			this.OnChange(new MemoryEvent()
			{
				Memory = this,
				Type = MemoryEventType.DECREASE_POINTER,
				Data = this.GetValue()
			});
		}

		public void IncreaseValue()
		{
			this._data[this._pointer] = (byte)(this._data[this._pointer] + 1);

			this.OnChange(new MemoryEvent()
			{
				Memory = this,
				Type = MemoryEventType.INCREASE_VALUE,
				Data = this.GetValue()
			});
		}

		public void DecreaseValue()
		{
			this._data[this._pointer] = (byte)(this._data[this._pointer] - 1);

			this.OnChange(new MemoryEvent()
			{
				Memory = this,
				Type = MemoryEventType.DECREASE_VALUE,
				Data = this.GetValue()
			});
		}

		public int GetPointer()
		{
			return this._pointer;
		}

		public void SetValue(byte b)
		{
			_data[_pointer] = b;

			this.OnChange(new MemoryEvent()
			{
				Memory = this,
				Type = MemoryEventType.SET_VALUE,
				Data = this.GetValue()
			});
		}

		public byte GetValue()
		{
			return this._data[this._pointer];
		}

		public void Out()
		{
			this.OnChange(new MemoryEvent()
			{
				Memory = this,
				Type = MemoryEventType.OUT,
				Data = this.GetValue()
			});
		}

		public void AddLoopEntrance(int pointer)
		{
			LoopEntries.Push(pointer);
		}

		public IDisposable Subscribe(IObserver<MemoryEvent> observer)
		{
			if (observer is null)
			{
				throw new ArgumentNullException(nameof(observer));
			}

			this._observers.Add(observer);

			return new UnsubscribeMemory(observer, this._observers);
		}

		public void OnChange(MemoryEvent evt)
		{
			this._observers.ForEach(o => o.OnNext(evt));
		}
	}
}
