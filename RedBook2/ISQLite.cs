using System;
using System.Collections.Generic;
using System.Text;

namespace RedBook2
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
