using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Utils
{
    public static class ConvertToJson
    {
        public static string ConvertToJSON(this Type EnumType)
        {
            if (!EnumType.IsEnum)
                throw new InvalidOperationException("Enum was expected");


            var results = Enum.GetValues(EnumType).Cast<object>().ToDictionary(enumValue => enumValue.ToString(), enumValue => (int)enumValue);
            return String.Format("{{ \"{0}\" : {1} }}", EnumType.Name, Newtonsoft.Json.JsonConvert.SerializeObject(results));

        }
    }
}