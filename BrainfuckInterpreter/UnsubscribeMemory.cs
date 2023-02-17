using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{
	public class UnsubscribeMemory : IDisposable
	{
		private IObserver<MemoryEvent> _observer;
		private List<IObserver<MemoryEvent>> _observers;

		public UnsubscribeMemory(IObserver<MemoryEvent> observer, List<IObserver<MemoryEvent>> observers)
		{
			this._observer = observer;
			this._observers = observers;
		}

		public void Dispose()
		{
			this._observers.Remove(this._observer);
		}
	}
}
