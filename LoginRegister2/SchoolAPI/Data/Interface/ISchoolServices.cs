using SchoolAPI.Data.Entity;

namespace SchoolAPI.Data.Interface
{
    public interface ISchoolServices <T> where T:class
    {
        Task <T> Create(T t);
        Task<T> Update(T t);

        Task<T> Delete(T t);    
        Task<List<T>> GetAll();
    }
}
