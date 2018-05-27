using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnappetChallenge.Core;
using SnappetChallenge.Models;

namespace SnappetChallenge.Providers
{
    public class WorkDataProvider : IWorkDataProvider
    {
        private IJsonFileDeserilizer _deserilizer;
        private string _filePath;

        public WorkDataProvider(string filePath, IJsonFileDeserilizer deserilizer)
        {
            _filePath = filePath;
            _deserilizer = deserilizer;
        }

        private IEnumerable<WorkData> _workData;

        public async Task<IEnumerable<WorkData>> GetDefaultWorkData()
        {
            if (_workData == null)
                _workData = await _deserilizer.Deserilize<IEnumerable<WorkData>>(_filePath);

            return _workData;
        }
    }
}
