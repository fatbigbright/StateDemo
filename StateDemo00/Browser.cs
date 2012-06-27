using System;

namespace StateDemo00
{
	public class Browser
	{
		private Control _header = new Control("Header Control");

		private Control _grid = new Control("Grid for Details");

		private State _currentState = null;

		public Browser ()
		{
			InitialComponent();
		}

		private void Display()
		{
			Console.WriteLine("----------------------------------------------");
			Console.WriteLine("Current State: {0}", _currentState.ToString());
			Console.WriteLine("_header.Enabled = {0}", _header.Enabled);
			Console.WriteLine("_grid.Enabled = {0}", _grid.Enabled);
			Console.WriteLine("----------------------------------------------");
		}

		public void Operate (Operation op)
		{
			_currentState = _currentState.Operate(op);
			_currentState.Enter();
		}

		private void InitialComponent ()
		{
			State initialState = new State("Initial State", () => {
				_header.Enabled = true;
				_grid.Enabled = false;
			});

			State gridState = new State("Grid State", () => {
				_header.Enabled = false;
				_grid.Enabled = true;
			});

			initialState.OnStateEntered += Display;
			gridState.OnStateEntered += Display;

			initialState.SetupStateItem(Operation.SCROLL_DOWN, gridState);
			gridState.SetupStateItem(Operation.SCROLL_UP, initialState);

			_currentState = initialState;
			_currentState.Enter();
		}

	}
}

