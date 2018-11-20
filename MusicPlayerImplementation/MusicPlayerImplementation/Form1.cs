using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayerImplementation
{
    public partial class Form1 : Form
    {
        MusicPlayer player;
        public Form1()
        {
            InitializeComponent();
            player = new MusicPlayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(player.State == PlaybackState.Stopped)
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    player.SelectMedia(listBox1.SelectedIndex);
                    button1.Text = "Pause";
                    player.Play();
                }
            }
            if (player.State==PlaybackState.Paused)
            {
                button1.Text = "Pause";
                player.Play();
            }
            else
            {
                button1.Text = "Play";
                player.Pause();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MP3 Files | *.mp3";
            ofd.Multiselect = true;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                player.LoadPlaylist(new List<string>(ofd.FileNames));
                foreach(string song in player.Playlist)
                {
                    System.IO.FileInfo info = new System.IO.FileInfo(song);
                    listBox1.Items.Add(info.Name);
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                player.SelectMedia(listBox1.SelectedIndex);
                button1.Text = "Pause";
                player.Play();
            }
        }
    }
}
