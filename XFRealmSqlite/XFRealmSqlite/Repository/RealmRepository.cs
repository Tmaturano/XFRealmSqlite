using Realms;
using System;
using System.Linq;
using XFRealmSqlite.RealmModel;

namespace XFRealmSqlite.Repository
{
    public class RealmRepository : IDisposable
    {
        private readonly Realm _realm;

        public RealmRepository()
        {
            _realm = Realm.GetInstance();
        }

        public void Insert(People people)
        {
            _realm.Write(() =>
            {
                var p = GetAll();
                                
                people.Id = p.Any() ? _realm.All<People>().Last().Id + 1 : 1;
                _realm.Add(people);
            });
        }

        public void Update(People people)
        {
            _realm.Write(() =>
            {
                _realm.Add(people, update: true);
            });
        }

        public void Delete(People people)
        {
            _realm.Write(() =>
            {
                _realm.Remove(people);
            });
        }
        
        public void DeleteAll()
        {
            _realm.Write(() =>
            {
                _realm.RemoveAll();
            });
        }

        public People GetById(int id)
        {
            return _realm.All<People>().FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<People> GetAll()
        {
            return _realm.All<People>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
