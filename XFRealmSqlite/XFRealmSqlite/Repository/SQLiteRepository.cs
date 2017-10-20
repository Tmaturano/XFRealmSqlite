using SQLite.Net;
using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using XFRealmSqlite.Interfaces;
using XFRealmSqlite.SQLiteModel;

namespace XFRealmSqlite.Repository
{
    public class SQLiteRepository : IDisposable
    {
        private readonly SQLiteConnection _connection;

        public SQLiteRepository()
        {
            var config = DependencyService.Get<ISQLite>();
            _connection = new SQLiteConnection(config.Platform, Path.Combine(config.DirectoryDB, "sqliteDatabase.db3"));
            _connection.CreateTable<People>();
        }

        public void Insert(People people)
        {
            _connection.Insert(people);
        }

        public void Update(People people)
        {
            _connection.Update(people);
        }

        public void Delete(People people)
        {
            _connection.Delete(people);
        }

        public void DeleteAll()
        {
            _connection.DeleteAll<People>();
        }

        public People GetById(int id)
        {
            return _connection.Table<People>().FirstOrDefault(p => p.Id == id);
        }

        public TableQuery<People> GetAll()
        {
            return _connection.Table<People>();
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
