using Remnant.Pipeline.Core;
using Remnant.Pipeline.Interfaces;

namespace Remnant.Log4Net
{
	public class LogObserver : Observer,
		IObserve<OnDebug, ILog4NetPipelineData>,
		IObserve<OnInfo, ILog4NetPipelineData>,
		IObserve<OnError, ILog4NetPipelineData>,
		IObserve<OnFatal, ILog4NetPipelineData>,
		IObserve<OnWarning, ILog4NetPipelineData>
	{
		public void OnEvent(OnDebug @event, ILog4NetPipelineData data)
		{
			var log = @event.Log ?? data.Log;

			if (log.IsDebugEnabled)
			{
				log.Debug(@event.Message);
			}
		}

		public void OnEvent(OnError @event, ILog4NetPipelineData data)
		{
			var log = @event.Log ?? data.Log;

			if (log.IsErrorEnabled)
			{
				log.Error(@event.Message, @event.Exception);
			}
		}

		public void OnEvent(OnInfo @event, ILog4NetPipelineData data)
		{
			var log = @event.Log ?? data.Log;

			if (log.IsInfoEnabled)
			{
				log.Info(@event.Message);
			}
		}

		public void OnEvent(OnFatal @event, ILog4NetPipelineData data)
		{
			var log = @event.Log ?? data.Log;

			if (log.IsFatalEnabled)
			{
				log.Fatal(@event.Message, @event.Exception);
			}
		}

		public void OnEvent(OnWarning @event, ILog4NetPipelineData data)
		{
			var log = @event.Log ?? data.Log;

			if (log.IsWarnEnabled)
			{
				log.Warn(@event.Message);
			}
		}
	}
}
