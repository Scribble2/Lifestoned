using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestoned.DataModel
{
    public static class EnumHelper
    {
        public static T GetAttributeOfType<T>(this System.Enum enumVal) where T : System.Attribute
        {
            if (enumVal == null)
                return null;

            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}
