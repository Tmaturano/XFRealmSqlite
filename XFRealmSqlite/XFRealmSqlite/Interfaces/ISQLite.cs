using SQLite.Net.Interop;

namespace XFRealmSqlite.Interfaces
{
    public interface ISQLite
    {        
        string DirectoryDB { get; }
        ISQLitePlatform Platform { get; }
    }
}
