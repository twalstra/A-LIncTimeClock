using System;
using System.Collections.Generic;
using Java.Text;
using Java.Util;

namespace TimeTrackerTutorial.Droid.Extensions
{
    public static class JavaLangExtensions
    {
        public static IDictionary<string, object> ToDictionary(this IDictionary<string, Java.Lang.Object> map)
        {
            var dict = new Dictionary<string, object>();

            foreach (var key in map.Keys)
            {
                if (key.Equals("Work"))
                {
                    // temp breakpoint
                }
                var value = map[key];
                if (value is Java.Lang.Boolean bln)
                {
                    dict.Add(key, bln.BooleanValue());
                }
                else if (value is Java.Lang.Long lng)
                {
                    dict.Add(key, lng.IntValue());
                }
                else if (value is Java.Lang.Integer integer)
                {
                    dict.Add(key, integer.IntValue());
                }
                else if (value is Java.Lang.Double dbl)
                {
                    dict.Add(key, dbl.DoubleValue());
                }
                else if (value is Java.Lang.String str)
                {
                    dict.Add(key, str.ToString());
                }
                else if (value is Java.Util.Date dt)
                {
                    var dtFormat = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss");
                    dict.Add(key, dtFormat.Format(dt));
                }
                else if (value is System.Collections.ICollection collection)
                {
                    var arrList = new ArrayList(collection);
                    var list = new List<object>();

                    for (var i = 0; i < arrList.Size(); i++)
                    {
                        var listItem = arrList.Get(i);
                        var hMap = listItem as System.Collections.IDictionary;
                        if (hMap != null)
                        {
                            var hMapDict = new Dictionary<string, Java.Lang.Object>();
                            foreach (var k in hMap.Keys)
                            {
                                System.Diagnostics.Debug.WriteLine(k);
                                var kStr = k.ToString();
                                Java.Lang.Object jObj = null;
                                try
                                {
                                    jObj = (Java.Lang.Object)hMap[k];
                                }
                                catch (Exception e)
                                {
                                    // couldn't cast to a Java.Lang.Object for some reason..
                                    jObj = new Java.Lang.String(hMap[k].ToString());
                                }
                                hMapDict.Add(kStr, jObj);
                            }
                            list.Add(hMapDict.ToDictionary());
                        }
                        else
                        {
                            list.Add(arrList.Get(i).ToString());
                        }
                    }
                    dict.Add(key, list);
                }
                else
                {
                    dict.Add(key, value.ToString());
                }
            }

            return dict;
        }
    }
}
