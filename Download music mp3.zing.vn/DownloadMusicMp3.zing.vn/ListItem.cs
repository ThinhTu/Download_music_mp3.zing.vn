using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadMusicMp3.zing.vn
{
    /// <summary>
    /// Dữ liệu về trang web
    /// </summary>
    class ListItem
    {
        /// <summary>
        /// trang web đang hiện hành download nhạc
        /// </summary>
        public string Page { get; set; }

        public List<Item> DsItems { get; set; }

        public ListItem()
        {
            DsItems = new List<Item>();
        }

        public void ThemItem(Item it)
        {
            DsItems.Add(it);
        }
    }
}
