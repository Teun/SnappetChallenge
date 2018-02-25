using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snappet.Core.Dtos;
using Snappet.Repository.Helpers;

namespace Snappet.Repository.Interfaces
{

    public interface IAppSettingsRepository
    {
        void Update(AppSettings appSettings);
        Task Save(AppSettings appSettings);
        IEnumerable<string> FindAllGroups();
        void Delete(long appSettingsId);
        AppSettings GetByName(string settingsName);
        AppSettings GetById(long analyticsId);
        QueryResult<AppSettings> FindAll(int pageIndex = 1, int pageSize = 10);
        QueryResult<AppSettings> FindByGroup(long categoryId, int pageIndex, int pageSize);
    }
}
