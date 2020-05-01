using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Devskill.Framework
{
    public interface ISubjectRepository
    {
        void Add(Subject entity);
        void Remove(Int32 id);
        void Remove(Subject entityToDelete);
        void Remove(Expression<Func<Subject, bool>> filter);
        void Edit(Subject entityToUpdate);
        int GetCount(Expression<Func<Subject, bool>> filter = null);
        IList<Subject> Get(Expression<Func<Subject, bool>> filter);
        IList<Subject> GetAll();
        Subject GetById(Int32 id);

        (IList<Subject> data, int total, int totalDisplay) Get(
            Expression<Func<Subject, bool>> filter = null,
            Func<IQueryable<Subject>, IOrderedQueryable<Subject>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        (IList<Subject> data, int total, int totalDisplay) GetDynamic(
            Expression<Func<Subject, bool>> filter = null,
            string orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        IList<Subject> Get(Expression<Func<Subject, bool>> filter = null,
            Func<IQueryable<Subject>, IOrderedQueryable<Subject>> orderBy = null,
            string includeProperties = "", bool isTrackingOff = false);

        IList<Subject> GetDynamic(Expression<Func<Subject, bool>> filter = null,
            string orderBy = null,
            string includeProperties = "", bool isTrackingOff = false);
    }
}