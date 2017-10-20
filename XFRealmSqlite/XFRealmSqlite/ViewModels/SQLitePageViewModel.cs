using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XFRealmSqlite.Repository;
using XFRealmSqlite.SQLiteModel;

namespace XFRealmSqlite.ViewModels
{
    public class SQLitePageViewModel : BaseViewModel
    {
        private readonly SQLiteRepository _repository;

        public ObservableCollection<People> PeopleList { get; }
        public SQLitePageViewModel()
        {
            InsertCommand = new Command(InsertCommandAsync, CanInsert);
            DeleteAllCommand = new Command(DeleteAllAsync);
            GetAllCommand = new Command(GetAllAsync);
            _repository = new SQLiteRepository(); //Could be changed for an interface so we could inject its dependency

            PeopleList = new ObservableCollection<People>();
        }
        private bool CanInsert() => !string.IsNullOrWhiteSpace(Name);

        private async void InsertCommandAsync()
        {
            try
            {
                IsBusy = true;

                var people = new People
                {
                    Name = Name,
                    BirthDate = BirthDate
                };

                _repository.Insert(people);
                await MessageService.ShowAsync("Success", "Data inserted in the SQLite table.");

                
            }
            catch (Exception ex)
            {
                await MessageService.ShowAsync("Erro", "An error ocurred when trying to save the People in the SQLite table.");
            }

            IsBusy = false;
        }

        private async void DeleteAllAsync()
        {
            try
            {
                IsBusy = true;

                _repository.DeleteAll();

                
            }
            catch (Exception ex)
            {
                await MessageService.ShowAsync("Erro", "An error ocurred when trying to delete all the People in the Database.");
            }

            IsBusy = false;
        }

        private async void GetAllAsync()
        {
            try
            {
                IsBusy = true;
                PeopleList.Clear();

                var people =_repository.GetAll();
                foreach (var p in people)
                {
                    PeopleList.Add(p);
                }

                
            }
            catch (Exception ex)
            {
                await MessageService.ShowAsync("Erro", "An error ocurred when trying to delete all the People in the Database.");
            }

            IsBusy = false;
        }
    }
}

