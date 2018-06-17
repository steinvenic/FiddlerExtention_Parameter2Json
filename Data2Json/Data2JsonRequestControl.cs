using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using FormateJson;



namespace Data2Json
{
    public partial class Data2JsonRequestControl : UserControl
    {
        public Data2JsonRequestControl()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                string s = System.Web.HttpUtility.UrlDecode((new JavaScriptSerializer()).Serialize(value));
                string str = MyJson.CondenceString(s);
                MyJson doc = MyJson.ParseObject(str);
                HeaderBox.Text = doc.ToStrWithFormat();

            }

        }


        public byte[] Body
        {
            set
            {
                if (null != value)
                {
                    string ret = System.Text.Encoding.UTF8.GetString(value);
                    if (ret.StartsWith("[") || ret.StartsWith("{") || ret=="")
                    {
                        DataBox.Text = "Null";
                    }
                    else {
                        string[] formParameters = ret.Split('&');

                        Dictionary<string, string> oscar = new Dictionary<string, string>();
                        foreach (string valuePair in formParameters)
                        {
                            System.Web.HttpUtility.UrlDecode(valuePair);
                            string[] formParameter = valuePair.Split('=');

                            oscar.Add(System.Web.HttpUtility.UrlDecode(formParameter[0]), System.Web.HttpUtility.UrlDecode(formParameter[1]));

                            PopulateGrid(oscar);


                        }
                        string s = System.Web.HttpUtility.UrlDecode((new JavaScriptSerializer()).Serialize(oscar));
                        string str = MyJson.CondenceString(s);
                        MyJson doc = MyJson.ParseObject(str);
                        DataBox.Text = doc.ToStrWithFormat();
                    }


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
            Clipboard.SetDataObject(DataBox.Text);
            PopulateGrid(new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(DataBox.Text));
        }

        private void CopyHeaderContent(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(HeaderBox.Text);
            PopulateGrid(new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(HeaderBox.Text));
        }
    }
}
