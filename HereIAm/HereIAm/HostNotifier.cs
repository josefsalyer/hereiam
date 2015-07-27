using System;

namespace HereIAm
{
	public class HostNotifier
	{
		public event EventHandler<VisitorEventArgs> VisitorArrived;

		private VisitorManager _visitorManager;

		public HostNotifier(VisitorManager visitorManager)
		{
			if (visitorManager == null)
				throw new ArgumentNullException ("visitorManager");

			_visitorManager = visitorManager;
			_visitorManager.VisitorAdded += VisitorAdded;
		}
			
		public void OnVisitorArrived(VisitorEventArgs e)
		{
			var handler = VisitorArrived;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		private void VisitorAdded(object sender, VisitorEventArgs e)
		{
			OnVisitorArrived (e);
		}
	}
}

