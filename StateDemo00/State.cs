using System;
using System.Collections;
using System.Collections.Generic;

namespace StateDemo00
{
	public delegate void StateDelegate();

	public class State
	{
		private Dictionary<Operation, State> _router  = new Dictionary<Operation, State>();

		private StateDelegate _enter;

		private string _name = string.Empty;

		public event StateDelegate OnStateEntered;

		public State (string name, StateDelegate enterMethod)
		{
			_name = name;
			_enter = enterMethod;
		}

		public override string ToString ()
		{
			return _name;
		}

		public void Enter()
		{
			_enter();
			if(OnStateEntered != null)
				OnStateEntered();
		}

		public void SetupStateItem(Operation op, State result)
		{
			if(_router.ContainsKey(op))
				throw new Exception("Operation already exists.");

			_router.Add(op, result);
		}

		public State Operate(Operation op)
		{
			if(_router.ContainsKey(op))
				return _router[op];

			return this;
		}
	}
}

