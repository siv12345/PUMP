using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace PUMP_v1
{
    public partial class Sample : Form
    {
        public Sample()
        {
            InitializeComponent();
           
            
        }

        /// <summary>
        /// When the Vlc control needs to find the location of the libvlc.dll.
        /// You could have set the VlcLibDirectory in the designer, but for this sample, we are in AnyCPU mode, and we don't know the process bitness.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vlcControl_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "( *.mp4) | *.mp4"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                vlcControl1.SetMedia(new FileInfo(Path.GetFileName(ofd.FileName)));
                vlcControl1.Play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vlcControl1.Pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vlcControl1.Play();
        }
    }
}
