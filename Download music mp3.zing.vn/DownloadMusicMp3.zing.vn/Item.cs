using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadMusicMp3.zing.vn
{
    /// <summary>
    /// trang web có nhiều loại type khác nhau như video mp3 ....
    /// </summary>
    class Item
    {
        /// <summary>
        /// kiểu loại nhạc
        /// </summary>
        public string Type { get; set; }

        public Music Music { get; set; }

        public Item(string type, Music ms)
        {
            this.Type = type;
            this.Music = ms;
        }
    }
}
