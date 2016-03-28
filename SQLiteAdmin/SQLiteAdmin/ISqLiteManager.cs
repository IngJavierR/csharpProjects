using System.Collections.Generic;

namespace SQLiteAdmin
{
    interface ISqLiteManager
    {
        List<T> Get<T>() where T : class;
        bool Save<T>(T regList) where T : class;
    }
}
