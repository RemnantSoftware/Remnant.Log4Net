using log4net;
using log4net.Core;
using Remnant.Pipeline.Interfaces;
using System;

namespace Remnant.Log4Net
{
	public class OnDebug : IEvent
	{
		public string Message { get; set; }
		public ILog Log { get; set; }
	}

	public class OnInfo : IEvent
	{
		public string Message { get; set; }
		public ILog Log { get; set; }
	}

	public class OnWarning : IEvent
	{
		public string Message { get; set; }
		public ILog Log { get; set; }
	}

	public class OnError : IEvent
	{
		public Exception Exception { get; set; }
		public string Message { get; set; }
		public ILog Log { get; set; }
	}

	public class OnFatal : IEvent
	{
		public Exception Exception { get; set; }
		public string Message { get; set; }
		public ILog Log { get; set; }
	}
}
