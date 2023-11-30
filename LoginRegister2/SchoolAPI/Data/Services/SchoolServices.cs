using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Context;
using SchoolAPI.Data.Interface;

namespace SchoolAPI.Data.Services
{
    public class SchoolServices<T> : ISchoolServices<T> where T : class
    {
        private SchoolDbContext _context;

        public SchoolServices(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T t)
        {
            if(t == null)
            {
                throw new Exception("NULL");
            }
            await _context.Set<T>().AddAsync(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task<T> Delete(T t)
        {
            if( t == null ) {
                throw new Exception("NULL");    
            }
             _context.Set<T>().Remove(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task<List<T>> GetAll()
        {
            
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T t)
        {
             _context.Set<T>().Update(t);
            await _context.SaveChangesAsync();
            return t;
        }

    }
}
