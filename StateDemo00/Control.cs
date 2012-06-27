using System;

namespace StateDemo00
{
	public class Control
	{
		public bool Enabled{set;get;}

		private string _name = string.Empty;

		public Control (string name)
		{
			_name = name;
		}

		public override string ToString ()
		{
			return _name;
		}
	}
}

