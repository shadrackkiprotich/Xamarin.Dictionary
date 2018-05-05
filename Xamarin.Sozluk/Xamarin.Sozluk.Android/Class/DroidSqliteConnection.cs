using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Sozluk.Droid.Class;

[assembly: Xamarin.Forms.Dependency(typeof(DroidSqliteConnection))]
namespace Xamarin.Sozluk.Droid.Class
{
    public class DroidSqliteConnection : IMySqLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            string _folderPath = System.Environment.GetFolderPath(System.
                Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(_folderPath, Xamarin.Sozluk.ClassUtils.SqLiteDbName);
            var platform = new SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }
    }
}