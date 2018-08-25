using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dapper;

namespace DerethForever.Web
{
    static class DapperMappingConfig
    {
        // Section
        //SqlMapper.SetTypeMap(typeof(Section), new CustomPropertyTypeMap(
        //  typeof(Section), (type, columnName) => type.GetProperties().FirstOrDefault(prop =>
        //	prop.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(attr => attr.Name == columnName))));
		public static void RegisterMapping()
        {
        }

		private static void ScanType<T>()
        {
            Type tt = typeof(T);
            SqlMapper.SetTypeMap(tt, new CustomPropertyTypeMap(tt,
                (type, column) => type.GetProperties()
					.FirstOrDefault(prop => prop.GetCustomAttributes(false)
						.OfType<ColumnAttribute>().Any(attr => attr.Name == column))
                ));
        }
    }
}