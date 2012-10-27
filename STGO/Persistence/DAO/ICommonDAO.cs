using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.DAO
{
    public interface ICommonDAO<T>
    {
        List<T> getAll();
        
        List<T> getFindById(long id);
        
        T saveOrUpdate(T entity);

        void delete(T entity);

    }
}
