using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Bill_Tracker
{
    internal class Database
    {

        private readonly SQLiteAsyncConnection _connection;

        public Database(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<Record>();
        }

    }
}
