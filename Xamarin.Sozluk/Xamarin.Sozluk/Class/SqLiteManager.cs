using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Sozluk.Models;
namespace Xamarin.Sozluk
{
    public class SqLiteManager
    {
        private readonly SQLiteConnection _sqlConnection;
        public SqLiteManager()
        {
            _sqlConnection = DependencyService.Get<IMySqLiteConnection>().GetConnection();
            _sqlConnection.CreateTable<WordModel>();
        }
        public int Insert(WordModel k)
        {
            return _sqlConnection.Insert(k);
        }
        public int Update(WordModel k)
        {
            return _sqlConnection.Update(k);
        }
        public IEnumerable<WordModel> GetAll()
        {
            return _sqlConnection.Table<WordModel>();
        }

        public bool Exists(string k)
        { 
            return _sqlConnection.Table<WordModel>().Where(x => x.ObjectKey == k).ToList().Count > 0;
        }
        public void Dispose()
        {
            _sqlConnection.Dispose();
        }
    }
}
