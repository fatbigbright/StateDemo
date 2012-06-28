using System;
using System.Collections;
using System.Collections.Generic;

namespace StateDemo00
{
	public delegate OperationResult OperationHandler();

	public class GridControl : Control
	{
		private IList<RecordModel> _data = null;

		private int _currentIndex = -1;

		private Dictionary<Operation, OperationHandler> operationMapping = new Dictionary<Operation, OperationHandler>();

		public GridControl(string name) : base(name)
		{
			BindOperation();
		}

		public void Bind(IList<RecordModel> dataSource)
		{
			_data = dataSource;
	    }

		public override OperationResult Operate (Operation op)
		{
			if(operationMapping.ContainsKey(op))
				return operationMapping[op]();
			return OperationResult.NORMALLY;
		}

		public override void Display ()
		{
			base.Display ();
			if (_data == null || _data.Count <= 0) {
				Console.WriteLine ("{0} data source is empty. ", _name);
				return;
			}
			if (Enabled) {
				Console.WriteLine ("Current Record: ID = '{0}', Name = '{1}'", _data [_currentIndex].ID, _data [_currentIndex].Name);
				return;
			}
		}

		private void BindOperation ()
		{
			operationMapping.Add(Operation.SCROLL_UP, () => {
				if(_currentIndex <= 0)
					return OperationResult.GRID_TOP;
				else
					_currentIndex--;
				return OperationResult.NORMALLY;
			});

			operationMapping.Add(Operation.SCROLL_DOWN, () => {
				if(_currentIndex >= _data.Count - 1)
					return OperationResult.GRID_BOTTOM;
				else
					_currentIndex++;

				return OperationResult.NORMALLY;
			});
		}
	}
}

