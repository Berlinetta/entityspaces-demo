using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public abstract class RepositoryBase<T>
        where T : class
    {
        public abstract void Add(T item);


    }
}
