﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinder.DataAccess
{
    public interface IDbConnectionFactory
    {
        DbConnection GetConnection();
    }
}
