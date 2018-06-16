using System.Collections;
using System.Collections.Generic;

namespace FormateJson
{
    public enum JsonType
    {
        TYPE_NULL = 0,
        TYPE_BOOL = 1,
        TYPE_INT = 2,
        TYPE_DOUBLE = 3,
        TYPE_STRING = 4,
        TYPE_OBJECT_NULL = 10,  //{}
        TYPE_OBJECT = 11,
        TYPE_ARRAY = 12,
    }
    //json解析，序列化
    public class MyJson
    {
        const string objtab = "  ";
        const string arraytab = "  ";
        const string tab = " \t\n\b\r";
        //需要对外提供的接口
        //2. tostring
        public string ToStr()
        {
            if (_type == JsonType.TYPE_NULL)
            {
                return "null";
            }
            if (_type == JsonType.TYPE_BOOL)
            {
                return _num == 1 ? "true" : "false";
            }
            if (_type == JsonType.TYPE_INT)
            {
                return _num.ToString();
            }
            if (_type == JsonType.TYPE_DOUBLE)
            {
                return _double.ToString();
            }
            if (_type == JsonType.TYPE_STRING)
            {
                return "\"" + _string + "\"";
            }
            if (_type == JsonType.TYPE_OBJECT_NULL)
            {
                return "{}";
            }
            if (_type == JsonType.TYPE_OBJECT)
            {
                System.IO.StringWriter sw = new System.IO.StringWriter();
                sw.Write("{");
                int cnt = 0;
                foreach (var tmp in child)
                {
                    sw.Write("\"");
                    sw.Write(tmp.Key);
                    sw.Write("\":");
                    sw.Write(tmp.Value.ToStr());
                    if (++cnt < child.Count)
                        sw.Write(",");
                }
                sw.Write("}");
                return sw.ToString();
            }
            if (_type == JsonType.TYPE_ARRAY)
            {
                System.IO.StringWriter sw = new System.IO.StringWriter();
                sw.Write("[");
                int cnt = 0;
                foreach (var tmp in list)
                {
                    sw.Write(tmp.ToStr());
                    if (++cnt < list.Count)
                        sw.Write(",");
                }
                sw.Write("]");
                return sw.ToString();
            }
            return "";
        }
        //3. tostringwithformat
        public string ToStrWithFormat()
        {
            if (_type == JsonType.TYPE_NULL)
            {
                return "null";
            }
            if (_type == JsonType.TYPE_BOOL)
            {
                return _num == 1 ? "true" : "false";
            }
            if (_type == JsonType.TYPE_INT)
            {
                return _num.ToString();
            }
            if (_type == JsonType.TYPE_DOUBLE)
            {
                return _double.ToString();
            }
            if (_type == JsonType.TYPE_STRING)
            {
                return "\"" + _string + "\"";
            }
            if (_type == JsonType.TYPE_OBJECT_NULL)
            {
                return "{}";
            }
            if (_type == JsonType.TYPE_OBJECT)
            {
                if (child.Count == 0)
                    return "{}";
                System.IO.StringWriter sw = new System.IO.StringWriter();
                sw.Write("{\n");
                int cnt = 0;
                foreach (var tmp in child)
                {
                    sw.Write(objtab + "\"");
                    sw.Write(tmp.Key);
                    sw.Write("\":");
                    string sub = tmp.Value.ToStrWithFormat();
                    string[] slist = tmp.Value.ToStrWithFormat().Split('\n');
                    sw.Write(slist[0]);
                    if (slist.Length > 2)
                    {
                        for (int i = 1; i < slist.Length - 1; ++i)
                            sw.Write("\n" + objtab + slist[i]);
                        sw.Write("\n" + objtab + slist[slist.Length - 1]);
                    }
                    if (++cnt < child.Count)
                        sw.Write(",");
                    sw.Write("\n");
                }
                sw.Write("}");
                return sw.ToString();
            }
            if (_type == JsonType.TYPE_ARRAY)
            {
                if (list.Count == 0)
                    return "[]";
                System.IO.StringWriter sw = new System.IO.StringWriter();
                sw.Write("[\n");
                int cnt = 0;
                foreach (var tmp in list)
                {
                    sw.Write(arraytab);
                    //sw.Write(tmp.ToStr());
                    string[] slist = tmp.ToStrWithFormat().Split('\n');
                    sw.Write(slist[0]);
                    if (slist.Length > 2)
                    {
                        for (int i = 1; i < slist.Length - 1; ++i)
                            sw.Write("\n" + arraytab + slist[i]);
                        sw.Write("\n" + arraytab + slist[slist.Length - 1]);
                    }
                    if (++cnt < list.Count)
                        sw.Write(",");
                    sw.Write("\n");
                }
                sw.Write("]");
                return sw.ToString();
            }
            return "";
        }
        //4. 判定类型
        public bool IsNull()
        {
            return _type == JsonType.TYPE_NULL;
        }
        public bool IsInt()
        {
            return _type == JsonType.TYPE_INT;
        }
        public bool IsString()
        {
            return _type == JsonType.TYPE_STRING;
        }
        public bool IsBool()
        {
            return _type == JsonType.TYPE_BOOL;
        }
        public bool IsDouble()
        {
            return _type == JsonType.TYPE_DOUBLE;
        }
        public bool IsArray()
        {
            return _type == JsonType.TYPE_ARRAY;
        }
        public bool IsObject()
        {
            return _type == JsonType.TYPE_OBJECT;
        }

