
using SQLite;
using System.Collections.ObjectModel;

namespace Reading
{
    public class ReadingDataBase
    {
        SQLiteConnection database;

        public ReadingDataBase()
        {
            var databasePath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "Database.db3");
            database = new SQLiteConnection(databasePath);
            database.CreateTable<DataEntry>();
        }

        public void InsertDataItem(DataEntry item)
        {
            database.Insert(item);
        }

        public ObservableCollection<DataEntry> GetDataItems()
        {
            return new ObservableCollection<DataEntry>(database.Table<DataEntry>());
        }
    }
}
