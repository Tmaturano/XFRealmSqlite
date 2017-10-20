using SQLite.Net.Attributes;
using System;

namespace XFRealmSqlite.SQLiteModel
{
    public class People
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTimeOffset BirthDate { get; set; }

        public string NameBirthDate { get => $"{Name} - {BirthDate.ToString("dd/MM/yyyy")}"; }
    }
}
