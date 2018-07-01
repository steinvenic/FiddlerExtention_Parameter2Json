using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using FormateJson;
using Newtonsoft.Json;

namespace Data2Json
{
    public partial class Data2JsonRequestControl : UserControl
    {
        public Data2JsonRequestControl()
        {
            InitializeComponent();
        }
        private string ConvertJsonString(string str)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }

        public void Clear()
        {
            DataBox.Text = string.Empty;
            HeaderBox.Text = string.Empty;
            UrlBox.Text = string.Empty;

        }
        public Dictionary<string, string> Headers
        {
            set
            {
                Dictionary<string, string> query = new Dictionary<string, string>();
                //处理URL
                if (value["requestUrl"].Contains("?"))//URl是否包含参数
                {
                    string[] arrayUrlParse = value["requestUrl"].Split('?');//分离参数和HOST
                    hostLabel.Text = arrayUrlParse[0];
                    string urlParses = arrayUrlParse[1];//获取所有参数
                    string[] urlQuerys = urlParses.Split('&');//获取单个参数项
                    foreach (string urlQuery in urlQuerys) {
                        string[] oneQuery = urlQuery.Split('=');
                        query.Add(System.Web.HttpUtility.UrlDecode(oneQuery[0]), System.Web.HttpUtility.UrlDecode(oneQuery[1]));
                    }
                    string urlSerializeJSON = JsonConvert.SerializeObject(query, Formatting.Indented);
                    UrlBox.Text = ConvertJsonString(urlSerializeJSON);
                    value.Remove("requestUrl");
                }
                else {
                    UrlBox.Text = "Null";
                    hostLabel.Text = value["requestUrl"];
                }

                //处理Header
                try
                {
                    value.Remove("requestUrl");
                }
                catch {
                }
                string strSerializeJSON = JsonConvert.SerializeObject(value, Formatting.Indented);
                HeaderBox.Text = ConvertJsonString(strSerializeJSON);
            }

        }


        public byte[] Body
        {
            set
            {
                if (null != value)
                {
                    string ret = System.Text.Encoding.UTF8.GetString(value);
                    if (ret.StartsWith("[") || ret.StartsWith("{") || ret == "")
                    {
                        DataBox.Text = "Null";
                    }
                    else
                    {
                        string[] formParameters = ret.Split('&');
                        Dictionary<string, string> dataDict = new Dictionary<string, string>();
                        foreach (string valuePair in formParameters)
                        {
                            System.Web.HttpUtility.UrlDecode(valuePair);
                            string[] formParameter = valuePair.Split('=');

                            try
                            {
                                dataDict.Add(System.Web.HttpUtility.UrlDecode(formParameter[0]), System.Web.HttpUtility.UrlDecode(formParameter[1]));
                            }
                            catch {

                            }
                            
                            PopulateGrid(dataDict);
                        }
                        string strSerializeJSON = JsonConvert.SerializeObject(dataDict, Formatting.Indented);
                        DataBox.Text = ConvertJsonString(strSerializeJSON);
                    }

                }
                else {
                    DataBox.Text = "Null";
                }

            }
        }

        private void PopulateGrid(Dictionary<string, string> dictionary)
        {
            dataGridView1.Rows.Clear();

                foreach (string key in dictionary.Keys)
                {
                    dataGridView1.Rows.Add(key, dictionary[key]);
                }

        }

        private void CopyDataContent(object sender, EventArgs e)
        {
            if (DataBox.Text != "Null") {
                Clipboard.SetDataObject(DataBox.Text);
                PopulateGrid(JsonConvert.DeserializeObject<Dictionary<string, string>>(DataBox.Text));
            }
            else
            {
                dataGridView1.Rows.Clear();
            }

        }

        private void CopyHeaderContent(object sender, EventArgs e)
        {
            if (HeaderBox.Text != "Null")
            {
                Clipboard.SetDataObject(HeaderBox.Text);
                //PopulateGrid(new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(HeaderBox.Text));
                PopulateGrid(JsonConvert.DeserializeObject<Dictionary<string, string>>(HeaderBox.Text));
            }
            else {
                dataGridView1.Rows.Clear();
            }

        }

        private void copyUrlContent(object sender, EventArgs e)
        {
            if (UrlBox.Text != "Null")
            {
                Clipboard.SetDataObject(UrlBox.Text);
                PopulateGrid(JsonConvert.DeserializeObject<Dictionary<string, string>>(UrlBox.Text));
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void copyHostUrlContent(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(hostLabel.Text);
        }
    }
}
