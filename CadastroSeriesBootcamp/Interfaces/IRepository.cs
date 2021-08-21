using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroSeriesBootcamp.Interfaces
{
    interface IRepository<T>
    {
        List<T> List();
        T RetornaById(int id);
        void Insert(T entidade);
        void Delete(int id);
        void Update(int id, T entidade);
        int NextId();
    }
}
