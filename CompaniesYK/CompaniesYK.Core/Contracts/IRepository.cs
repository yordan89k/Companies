using CompaniesYK.Core.Models;
using System;
using System.Linq;

namespace CompaniesYK.Core.Contracts
{
    public interface IRepository<T> where T : Base
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(Guid Id);
        T Find(Guid Id);
        void Insert(T t);
        void Update(T t);
    }
}