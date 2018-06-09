using log4net.Repository;
using log4net.Core;
using Remnant.Pipeline.Core;
using System;
using log4net;
using System.Reflection;
using System.Xml;
using System.IO;

namespace Remnant.Log4Net
{
	public class Log4NetPipeline : CorePipeline
	{
		private readonly ILoggerRepository _loggerRepostiory;
		private readonly ILog _log;

		public Log4NetPipeline(string repository = null)
		{
			var logRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
			var log4netConfig = new XmlDocument();

			log4netConfig.Load(File.OpenRead("log4net.config"));

			log4net.Config.XmlConfigurator.Configure(logRepository, log4netConfig["log4net"]);

			_log = LogManager.GetLogger(GetType());

			Configuration = new PipelineConfig(c => c
				.UseData(new Log4NetPipelineData { Log = _log })
				.AutoRaiseEvents(false)
				.Stages()
				.RegisterStage("Log")
				.ForEvent<OnDebug>()
				.ForEvent<OnInfo>()
				.ForEvent<OnFatal>()
				.ForEvent<OnError>()
				.ForEvent<OnWarning>()
				.Observers()
				.RegisterObserver<LogObserver>()
			);
		}
	}
}
