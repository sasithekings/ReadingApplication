
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

    }
}
