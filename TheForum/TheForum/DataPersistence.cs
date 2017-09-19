using System;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using SQLite;

namespace TheForum
{
    public class DataPersistence
    {

        readonly SQLiteAsyncConnection database;

		public DataPersistence(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<DataTable>().Wait();
		}


        public Task<List<DataTable>> GetItemsAsync()
		{
			return database.Table<DataTable>().ToListAsync();
		}

        public Task<DataTable> LoadUser() 
        {
            return database.Table<DataTable>().FirstAsync();

        }

        public Task<int> SaveItemAsync(DataTable data)
		{
				return database.InsertAsync(data);
		}

        public Task<int> DeleteItemAsync(string name)
		{
			return database.DeleteAsync(name);
		}


        public void DropTable(){

            database.ExecuteAsync("delete from DataTable");

        }


    }
}

