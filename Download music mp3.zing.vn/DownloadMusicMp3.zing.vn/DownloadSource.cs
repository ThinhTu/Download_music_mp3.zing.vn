using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;

namespace DownloadMusicMp3.zing.vn
{
    /// <summary>
    /// download souce của trang web 
    /// </summary>
    class DownloadSource
    {
        /// <summary>
        /// địa chỉ của trang web cần download 
        /// </summary>
        public string Url { get; set; } 
        /// <summary>
        /// link xml chứa thông tin nhạc của trang web 
        /// </summary>
        public string LinkXml { get; set; }

        /// <summary>
        /// tai lieu xmldocument
        /// </summary>
        public XmlDocument XmlDoc { get; set; }

        public ListItem ListMusics { get; set; }

        public string GetSource(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            var reader = new StreamReader(request.GetResponse().GetResponseStream());
            string src = reader.ReadToEnd();
            return src;
        }

        public DownloadSource(string url)
        {
            string src = GetSource(url);
            Url = GetUrlPage(url);
            ToXmlUrl(src);
            if (LinkXml != null)
            {
                XmlDoc = new XmlDocument();
                string srcxml = GetSource(LinkXml);
                XmlDoc.LoadXml(srcxml);
                XMlDocToData();
            }
        }

        public string GetUrlPage(string url)
        {
            if (!url.StartsWith("http://"))
                url = "http://" + url;
            var arr = url.Split('/');
            return "http://" + arr[2];
        }

        public void ToXmlUrl(string dsrc)
        {
            if (this.Url == "http://mp3.zing.vn")
            {
                try
                {
                    var arr = dsrc.Split(new string[] { "xmlURL=" }, StringSplitOptions.None);
                    var kq = arr[1].Split(new string[] { "&amp" }, StringSplitOptions.None);
                    LinkXml = kq[0]; 
                }
                catch (Exception)
                {
                    
                }         
                  
            }
        }

        public void XMlDocToData()
        {
            var data = XmlDoc.GetElementsByTagName("data");
            var dtdata = new ListItem();
            dtdata.Page = data[0].Attributes["page"].Value;
            var items = XmlDoc.GetElementsByTagName("item");
            var dsItem = new ListItem();
            foreach (XmlNode item in items)
            {
                var ms = new Music(item["title"].InnerText, item["performer"].InnerText, item["link"].InnerText, item["source"].InnerText, item["hq"].InnerText);
                var it = new Item(item.Attributes["type"].Value,ms);
                dsItem.ThemItem(it);
            }
            ListMusics = dsItem;
        }
    }
}
