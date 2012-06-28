using System;

namespace StateDemo00
{
	public class Control
	{
		public bool Enabled{set;get;}

		protected string _name = string.Empty;

		public Control (string name)
		{
			_name = name;
		}

		public virtual OperationResult Operate(Operation op)
		{
			return OperationResult.NORMALLY;
		}

		public virtual void Display ()
		{
			Console.WriteLine("{0} Enabled : {1}", _name, Enabled);
		}

		public override string ToString ()
		{
			return _name;
		}
	}
}

