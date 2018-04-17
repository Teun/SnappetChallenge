namespace SnappetChallenge.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EFGetStarted.AspNetCore.NewDb.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Layer around database
    /// </summary>
    /// <seealso cref="SnappetChallenge.Core.IReportDatabaseLayer" />
    /// <seealso cref="System.IDisposable" />
    public class ReportDatabaseLayer : IReportDatabaseLayer, IDisposable
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ClassReportContext classReportContext;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportDatabaseLayer"/> class.
        /// </summary>
        public ReportDatabaseLayer() : this(new ClassReportContextFactory().CreateDbContext(null))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportDatabaseLayer"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ReportDatabaseLayer(ClassReportContext context)
        {
            this.classReportContext = context;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ReportDatabaseLayer"/> class.
        /// </summary>
        ~ReportDatabaseLayer()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets the report item asynchronous.
        /// </summary>
        /// <param name="repDate">The rep date.</param>
        /// <returns>
        /// Result with api report items
        /// </returns>
        /// <exception cref="System.ArgumentNullException">repDate</exception>
        public async Task<List<ApiReportItem>> GetReportItemAsync(DateTime? repDate)
        {
            if (!repDate.HasValue)
            {
                throw new ArgumentNullException(nameof(repDate));
            }

            return await this.classReportContext.ReportItems
                .Where(x => x.SubmitDateTime.Date == repDate.Value.Date)
                .GroupBy(x => x.Subject)
                .Select(x => new ApiReportItem
                {
                    Subject = x.First().Subject,
                    CorrectAnswers = x.Sum(z => z.Correct),
                    SumProgress = x.Sum(z => z.Progress)
                }).ToListAsync();
        }

        /// <summary>
        /// Adds the class report item.
        /// </summary>
        /// <param name="itemLst">The item LST.</param>
        /// <returns>
        /// Task result
        /// </returns>
        public async Task AddClassReportItem(List<ReportItem> itemLst)
        {
            await this.classReportContext.ReportItems.AddRangeAsync(itemLst);
            await this.classReportContext.SaveChangesAsync();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.classReportContext.Dispose();
            }

            this.disposed = true;
        }
    }
}
