using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace WindowsFormsApp1
{
    public static class FSJsonParser
    {
        public static string ObjToJson(System.Object _obj)
        {
            Type t = _obj.GetType();
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            string content = "";
            List<string> fields = new List<string>();

            for (int i = 0; i < propInfos.Length; i++)
            {
                //Debug.Log(propInfos[i].PropertyType.Name + " - " + propInfos[i].Name + " : " + propInfos[i].GetValue(_obj).ToString());

                string comma = (i == propInfos.Length - 1) ? "" : ",";
                fields.Add("\"" + propInfos[i].Name + "\":"
                    + "{"
                    + "\"" + GetFSValueTypeString(propInfos[i].PropertyType) + "\""
                    + ":\"" + propInfos[i].GetValue(_obj).ToString() + "\""
                    + "}" + comma);
            }

            for (int i = 0; i < fields.Count; i++)
            {
                content = content + fields[i];
            }

            return "{\"fields\":{" + content + "}}";
        }

        // Using string to check is not very good. Using C# 7 's new feature would be better.
        static string GetFSValueTypeString(Type _type)
        {
            string result = "";
            switch (_type.Name)
            {
                case "String":
                    result = "stringValue";
                    break;
                case "Boolean":
                    result = "booleanValue";
                    break;
                case "Int32":
                    result = "integerValue";
                    break;
                case "Single":
                    result = "doubleValue"; // There is no floatValue in Firestore
                    break;
                case "Double":
                    result = "doubleValue";
                    break;
            }
            return result;
        }
    }
}
