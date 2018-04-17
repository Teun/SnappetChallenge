
namespace Nicollas.Core.Factories
{
    using Nicollas.Core.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IChartFactory : IFactory<Evaluation, int>
    {
        Task<IQueryable<Ngx.Charts.Single>> GetAplyMonth();
        Task<IQueryable<Ngx.Charts.Multiple>> GetAplyWeek();
        Task<IQueryable<Ngx.Charts.Multiple>> GetDificultyWeek();
        Task<IQueryable<Ngx.Charts.Multiple>> GetProgressWeek();
        Task<IQueryable<Ngx.Charts.Multiple>> GetDificultyByStudantWeek(int studantId);
        Task<IQueryable<Ngx.Charts.Multiple>> GetProgressByStudantWeek(int studantId);
    }
}
