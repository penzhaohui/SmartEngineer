using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SmartEngineer.Core.Adapter
{
    public class DatabaseAdapter : IDatabaseAdapter
    {
        public List<string> GetDBInstances(string ip, string authType, string userName, string password)
        {
            List<string> dbInstances = new List<string>();

            // C#获取所有SQL Server的数据库实例名称 - http://www.cnblogs.com/weisenz/archive/2013/01/08/2851072.html
            SqlConnection Connection = new SqlConnection(
            String.Format("Data Source={0};Initial Catalog = master;User ID = {1};PWD = {2}", ip, userName, password));

            DataTable DBNameTable = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("select name from master..sysdatabases", Connection);
            Adapter.Fill(DBNameTable);

            foreach (DataRow row in DBNameTable.Rows)
            {
                dbInstances.Add(row["name"] as string);
            }

            return dbInstances;
        }
    }
}
