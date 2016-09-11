using Snappet.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snappet.Model;
using Microsoft.Extensions.DependencyInjection;
using Snappet.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Snappet.Repository.Implementation
{
    public class AnswerRepository : IAnswerRepository, IDisposable
    {
        private readonly AnswerContext answerContext;

        public AnswerRepository(AnswerContext AnswerContext)
        {
            this.answerContext = AnswerContext;
        }

        public void Add(Answer item)
        {
            answerContext.Answers.Add(item);
        }

        public void AddRange(List<Answer> items)
        {
            answerContext.Answers.AddRange(items);
        }

        public Answer Find(int ID)
        {
            return answerContext.Answers.FirstOrDefault(a => a.SubmittedAnswerId == ID);
        }

        public IEnumerable<Answer> GetAll()
        {
            return answerContext.Answers.ToList();
        }

        public void Remove(int ID)
        {
            Answer answer = answerContext.Answers.FirstOrDefault(a => a.SubmittedAnswerId == ID);

            if(answer != null)
            {
                answerContext.Answers.Remove(answer);
            }
            else
            {
                throw new Exception("Invalid ID passed to AnswerRepository.Remove.");
            }
        }

        public Answer Update(Answer item)
        {
            answerContext.Answers.Attach(item).State = EntityState.Modified;
            return item;
        }

        public void Save()
        {
            answerContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    answerContext.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
