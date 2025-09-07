using OptionalToursAPI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Common;
using System.Linq;
using PAMAPI.Core.Entities;

namespace OptionalToursAPI.Infrastructure.Context
{
    public class DatabaseManager : IDataBaseManager
    {
        public OdbcCommand CreateCommand(OdbcConnection connection)
        {
            return connection.CreateCommand();
        }

        public async Task<List<T>> ExecuteReaderAllAsync<T>(OdbcCommand command)
        {
            using (var reader = await command.ExecuteReaderAsync())
            {
                var items = new List<T>();
                while (reader.Read())
                {
                    items.Add(Map<T>(reader));
                }
                return items;
            }
        }

        public async Task<T> ExecuteReaderAsync<T>(OdbcCommand command)
        {
            using (var reader = await command.ExecuteReaderAsync())
            {
                var items = new List<T>();
                while (reader.Read())
                {
                    return (Map<T>(reader));
                }
                return default(T);
            }
        }

        public object ExecuteScalar(OdbcCommand command)
        {
            return command.ExecuteScalar();
        }

        public async Task<int> ExecuteNonQueryAsync(OdbcCommand command)
        {
            return await command.ExecuteNonQueryAsync();
        }

        protected TEntity Map<TEntity>(IDataRecord record)
        {
            var objT = Activator.CreateInstance<TEntity>();
            Type type = objT.GetType();
            PropertyInfo[] props = type.GetProperties();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                if (record.HasColumn(property.Name) && !record.IsDBNull(record.GetOrdinal(property.Name)))
                {
                    var convertedValue = ConvertAndAssignValue(Convert.ToString(property.PropertyType).ToLower(), record[property.Name]);
                    property.SetValue(objT, convertedValue);
                }
            }
            return objT;
        }

        public static object ConvertAndAssignValue(string propertyType, object record)
        {
            switch (propertyType)
            {
                case string s when s.Contains("system.int64"):
                    return Convert.ToInt64(record);
                case string s when s.Contains("system.int32"):
                    return Convert.ToInt32(record);
                case string s when s.Contains("system.byte[]"):
                    return Convert.ToByte(record);
                case string s when s.Contains("system.bool"):
                    return Convert.ToBoolean(record);
                case string s when s.Contains("system.char"):
                    return Convert.ToChar(record);
                case string s when s.Contains("system.datetime"):
                    return Convert.ToDateTime(record);
                case { } s when s.Contains("system.timespan"):
                    var newTimeSpan = TimeSpan.Parse(Convert.ToString(record));
                    return newTimeSpan;
                case string s when s.Contains("system.decimal"):
                    return Convert.ToDecimal(record);
                case string s when s.Contains("system.double"):
                    return Convert.ToDouble(record);
                case string s when s.Contains("system.int"):
                    return Convert.ToInt32(record);
                case string s when s.Contains("system.string"):
                    return Convert.ToString(record).Trim();
                case string s when s.Contains("system.single"):
                    return Convert.ToSingle(record);
                case string s when s.Contains("system.int16"):
                    return Convert.ToInt16(record);
                case string s when s.Contains("system.byte"):
                    return Convert.ToByte(record);
                case string s when s.Contains("system.guid"):
                    Guid newGuid = Guid.Parse(Convert.ToString(record).Trim());
                    return newGuid;
                default:
                    return null;
            }

        }
    }

    public static class DataRecordExtensions
    {
        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (var i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
