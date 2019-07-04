using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Queries
{
    public class Helper<T>
    {

        public static bool IsValidId(IQueryable<T> dbSet, T entity)
        {
            return dbSet.Contains(entity);
        }
    }
}
