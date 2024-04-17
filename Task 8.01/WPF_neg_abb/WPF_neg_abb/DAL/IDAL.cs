using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_neg_abb.DAL
{
    internal interface IDAL<T>
    {
        bool insert(T t);
        List<T> findAll();
        T findById(int id);
        bool deleteById(int id);
        bool update(T t);
    }
}
