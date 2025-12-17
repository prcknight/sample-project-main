using BusinessEntities;
using Common;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    //[AutoRegister]
    public class MemoryRepository<T> : IRepository<T> where T : IdObject
    {
        protected static readonly Dictionary<string, T> _documentSession = new Dictionary<string, T>();

        public MemoryRepository()
        {
        }

        public void Save(T entity)
        {
            _documentSession.Add(entity.Id.ToString(), entity);
        }

        public void Delete(T entity)
        {
            if (_documentSession.ContainsKey(entity.Id.ToString()))
            {
                _documentSession.Remove(entity.Id.ToString());
            }
        }

        public T Get(Guid id)
        {
            T result = null;
            
            if (_documentSession.ContainsKey(id.ToString()))
            {
                result = _documentSession[id.ToString()];
            }

            return result;
        }

        protected void DeleteAll<TIndex>() where TIndex : AbstractIndexCreationTask<T>
        {
            _documentSession.Clear();
        }
    }
}
