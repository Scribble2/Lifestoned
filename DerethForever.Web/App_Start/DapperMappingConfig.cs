using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using Lifestoned.DataModel.Account;

namespace DerethForever.Web
{
    internal static class DapperMappingConfig
    {
        public static void RegisterMapping()
        {
            SqlMapper.AddTypeMap(typeof(Guid), DbType.Binary);
            SqlMapper.AddTypeHandler(new GuidTypeHandler());

            ScanType<AccountModel>();
            ScanType<ManagedServerModel>();
            ScanType<SubscriptionModel>();
        }

        private static void ScanType<T>()
        {
            Type tt = typeof(T);
            SqlMapper.SetTypeMap(
                tt,
                new CustomPropertyTypeMap(
                    tt,
                    (type, column) => type.GetProperties().FirstOrDefault(
                        prop => prop.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(
                            attr => attr.Name == column))));
        }

        private class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
        {
            public override Guid Parse(object value)
            {
                return new Guid((byte[])value);
            }

            public override void SetValue(IDbDataParameter parameter, Guid value)
            {
                parameter.DbType = DbType.Binary;
                parameter.Value = value.ToByteArray();
            }
        }
    }
}