using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{
	public class MemoryObserver : IObserver<MemoryEvent>
	{
		private IDisposable _unsubscribe;
		private Action<MemoryEvent> _action;

		public MemoryObserver(IObservable<MemoryEvent> subject, Action<MemoryEvent> p_action)
		{
			if (subject is null)
			{
				throw new ArgumentNullException(nameof(subject));
			}

			this._unsubscribe = subject.Subscribe(this);
			this._action = p_action;
		}
		public void OnCompleted()
		{
			this.Unsubscribe();
		}

		public void OnError(Exception error)
		{
			throw error;
		}

		public void OnNext(MemoryEvent value)
		{
			this._action(value);
		}

		public void Unsubscribe()
		{
			this._unsubscribe.Dispose();
			this._unsubscribe = null;
		}
	}
}
