using SnappetChallenge.Application.Business.Repository;

namespace SnappetChallenge.Application.Business.Results;

public class GetProgressReportResult
{
    public ProgressReportCollection BySubjectReportData { get; set; }
    public ProgressReportCollection ByDomainReportData { get; set; }
}

public class ProgressReportCollection
{
    public ProgressReportCollection()
    {
        DataSet = new List<DataSetItem>();
    }

    public List<DataSetItem> DataSet { get; private set; }

    public void AddRange(DataSetColumn column, List<ProgressReportDTO> data)
    {
        data.ForEach(d => Add(column, d));
    }

    public void Add(DataSetColumn column, ProgressReportDTO data)
    {
        var item = DataSet.FirstOrDefault(d=>d.Data ==  data.Data);
        var exists = item != null;
        if (!exists)
        {
            item = new DataSetItem { Data = data.Data };
            DataSet.Add(item);
        }

        if (column == DataSetColumn.Today)
        {
            item.Today = data.Progress;
        }
        else
        {
            item.LastWeek = data.Progress;
        }
    }
}

public enum DataSetColumn
{
    LastWeek,
    Today
}

public class DataSetItem
{
    public string Data { get; set; }
    public int Today { get; set; }
    public int LastWeek { get; set; }
}