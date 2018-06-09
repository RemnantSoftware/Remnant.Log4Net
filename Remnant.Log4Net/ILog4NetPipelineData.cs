using log4net;
using log4net.Core;
using Remnant.Pipeline.Interfaces;

namespace Remnant.Log4Net
{
	public interface ILog4NetPipelineData : IPipelineData
	{
		ILog Log { get; set; }
	}
}
