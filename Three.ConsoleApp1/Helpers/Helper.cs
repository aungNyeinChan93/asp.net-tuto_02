using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Three.ConsoleApp1.Helpers
{
    public static class Helper
    {
        public static string ToJson(this object obj) 
        { 
            string jsonStr = JsonConvert.SerializeObject(obj);
            return jsonStr;
        }

        public static object? ToObject(this string str)
        {
            var result = JsonConvert.DeserializeObject(str);
            return result;
        }

        public static T? ToObject<T>(this string str)
        {
            var result = JsonConvert.DeserializeObject<T>(str);
            return result;
        }
    }
}
