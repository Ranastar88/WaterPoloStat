using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterPoloStat.API.Dtos
{
    public class ResultDto
    {
		public ResultDto()
		{
			Errors = new List<string>();
			Warnings = new List<string>();
		}

		public bool OperationSucceded => Exception == null && !Errors.Any();
		public bool HasWarnings => Warnings.Any();

		public List<string> Errors { get; set; }
		public List<string> Warnings { get; set; }

		public Exception Exception { get; set; }

		public object Result { get; set; }

		public void AddError(string msg)
		{
			Errors.Add(msg);
		}

		public void AddError(List<string> messages)
		{
			Errors.AddRange(messages);
		}

		public void AddWarning(string msg)
		{
			Warnings.Add(msg);
		}

		public void AddWarning(List<string> messages)
		{
			Warnings.AddRange(messages);
		}
	}
}
