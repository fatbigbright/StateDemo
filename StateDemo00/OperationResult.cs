using System;

namespace StateDemo00
{
	public enum OperationResult
	{
		NORMALLY = 0,
	 	INVALID = 1,// when the control is not enabled to operate or not editable for editing, INVALID will be returned.
		GRID_BOTTOM = 2,
		GRID_TOP = 3,
		ADD_FAILED = 4,
		UPDATE_FAILED = 5,
		DELETE_FAILED = 6
	}
}

