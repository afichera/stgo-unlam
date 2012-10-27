using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Service
{
    public interface ICommonService<T>
    {
        List<T> getAll();

        T getFindById(long id);

        T saveOrUpdate(T entity);

        void delete(T entity);
    }
}
