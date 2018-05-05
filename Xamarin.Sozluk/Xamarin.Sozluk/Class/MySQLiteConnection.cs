using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLite.Net;

namespace Xamarin.Sozluk
{
    public interface IMySqLiteConnection
    {
        SQLiteConnection GetConnection();
    }
}
