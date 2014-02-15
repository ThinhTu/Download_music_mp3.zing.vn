using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadMusicMp3.zing.vn
{
    /// <summary>
    /// class cho biết 1 đối tượng music có những thành phần nào
    /// </summary>
    class Music
    {
        /// <summary>
        /// tên 1 bài hát
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// thông tin về ca sĩ
        /// </summary>
        public string Performer { get; set; }

        /// <summary>
        /// link nghe nhạc online
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// nguồn bài hát 
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// thuộc tính hq
        /// </summary>
        public string Hq { get; set; }

        public Music(string _title, string _performer, string _link, string _souce, string _hq)
        {
            this.Title = _title;
            this.Performer = _performer;
            this.Link = _link;
            this.Source = _souce;
            this.Hq = _hq;
        }
    }
}
