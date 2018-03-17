namespace Nicollas.Imp.Factory
{
    using Microsoft.EntityFrameworkCore;
    using Ngx.Charts;
    using Nicollas.Core;
    using Nicollas.Core.Entities;
    using Nicollas.Core.Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ChartFactory : Factory<Evaluation, int>, IChartFactory
    {
        public ChartFactory(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<IQueryable<Multiple>> GetAplyWeek()
        {
            var query = await this.Repository.GetAllQueryableAsync();
            query.Include(r => r.Domain);
            return query.GroupBy(eval => eval.ApliedAt.Day % 4 ).Select(grp => new Ngx.Charts.Multiple
            {
                Name = $"Week {grp.Key + 1}",
                Series = grp.GroupBy(eval => eval.Domain).Select(serie => new Ngx.Charts.Single
                {
                    Name = serie.Key.Description,
                    Value = serie.Count()
                }).OrderBy(row => row.Name)
            });
        }

        public async Task<IQueryable<Ngx.Charts.Single>> GetAplyMonth()
        {
            var query = await this.Repository.GetAllQueryableAsync();
            query.Include(r => r.Domain);
            return query.GroupBy(eval => eval.Domain).Select(grp => new Ngx.Charts.Single
            {
                Name = grp.Key.Description,
                Value = grp.Count()
            }).OrderBy(row => row.Name);
        }

        public async Task<IQueryable<Multiple>> GetDificultyWeek()
        {
            var query = await this.Repository.GetAllQueryableAsync();
            query.Include(r => r.Domain);



            return query.GroupBy(eval => eval.Domain).Select(grp => new Ngx.Charts.Multiple
            {
                Name = grp.Key.Description,
                Series = grp.GroupBy(eval => eval.ApliedAt.Day % 4).Select(serie => new Ngx.Charts.Single
                {
                    Name = $"Week {serie.Key + 1}",
                    Value = serie.Sum(row => row.Difficulty) / serie.Count()
                }).OrderBy(row => row.Name)
            });
        }

        public async Task<IQueryable<Multiple>> GetProgressWeek()
        {
            var query = await this.Repository.GetAllQueryableAsync();
            query.Include(r => r.Domain);

            return query.GroupBy(eval => eval.Domain).Select(grp => new Ngx.Charts.Multiple
            {
                Name = grp.Key.Description,
                Series = grp.GroupBy(eval => eval.ApliedAt.Day % 4).Select(serie => new Ngx.Charts.Single
                {
                    Name = $"Week {serie.Key + 1}",
                    Value = serie.Sum(row => row.Progress) / serie.Count()
                }).OrderBy(row => row.Name)
            });
        }
    }
}
