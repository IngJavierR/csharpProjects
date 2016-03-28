using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Transactions;

namespace SQLiteAdmin
{
    public class SqLiteManager : ISqLiteManager, IDisposable
    {
        private readonly SQLiteConnection _connection;
        private readonly DataContext _context;

        public SqLiteManager(string dbName)
        {
            if (!File.Exists(dbName))
                SQLiteConnection.CreateFile(dbName);

            _connection = new SQLiteConnection(string.Format("Data Source = {0}; Version = 3;", dbName));
            _connection.Open();
            GenerateTables();
            _context = new DataContext(_connection);
        }

        private void GenerateTables()
        {
            var sql = string.Format("CREATE TABLE IF NOT EXISTS {0}({1},{2},{3},{4},{5},{6},{7},{8},{9})",
                "INCOMES",
                "ID INTEGER PRIMARY KEY NOT NULL",
                "TIPO_PAGO INT NOT NULL",
                "FECHA_OPERACION INT NOT NULL",
                "HORA_OPERACION INT NOT NULL",
                "EXPECTED_SIZE INT NOT NULL",
                "REAL_SIZE INT NOT NULL",
                "MENSAJE BLOB NOT NULL",
                "SIZE_VALID INT NOT NULL",
                "STRUCTURE_VALID INT NOT NULL");
            var command = new SQLiteCommand(sql, _connection);
            command.ExecuteNonQuery();
        }

        public List<T> Get<T>() where T : class
        {
            return _context.GetTable<T>().ToList();
        }

        public bool Save<T>(T regList) where T : class
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var data = _context.GetTable<T>();
                    data.InsertOnSubmit(regList);
                    _context.SubmitChanges();
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new SQLiteException(ex.Message);
                }
            }
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
            _connection.Close();
        }
    }
}
