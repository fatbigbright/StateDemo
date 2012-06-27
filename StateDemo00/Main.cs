using System;

namespace StateDemo00
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Console.WriteLine ("Hello World!");

			Browser browser = new Browser();
			browser.Operate(Operation.SCROLL_DOWN);
			browser.Operate(Operation.SCROLL_UP);
			Console.ReadKey();
		}
	}
}
