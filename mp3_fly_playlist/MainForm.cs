using System;
using System.Linq;
using System.Windows.Forms;

namespace mp3_fly_playlist
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            lbPlaylist.DataSource = Playlist.Singleton.Items;
            lbPlaylist.DisplayMember = "Name";
            lbPlaylist.ValueMember = "SDPath";
        }

        private void directoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdChooseMp3.Multiselect = false;
            if (ofdChooseMp3.ShowDialog() == DialogResult.OK)
            {
                Playlist.Singleton.AddDirectory(ofdChooseMp3.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdChooseMp3.Multiselect = true;
            if (ofdChooseMp3.ShowDialog() == DialogResult.OK)
            {
                Playlist.Singleton.AddFiles(ofdChooseMp3.FileNames);
            }
        }

        private void lbPlaylist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Playlist.Singleton.DeleteItems(lbPlaylist.SelectedItems.Cast<Mp3Item>().ToArray());
            }
            else if (e.Control)
            {
                if (e.KeyCode == Keys.Up)
                {
                    Playlist.Singleton.MoveUpItems(lbPlaylist.SelectedItems.Cast<Mp3Item>().ToArray());
                }
                else if (e.KeyCode == Keys.Down)
                {
                    Playlist.Singleton.MoveDownItems(lbPlaylist.SelectedItems.Cast<Mp3Item>().ToArray());
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sfdSavePlaylist.ShowDialog() == DialogResult.OK)
            {
                Playlist.Singleton.Save(sfdSavePlaylist.FileName);
            }
        }
    }
}
