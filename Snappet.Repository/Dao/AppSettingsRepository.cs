using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Snappet.Core.Dtos;
using Snappet.Repository.Helpers;
using Snappet.Repository.Interfaces;

namespace Snappet.Repository.Dao
{

    public class AppSettingsRepository : IAppSettingsRepository
    {

        static AppSettingsRepository _appSettingsRepository { get; set; }


        public static AppSettingsRepository GetInstance()
        {
            return _appSettingsRepository ?? (_appSettingsRepository = new AppSettingsRepository());
        }

        public void Delete(long appSettingsId)
        {
            throw new NotImplementedException();
        }

        public AppSettings GetByName(string settingsName)
        {
            using (var conn = SqldaoFactory.GetConnection())
            {
                var appSettings = conn.Query<AppSettings>("appsettings_findbyname",
                    new { settingsName }, commandType: CommandType.StoredProcedure);

                return appSettings.SingleOrDefault();
            }
        }

        public IEnumerable<string> FindAllGroups()
        {
            using (var conn = SqldaoFactory.GetConnection())
            {
                var result = conn.QueryMultiple("appsettings_findallgroups",
                    commandType: CommandType.StoredProcedure);

                var groupNames = result.Read<string>();

                return groupNames;
            }
        }
        public QueryResult<AppSettings> FindAll(int pageIndex = 1, int pageSize = 10)
        {
            using (var conn = SqldaoFactory.GetConnection())
            {
                var pagingInfo = QueryHelper.GetPagingRowNumber(pageIndex, pageSize);
                var result = conn.QueryMultiple("appsettings_findall",
                    new
                    {
                        rowStart = pagingInfo.RowStart,
                        rowEnd = pagingInfo.RowEnd
                    },
                    commandType: CommandType.StoredProcedure);

                var appSettings = result.Read<AppSettings>();


                return new QueryResult<AppSettings>(appSettings, result.Read<int>().First());
            }
        }

        public QueryResult<AppSettings> FindByGroup(long categoryId, int pageIndex, int pageSize)
        {
            return new QueryResult<AppSettings>(new List<AppSettings>(), 21);
        }

        public AppSettings GetById(long Id)
        {
            return new AppSettings();
        }

        public async Task Save(AppSettings appSettings)
        {
            using (var conn = SqldaoFactory.GetConnection())
            {

                await conn.QueryAsync("appsetting_insertupdate", new
                {
                    appSettings.Id,
                    appSettings.Name,
                    appSettings.Value,
                    appSettings.GroupName,
                    appSettings.Description

                }, commandType: CommandType.StoredProcedure);
            }

        }

        public void Update(AppSettings appsettingSettings)
        {
        }
    }
}