        //5. 获取数值
        public bool GetBool()
        {
            return _type == JsonType.TYPE_BOOL && _num != 0;
        }
        public int GetInt()
        {
            return _type == JsonType.TYPE_INT ? _num : 0;
        }
        public double GetDouble()
        {
            return _type == JsonType.TYPE_DOUBLE ? _double : 0.0f;
        }
        public string GetString()
        {
            return _type == JsonType.TYPE_STRING ? _string : "";
        }
        public MyJson GetObject()
        {
            return this;
        }

        //包含的数据，包括类型，数值，字符串
        public JsonType _type = JsonType.TYPE_NULL;             //默认节点类型为null
        public int _num = 0;                                    //用于存储bool型和int型数据
        public double _double = 0.0f;                           //用于存储double类型数据
        public string _string = "";                             //用于存储string类型数据
        public List<MyJson> list = new List<MyJson>(0);         //用于类型为array的节点存储子节点元素
        public Dictionary<string, MyJson> child = new Dictionary<string, MyJson>();     //用于object存储key-value类型

        //包含的内部方法
        public static MyJson ParseNull(string s)
        {
            if (s == "null")
                return new MyJson();
            return null;
        }
        public static MyJson ParseBool(string s)
        {
            if (s == "true" || s == "false")
            {
                MyJson tmp = new MyJson();
                tmp._type = JsonType.TYPE_BOOL;
                if (s == "true")
                {
                    tmp._num = 1;
                }
                else
                {
                    tmp._num = 0;
                }
                return tmp;
            }
            return null;
        }
        public static MyJson ParseInt(string s)
        {
            int index = 0;
            int num = 0;
            bool flag = false;  //是否有负号
            if (s[0] == '+' || s[0] == '-')
            {
                flag = s[0] == '-';
                index++;
            }
            for (int i = index; i < s.Length; ++i)
            {
                if (s[i] > '9' || s[i] < '0')
                    return null;
                num = num * 10 + s[i] - '0';
            }
            MyJson tmp = new MyJson();
            tmp._type = JsonType.TYPE_INT;
            tmp._num = flag ? -1 * num : num;
            return tmp;
        }
        public static MyJson ParseDouble(string s)
        {
            //校验下是否是double
            int index = 0, cnt = 0;
            if (s[0] == '+' || s[0] == '-') index++;
            for (int i = index; i < s.Length; ++i)
            {
                if (s[i] == '.')
                    cnt++;
                else if (s[i] > '9' || s[i] < '0')
                    return null;
            }
            if (cnt > 1)
                return null;

            double num = System.Convert.ToDouble(s);
            MyJson tmp = new MyJson();
            tmp._type = JsonType.TYPE_DOUBLE;
            tmp._double = num;
            return tmp;
        }
        public static MyJson ParseString(string s)
        {
            //判定是否有效字符串
            if (s.Length < 2 || s[0] != '\"' || s[s.Length - 1] != '\"')
                return null;
            MyJson tmp = new MyJson();
            tmp._type = JsonType.TYPE_STRING;
            tmp._string = s.Substring(1, s.Length - 2);
            return tmp;
        }
        public static MyJson ParseNullObject(string s)
        {
            if (s != "{}")
                return null;
            MyJson tmp = new MyJson();
            tmp._type = JsonType.TYPE_OBJECT_NULL;
            return tmp;
        }
        //对象，格式必须为{}开头结尾，中间用,隔开的key:value对
        public static MyJson ParseObject(string s)
        {
            if (s.Length == 0)
                return null;
            if (s == "null")
            {
                return ParseNull(s);
            }
            if (s == "true" || s == "false")
            {
                return ParseBool(s);
            }
            if (s == "{}")
            {
                return ParseNullObject(s);
            }
            if (s[0] == '+' || s[0] == '-' || s[0] >= '0' && s[0] <= '9')
            {
                if (s.IndexOf('.') >= 0)
                    return ParseDouble(s);
                return ParseInt(s);
            }

            if (s[0] == '"')
                return ParseString(s);
            if (s.Length < 2)
                return null;
            if (s[0] == '[' && s[s.Length - 1] == ']')
            {
                MyJson tmp = new MyJson();
                tmp._type = JsonType.TYPE_ARRAY;
                int start = 1, end = 1;
                while (end < s.Length - 1)
                {
                    while (end < s.Length - 1)
                    {
                        if (s[end] == '"')
                        {
                            ++end;
                            while (end < s.Length - 1 && s[end] != '"') ++end;
                        }
                        if (s[end] == '[')
                        {
                            ++end;
                            while (end < s.Length - 1 && s[end] != ']') ++end;
                        }
                        if (s[end] == '{')
                        {
                            ++end;
                            while (end < s.Length - 1 && s[end] != '}') ++end;
                        }
                        if (end == s.Length - 1 || s[end] == ',')
                            break;
                        ++end;
                    }
                    MyJson subtmp = ParseObject(s.Substring(start, end - start));
                    tmp.list.Add(subtmp);
                    end++;
                    start = end;
                }
                return tmp;
            }
            if (s[0] == '{' && s[s.Length - 1] == '}')
            {

                MyJson tmp = new MyJson();
                tmp._type = JsonType.TYPE_OBJECT;
                int start = 1, end = 1;
                while (end < s.Length - 1)   //到末尾
                {
                    while (end < s.Length - 1)   //到逗号或者末尾，一对key:value
                    {
                        if (s[end] == '"')
                        {
                            ++end;
                            while (end < s.Length - 1 && s[end] != '"') ++end;
                        }
                        if (s[end] == '[')
                        {
                            ++end;
                            while (end < s.Length - 1 && s[end] != ']') ++end;
                        }
                        if (s[end] == '{')
                        {
                            ++end;
                            while (end < s.Length - 1 && s[end] != '}') ++end;
                        }
                        if (end == s.Length - 1 || s[end] == ',')  //真实逗号，不是在引号里面的
                            break;
                        ++end;
                    }
                    string sub = s.Substring(start, end - start);
                    string key;
                    MyJson subtmp = ParseKeyValue(sub, out key);
                    if (subtmp == null)
                        return null;
                    if (tmp.child.ContainsKey(key))
                        return null;
                    tmp.child.Add(key, subtmp);
                    end++;
                    start = end;
                }
                return tmp;
            }
            return null;
        }

