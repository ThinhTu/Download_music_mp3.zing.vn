using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace DownloadMusicMp3.zing.vn
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(downloadsrc.LinkXml);
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            if (CheckVariable())
            {
                var downloadsrc = new DownloadSource(textLink.Text);
                if (downloadsrc.LinkXml != null)
                {
                    var dir = textDSTdownload.Text;
                    var webClient = new WebClient();
                    int i = 0;
                    webClient.DownloadFileAsync(new Uri(downloadsrc.ListMusics.DsItems[i].Music.Source),
                        dir + @"\" + downloadsrc.ListMusics.DsItems[i].Music.Title + "." +
                        downloadsrc.ListMusics.DsItems[i].Type);
                    webClient.DownloadProgressChanged += (u, v) =>
                    {
                        toolStripLbtitle.Text = string.Format("{0} - {1} %",
                            downloadsrc.ListMusics.DsItems[i].Music.Title, v.ProgressPercentage);
                    };
                    webClient.DownloadFileCompleted += (u, v) =>
                    {
                        if (i < downloadsrc.ListMusics.DsItems.Count - 1)
                        {
                            i++;
                            webClient.DownloadFileAsync(new Uri(downloadsrc.ListMusics.DsItems[i].Music.Source),
                                dir + @"\" + downloadsrc.ListMusics.DsItems[i].Music.Title + "." +
                                downloadsrc.ListMusics.DsItems[i].Type);
                        }
                        else
                        {
                            MessageBox.Show(@"Download Complete!");
                            EnableControl(true);
                        }

                    };
                }
                else
                {
                    MessageBox.Show("Link download nhạc không hợp lệ!");
                    EnableControl(true);
                }
            }
            else
            {
                MessageBox.Show("Lỗi chưa chọn đường dẫn!");
                EnableControl(true);
            }

        }

        private bool CheckVariable()
        {
            if (textLink.Text == "" | textDSTdownload.Text == "")
                return false;
            return true;
        }

        private void EnableControl(bool i)
        {
            textLink.Enabled = i;
            textDSTdownload.Enabled = i;
            btn_Start.Enabled = i;
            btn_openDirectory.Enabled = i;
        }

        private void btn_openDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textDSTdownload.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}