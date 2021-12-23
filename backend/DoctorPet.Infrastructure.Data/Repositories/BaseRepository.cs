using DoctorPet.Domain.Interfaces.Repositories;
using DoctorPet.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DoctorPet.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DoctorPetContext _context;

        public BaseRepository(DoctorPetContext context)
        {
            _context = context;
        }

        public T Atualizar(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<T> Obter()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T ObterPorId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remover(int id)
        {
            var entity = ObterPorId(id);

            _context.Set<T>().Remove(entity);

            _context.SaveChanges();
        }

        public T Salvar(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
