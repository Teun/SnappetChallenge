
namespace Nicollas.Imp.Services
{
    using Nicollas.Core;
    using Nicollas.Core.Entities;
    using Nicollas.Core.Factories;
    using Nicollas.Core.Services;
    using System.Collections.Generic;
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

        public async Task<bool> InsertEvaluationDataAsync(IList<Evaluation> evalData)
        {
            foreach (var item in evalData)
            {
                await this.AddAsync(item);
            }

            return true;
        }
    }
}
