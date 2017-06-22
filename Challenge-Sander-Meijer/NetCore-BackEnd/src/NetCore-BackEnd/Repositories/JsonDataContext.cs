using System;
using System.Collections.Generic;
using System.IO;
using NetCore.BackEnd.Models.Poco;
using Newtonsoft.Json;

namespace NetCore.BackEnd.Repositories
{
	public class JsonDataContext : IDataContext
	{
		private const string DataFile = @"Data\work.json";

		private IList<WorkResult> _workResults;

		public IList<WorkResult> WorkResults => _workResults ?? (_workResults = Initialize());

		public IList<WorkResult> Initialize()
		{
			if (!File.Exists(DataFile))
			{
				throw new InvalidOperationException($"File '{DataFile}' does not exist");
			}

			var jsonText = File.ReadAllText(@"Data\work.json");

			if (string.IsNullOrWhiteSpace(jsonText))
			{
				throw new InvalidOperationException($"No data was found at '{DataFile}'");
			}

			return JsonConvert.DeserializeObject<List<WorkResult>>(jsonText);
		}
	}
}