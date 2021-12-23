using System;
using System.Collections.Generic;

namespace DoctorPet.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        List<T> Obter();
        T ObterPorId(int id);
        T Salvar(T entity);
        T Atualizar(T entity);
        void Remover(int id);
    }
}
