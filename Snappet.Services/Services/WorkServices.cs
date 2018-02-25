using System;
using System.Data;
using FileHelpers;
using Snappet.Core.Utils;
using Snappet.Repository.Dao;
using Snappet.Repository.Interfaces;

namespace Snappet.Services.Services
{
    public class WorkService
    {
        private readonly IAppLogRepository _appLogRepository = AppLogRepository.GetInstance();

        public DataTable LoadAndDataFile(string filePath = ApplicationConstants.WorkFilePath, char delimiter = ApplicationConstants.FileDelimiter)
        {
            var workItemsDataTables = new DataTable(); 
            try
            { 
                workItemsDataTables = CsvEngine.CsvToDataTable(filePath, delimiter); 
            }
            catch (Exception exception)
            {
                _appLogRepository.Log(exception);
            }
            return workItemsDataTables;
        }
    }
}
