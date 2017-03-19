using Newtonsoft.Json;

namespace Snappet.Reports
{
    public interface IReport
    {
        object Generate(string parameters);
    }

    public abstract class Report<TParameters> : IReport where TParameters : new()
    {
        public TParameters Parameters { get; private set; }

        public object Generate(string parameters)
        {
            if (parameters == null)
            {
                Parameters = new TParameters();
            }
            else
            {
                Parameters = JsonConvert.DeserializeObject<TParameters>(parameters);
            }
            return Generate(Parameters);
        }

        protected abstract object Generate(TParameters parameters);
    }
}
