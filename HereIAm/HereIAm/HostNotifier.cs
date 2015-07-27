using System;

namespace HereIAm
{
	public class HostNotifier
	{
		public event EventHandler<VisitorEventArgs> VisitorArrived;

		public void OnVisitorArrived(VisitorEventArgs e)
		{
			var handler = VisitorArrived;
			if (handler != null)
			{
				handler(this, e);
			}
		}
	}
}

