
namespace Nicollas.Imp.Services
{
    using Nicollas.Core;
    using Nicollas.Core.Entities;
    using Nicollas.Core.Factories;
    using Nicollas.Core.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EvaluationService : Service<Evaluation, int>, IEvaluationService
    {
        private ISubjectFactory subjectFactory;
        private IDomainFactory domainFactory;

        public EvaluationService(IUnitOfWork unitOfWork,
            ISubjectFactory subjectFactory,
            IDomainFactory domainFactory)
            : base(unitOfWork)
        {
            this.subjectFactory = subjectFactory;
            this.domainFactory = domainFactory;
        }

        public async Task InsertEvaluationDataAsync(IList<Evaluation> evalData)
        {
            var alreadyPersisted = (await this.GetAllQueryableByCriteriaAsync(row => evalData.Any(evl => evl.Id == row.Id))).Select(r => r.Id);
            var toPersist = evalData.Where(row => !alreadyPersisted.Any(id => row.Id == id));

            foreach (var item in toPersist)
            {
                if(await this.GetByCriteriaAsync(row => row.Id == item.Id) != null)
                {
                    continue;
                }

                item.SubjectId = await this.subjectFactory.GetSubjectId(item.Subject);
                item.Subject = null;

                item.DomainId = await this.domainFactory.GetDomainId(item.Domain);
                item.Domain = null;

                this.Repository.Add(item);
            }
            await this.UnitOfWork.CommitAsync();
        }
    }
}
