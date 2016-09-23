using System;
using SQLite;

namespace BloodDonors
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
