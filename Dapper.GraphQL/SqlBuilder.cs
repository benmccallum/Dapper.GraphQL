﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dapper.GraphQL
{
    /// <summary>
    /// A builder for SQL queries and statements.
    /// </summary>
    public static class SqlBuilder
    {
        public static SqlDeleteContext Delete(string from, dynamic parameters = null)
        {
            return new SqlDeleteContext(from, parameters);
        }

        public static SqlDeleteContext Delete<TEntityType>(dynamic parameters = null)
        {
            return new SqlDeleteContext(TableHelper.GetTableName<TEntityType>(), parameters);
        }

        public static SqlQueryContext From(string from, dynamic parameters = null)
        {
            return new SqlQueryContext(from, parameters);
        }

        public static SqlQueryContext From<TEntityType>(string alias = null)
        {
            return new SqlQueryContext<TEntityType>(alias);
        }

        public static SqlInsertContext Insert<TEntityType>(TEntityType obj)
        {
            return new SqlInsertContext(TableHelper.GetTableName<TEntityType>(), obj);
        }

        public static SqlInsertContext Insert(string table, dynamic parameters = null)
        {
            return new SqlInsertContext(table, parameters);
        }

        public static SqlUpdateContext Update<TEntityType>(TEntityType obj)
        {
            return new SqlUpdateContext(TableHelper.GetTableName<TEntityType>(), obj);
        }

        public static SqlUpdateContext Update(string table, dynamic parameters = null)
        {
            return new SqlUpdateContext(table, parameters);
        }
    }
}