        public static MyJson ParseKeyValue(string s, out string key)
        {
            key = "";
            //获取key， value
            if (s[0] != '"')
                return null;
            int index = 1;
            while (index < s.Length && s[index] != '"') ++index;
            if (index == s.Length)
                return null;
            key = s.Substring(1, index - 1);
            //校验key是否合法
            if (!CheckKeyValid(key))
            {
                return null;
            }
            //取出后面的value来
            index++;
            if (index == s.Length || s[index] != ':')
                return null;
            index++;

            string sValue = s.Substring(index, s.Length - index);
            MyJson val = ParseObject(sValue);

            return val;
        }
        public static bool CheckKeyValid(string s)    //在key内只允许存在a-z,A-Z,0-9,-,_
        {
            if (s.Length == 0) return false;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != '-' && s[i] != '_' && !(s[i] >= '0' && s[i] <= '9') && !(s[i] >= 'a' && s[i] <= 'z') && !(s[i] >= 'A' && s[i] <= 'Z'))
                    return false;
            }
            return true;
        }

        public static string CondenceString(string s)
        {
            //主要是压缩非\"\"字符串之间的其他符号
            System.IO.StringWriter sw = new System.IO.StringWriter();
            int index = 0;
            while (index < s.Length)
            {
                //在tab内
                while (index < s.Length && tab.IndexOf(s[index]) >= 0)
                    ++index;
                if (s[index] == '\"')
                {
                    sw.Write(s[index]);
                    ++index;
                    while (index < s.Length && s[index] != '\"')
                    {
                        sw.Write(s[index]);
                        ++index;
                    }
                }

                if (index == s.Length) break;
                sw.Write(s[index]);
                ++index;
            }
            return sw.ToString();
        }
        public MyJson Key(string key)
        {
            if (_type != JsonType.TYPE_OBJECT)
            {
                return null;
            }
            MyJson tmp;
            child.TryGetValue(key, out tmp);
            return tmp;
        }
    }
}
