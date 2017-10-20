using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using System;
using Xamarin.Forms;
using XFRealmSqlite.Droid.Database;
using XFRealmSqlite.Interfaces;

[assembly: Dependency(typeof(SQLiteDroid))]
namespace XFRealmSqlite.Droid.Database
{
    public class SQLiteDroid : ISQLite
    {
        private string _directoryDB;

        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_directoryDB))
                {
                    _directoryDB = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                }

                return _directoryDB;
            }            
        }


        private ISQLitePlatform _platform;
        public ISQLitePlatform Platform
        {
            get
            {
                if (_platform == null)
                {                    
                    _platform = new SQLitePlatformAndroid();
                }

                return _platform;
            }
        }
    }
}