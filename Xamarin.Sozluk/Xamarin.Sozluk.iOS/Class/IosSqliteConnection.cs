using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;

namespace Xamarin.Sozluk.iOS.Class
{
    public class IosSqliteConnection: IMySqLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            string _folderPath = System.Environment.GetFolderPath(System.
                Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(_folderPath, Xamarin.Sozluk.ClassUtils.SqLiteDbName);
            var platform = new SQLitePlatformIOS();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }
    }
}