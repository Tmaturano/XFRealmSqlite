using Realms;
using System;

namespace XFRealmSqlite.RealmModel
{
    public class People : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTimeOffset BirthDate { get; set; }

        public string NameBirthDate { get => $"{Name} - {BirthDate.ToString("dd/MM/yyyy")}"; }
    }
}
