using log4net;
using log4net.Core;
using Remnant.Pipeline.Data;

namespace Remnant.Log4Net
{
	public class Log4NetPipelineData : PipelineData, ILog4NetPipelineData
	{
		public ILog Log { get; set; }
	}
}
