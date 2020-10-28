using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcGo.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        //ICollection<T> FindAll();

        //T FindById(int id);

        //bool isExists(int id);

        //bool Create(T entity);
        //bool Update(T entity);
        //bool Delete(T entity);

        //bool Save();э

        Task<ICollection<T>> FindAll();

        Task<T> FindById(int id);

        Task<bool> isExists(int id);

        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);

        Task<bool> Save();
    }
}
