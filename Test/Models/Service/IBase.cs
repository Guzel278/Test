using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models.Service
{
    public interface IBase<T> where T : class
    {
        List<T> Get();

        T GetById(int id);

        void Create(T dataObject);

        void Update(T dataObject);

        void Delete(T dataObject);

        void Reload(T dataObject);

    }
}
