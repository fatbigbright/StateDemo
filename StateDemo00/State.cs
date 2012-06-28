using System;
using System.Collections;
using System.Collections.Generic;

namespace StateDemo00
{
	using ResultStateMapping = Dictionary<OperationResult, State>;

	public delegate void StateDelegate();

	public class State
	{
		private Dictionary<Operation, ResultStateMapping> _router = new Dictionary<Operation, ResultStateMapping>();

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

		public void SetupStateItem (Operation op, OperationResult result, State state)
		{
			if (_router.ContainsKey (op)) {
				if(_router[op].ContainsKey(result))
					throw new Exception("Mapping already exists.");

				_router[op].Add(result, state);
				return;
			}

			ResultStateMapping mapping = new ResultStateMapping();
			mapping.Add(result, state);
			_router.Add(op, mapping);
		}

		public State Operate(Operation op, OperationResult result)
		{
			if(_router.ContainsKey(op))
				if(_router[op].ContainsKey(result))
					return _router[op][result];

			return this;
		}
	}
}

