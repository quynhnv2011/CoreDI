using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Core.Common.Utils
{
    public class ObjectUtils
    {
        public static void CopyObject<T>(object sourceObject, ref T destObject, bool bolNoList)
        {
            //	If either the source, or destination is null, return
            if (sourceObject == null || destObject == null)
                return;

            //	Get the type of each object
            Type sourceType = sourceObject.GetType();
            Type targetType = destObject.GetType();

            //	Loop through the source properties
            foreach (PropertyInfo p in sourceType.GetProperties())
            {
                //	Get the matching property in the destination object
                PropertyInfo targetObj = targetType.GetProperty(p.Name);                
                //	If there is none, skip
                if (targetObj == null)
                    continue;
                if (p.PropertyType.Namespace.Contains("TTB.BackEnd"))
                    continue;
                if (bolNoList)
                {
                    if (p.PropertyType.Namespace.Contains("System.Collections.Generic"))
                        continue;
                }
                try
                {
                    if (p.CanWrite)
                        targetObj.SetValue(destObject, p.GetValue(sourceObject, null), null);
                }
                catch (Exception)
                {
                }

            }
        }

        public static string ObjectToString(object obj,HashSet<string> exceptProperties)
        {
            if (obj == null) return string.Empty;
            Type t = obj.GetType();
            var props = t.GetProperties().OrderByDescending(q => q.Name).ToList();

            var strResult = string.Empty;
            foreach (PropertyInfo prp in props)
            {
                if (!exceptProperties.Contains(prp.Name) 
                    && !prp.PropertyType.Namespace.Contains("System.Collections.Generic")
                    && !prp.PropertyType.Namespace.Contains("TTB.BackEnd"))
                {
                    object value = prp.GetValue(obj, new object[] { });
                    if (value == null) value = string.Empty;

                    strResult = string.Format("{0}-{1}:{2}", strResult, prp.Name, value);
                }
            }
            return strResult;
        }

        
        public static T Clone<T>(T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            var props = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            for (var i = 0; i < props.Count; i++)
            {
                var prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            var values = new object[props.Count];
            foreach (T item in data)
            {
                for (var i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}
