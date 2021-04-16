using System;
using System.Collections.Generic;
using Java.Util;
using Newtonsoft.Json.Linq;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.Droid.Extensions
{
    public static class IIdentifiableExtensions
    {
        public static HashMap ToHashMap(this Dictionary<string, Java.Lang.Object> dict)
        {
            var map = new Java.Util.HashMap();
            foreach (var k in dict.Keys)
            {
                map.Put(new String(k), dict[k]);
            }
            return map;
        }
        public static Dictionary<string, Java.Lang.Object> Convert(this IIdentifiable item)
        {
            var dict = new Dictionary<string, Java.Lang.Object>();

            var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            var propertyDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonStr);

            foreach (var key in propertyDict.Keys)
            {
                if (key.Equals("Id"))
                    continue;
                var val = propertyDict[key];
                Java.Lang.Object javaVal = null;
                if (val is string str)
                    javaVal = new Java.Lang.String(str);
                else if (val is double dbl)
                    javaVal = new Java.Lang.Double(dbl);
                else if (val is int intVal)
                    javaVal = new Java.Lang.Integer(intVal);
                else if (val is DateTime dt)
                    javaVal = dt.ToString();
                else if (val is bool boolVal)
                    javaVal = new Java.Lang.Boolean(boolVal);
                else if (val is JContainer container)
                {
                    for (var i = 0; i < container.Count; i++)
                    {
                        var jItem = container[i];
                    }
                }
                else if (val is IList<IIdentifiable> collection)
                {
                    var list = new ArrayList();
                    foreach (var idItem in collection)
                    {
                        list.Add(idItem.Convert().ToHashMap());
                    }
                    javaVal = list;
                }
                else if (val is IIdentifiable innerObj)
                {
                    var map = innerObj.Convert().ToHashMap();
                    javaVal = map;
                }

                if (javaVal != null)
                    dict.Add(key, javaVal);
            }

            return dict;
        }
    }
}
