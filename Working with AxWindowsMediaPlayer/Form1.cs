using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//ref link:https://www.youtube.com/watch?v=KXi3KQiMqGw&list=PLAIBPfq19p2EJ6JY0f5DyQfybwBGVglcR&index=61
// media player for mp3 and videos .....

namespace Working_with_AxWindowsMediaPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //mediaPlayer.uiMode = "none"; // ="" (none, mini, invisible, full) full is the default
            //mediaPlayer.ShowPropertyPages(); // media settings
            //mediaPlayer.settings.autoStart = false; // auto start off
            //mediaPlayer.settings.mute = true; // starts up muted
            mediaPlayer.settings.volume = 75; // sounds 75%

        }

        private void btnPickFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgOpenFile = new OpenFileDialog())
            {
                dlgOpenFile.Filter = "All Files|*.*";
                
                if(dlgOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        mediaPlayer.URL = dlgOpenFile.FileName;
                        lblPath.Text = dlgOpenFile.FileName;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Unable to load file!\n\n" + ex.Message);
                    }
                }
            } 
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mediaPlayer.Ctlcontrols.stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            mediaPlayer.Ctlcontrols.play();
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            if(mediaPlayer.URL.Length > 0)
            {
                mediaPlayer.fullScreen = true;
            }
        }

        private void mediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(mediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped) // repeat play more than once
            {
                mediaPlayer.Ctlcontrols.play(); 
            }
        }
    }
}
