using DartAgenda.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartAgenda.Infra.Repositories
{
    public class BasicRepository<T> : IBasicRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;
        public BasicRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return this._dbContext.Database.BeginTransaction();
        }

        public void Excluir(T model)
        {
            this._dbContext.Set<T>().Remove(model);
        }

        public IEnumerable<T> ListaTodos()
        {
            return this._dbContext.Set<T>().AsEnumerable();
        }

        public T ObterPorId(int id)
        {
            return this._dbContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> Pesquisar(T filtro)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Salvar(T model)
        {
            Type type = typeof(T);
            long id = Convert.ToInt64(type.GetProperty("Id").GetValue(model));

            if (id == 0)
            {
                return await Inserir(model);
            }
            else
            {
                return Alterar(model);
            }
        }

        private async Task<T> Inserir(T model)
        {
            var newEntity = await this._dbContext.Set<T>().AddAsync(model);
            return newEntity.Entity;
        }

        public T Alterar(T model)
        {
            DetachLocal();
            var newEntity = this._dbContext.Set<T>().Update(model);
            return newEntity.Entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        private void DetachLocal()
        {
            var local = this._dbContext.Set<T>().Local.FirstOrDefault();
            if (!(local == null))
            {
                this._dbContext.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
